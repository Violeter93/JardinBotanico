using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JardinBotanico.Models
{
    [Table("Centros")]
    public class Centro
    {
        [Key]
        public long? Id { get; set; }

        [DisplayName("Nombre Centro")]
        public string? NombreCentro { get; set; }
        public string? Direccion { get; set; }
        public string? Ciudad { get; set; }

        public virtual ICollection<Jardinero>? Jardineros { get; set; }
    }
}
