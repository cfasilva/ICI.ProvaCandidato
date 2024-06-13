using ICI.ProvaCandidato.Negocio;
using Microsoft.EntityFrameworkCore;

namespace ICI.ProvaCandidato.Dados
{
    public class ApplicationDbContext : DbContext
    {
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<TagNews> TagNews { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TagNews>()
                .HasOne(tn => tn.Tag)
                .WithMany(t => t.TagNews)
                .HasForeignKey(tn => tn.TagId);

            modelBuilder.Entity<TagNews>()
                .HasOne(tn => tn.News)
                .WithMany(n => n.TagNews)
                .HasForeignKey(tn => tn.NewsId);
        }
    }
}
