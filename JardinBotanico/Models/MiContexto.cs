using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace JardinBotanico.Models
{
    public class MiContexto : DbContext
    {
        public MiContexto(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<Planta> Plantas { get; set; }
        public DbSet<Jardinero> Jardineros { get; set; }
        public DbSet<Centro> Centros { get; set; }
    }
}
