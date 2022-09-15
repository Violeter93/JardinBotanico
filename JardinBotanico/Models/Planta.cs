using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JardinBotanico.Models
{
    [Table("Plantas")]
    public class Planta
    {
        [Key]
        public long? Id { get; set; }

        [DisplayName("Nombre Científico")]
        public string? NombreCientifico { get; set; }

        [DisplayName("Nombre Común")]
        public string? NombreComun { get; set; }

        public long? JardineroId { get; set; }

        public Jardinero? Jardinero { get; set; }
    }
}
