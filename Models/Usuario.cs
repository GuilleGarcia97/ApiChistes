using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApiChistes.Models
{
    public class Usuario
    {
        public Usuario() { }
        public Usuario(string _email,string _nombre,string _pass,string _salt) 
        { 
            Email = _email;
            NombreUsuario = _nombre;
            Password = _pass;
            Salt = _salt;
        }
        [Key,Required]
        public string Email { get; set; }
        public string NombreUsuario { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }

        [JsonIgnore]
        public ICollection<Chiste> ChistesUsuario { get; set; }
    }
}
