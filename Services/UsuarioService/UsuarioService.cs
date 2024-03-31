using ApiChistes.Data;
using ApiChistes.Models;
using ApiChistes.Models.DTO;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace ApiChistes.Services.UsuarioService
{
    public class UsuarioService : IUsuarioService
    {
        private IConfiguration _configuration;
        public readonly DataBaseContext _context;

        public UsuarioService(DataBaseContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<List<Usuario>> GetAllUsuarios()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task<Usuario> RegistrarUsuario(UsuarioRegistrarDto usuario)
        {
            byte[] salt = RandomNumberGenerator.GetBytes(128 / 8); // divide by 8 to convert bits to bytes
            
            string strSalt = Convert.ToBase64String(salt);
            string pass = HashPassword(usuario.Password, salt);
            
            Usuario auxUsuario = new Usuario(usuario.Email, usuario.NombreUsuario,pass, strSalt);

            _context.Usuarios.Add(auxUsuario);
            await _context.SaveChangesAsync();

            return auxUsuario;
        }


        public async Task<string> LoginUsuario(UsuarioLoginDto usuario)
        {
            string response = string.Empty;
            if (usuario != null)
            {
                var auxUsuario = await AuthenticateUser(usuario);
                if (auxUsuario != null)
                    response = GenerarToken(auxUsuario);
            }
            return response;
        }

        public async Task<List<Chiste>> GetMisChistes(string email)
        {
            var auxUsuario = await _context.Usuarios.Include(c => c.ChistesUsuario).FirstOrDefaultAsync(u => u.Email == email);
            return auxUsuario.ChistesUsuario.ToList();
        }

        private async Task<Usuario> AuthenticateUser(UsuarioLoginDto usuario)
        {
            var auxUsuario = await _context.Usuarios.FindAsync(usuario.Email);

            if (auxUsuario != null)
            {
                byte[] salt = Convert.FromBase64String(auxUsuario.Salt);
                string hash = HashPassword(usuario.Password, salt);
                if (hash != auxUsuario.Password)
                    auxUsuario = null;
            }
            return auxUsuario;
        }

        private string HashPassword(string pass, byte[] salt)
        {
            // derive a 256-bit subkey (use HMACSHA256 with 100,000 iterations)
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: pass!,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));
            return hashed;
        }


        private string GenerarToken(Usuario usuario)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,usuario.Email)
            };
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"],
                expires: DateTime.Now.AddMinutes(2),
                claims: claims,
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
