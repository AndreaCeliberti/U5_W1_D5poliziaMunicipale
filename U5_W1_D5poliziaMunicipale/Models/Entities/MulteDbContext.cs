using Microsoft.EntityFrameworkCore;

namespace U5_W1_D5poliziaMunicipale.Models.Entities
{
    public class MulteDbContext : DbContext
    {
        public MulteDbContext(DbContextOptions <MulteDbContext> options) : base(options)
        {
        
        }

        public DbSet<Anagrafica> Anagrafiche { get; set; }
        public DbSet<Verbale> Verbali { get; set; }
        public DbSet<Violazione> Violazioni { get; set; }

    }
}
