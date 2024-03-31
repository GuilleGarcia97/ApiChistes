using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApiChistes.Models
{
    public class Chiste
    {
        public Chiste() { }
        public Chiste(string _texto, string _email)
        {
            Texto = _texto;
            Email = _email;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Texto { get; set; }

        [ForeignKey("Usuario")]
        public string Email { get; set; }

        [JsonIgnore]
        public Usuario? Usuario { get; set; } = null;

        
    }
  
}
