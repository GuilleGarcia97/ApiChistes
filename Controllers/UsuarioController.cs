using ApiChistes.Services.ChisteService;
using ApiChistes.Services.UsuarioService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;
using ApiChistes.Models.DTO;

namespace ApiChistes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        public readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }



        [AllowAnonymous]
        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> Login(UsuarioLoginDto usuario)
        {
            var token = await _usuarioService.LoginUsuario(usuario);

            if (string.IsNullOrEmpty(token))
                return Unauthorized();

            return Ok(new { token = token });
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAllUsuarios()
        {
            return Ok(await _usuarioService.GetAllUsuarios());
        }

        [AllowAnonymous]
        [Route("signin")]
        [HttpPost]
        public async Task<IActionResult> RegistrarUsuario(UsuarioRegistrarDto pUsuario)
        {
            return Ok(await _usuarioService.RegistrarUsuario(pUsuario));
        }
        [Authorize]
        [Route("misChistes")]
        [HttpGet]
        public async Task<IActionResult> GetMisChistes()
        {
            return Ok(await _usuarioService.GetMisChistes(User?.Identity?.Name));
        }
        [Route("{email}")]
        [HttpGet]
        public async Task<IActionResult> GetChistesEmail(string email)
        {
            return Ok(await _usuarioService.GetMisChistes(email));
        }


    }
}
