using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JardinBotanico.Models
{
    [Table("Jardineros")]
    public class Jardinero
    {
        [Key]
        public long? Id { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }

        [DisplayName("Centro")]
        public long? CentroId { get; set; }
        public Centro? Centro { get; set; }


        public virtual ICollection<Planta>? Plantas { get; set; }
    }
}
