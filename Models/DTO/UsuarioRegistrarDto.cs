using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiChistes.Models.DTO
{
    public class UsuarioRegistrarDto
    {
        [Key, Required]
        public string Email { get; set; }
        public string NombreUsuario { get; set; }
        public string Password { get; set; }

    }
}
