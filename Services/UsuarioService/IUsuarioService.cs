using ApiChistes.Data;
using ApiChistes.Models;
using ApiChistes.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiChistes.Services.UsuarioService
{
    public interface IUsuarioService
    {
        //Usuario AuthenticateUser(Usuario usuario);
        //string GenerarToken(Usuario usuario);
        //string Login(Usuario usuario);
        Task<List<Usuario>> GetAllUsuarios();
        Task<Usuario> RegistrarUsuario(UsuarioRegistrarDto usuario);
        Task<string> LoginUsuario(UsuarioLoginDto usuario);
        Task<List<Chiste>> GetMisChistes(string email);
    }
}
