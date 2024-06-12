using ICI.ProvaCandidato.Negocio;
using Microsoft.EntityFrameworkCore;

namespace ICI.ProvaCandidato.Dados
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :
            base(options)
        { }

        public DbSet<Tag> Tags { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
