using ICI.ProvaCandidato.Dados;
using ICI.ProvaCandidato.Negocio;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ICI.ProvaCandidato.Web.Services
{
    public static class DatabaseService
    {
        public static void Initialize(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                serviceScope
                    .ServiceProvider
                    .GetService<ApplicationDbContext>()
                    .Database
                    .Migrate();
            }
        }

        public static void Seed(ApplicationDbContext context)
        {
            context.Users.AddRange(
                new User { Name = "Admin", Email = "contact@admin.com", Password = "admin123" }
            );

            context.SaveChanges();
        }
    }
}
