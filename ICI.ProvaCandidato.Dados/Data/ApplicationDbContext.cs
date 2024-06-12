using Microsoft.EntityFrameworkCore;

namespace ICI.ProvaCandidato.Dados.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :
            base(options) { }

        public DbSet<Tag> Tags { get; set; }
    }
}
