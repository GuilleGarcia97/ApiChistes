using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiChistes.Models.DTO
{
    public class UsuarioLoginDto
    {
        [Key, Required]
        public string Email { get; set; }
        public string Password { get; set; }

    }
}
