using ICI.ProvaCandidato.Dados;
using ICI.ProvaCandidato.Web.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ICI.ProvaCandidato.Web
{
    public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			var server = Configuration["DatabaseServer"] ?? "mssql-server";
			var port = Configuration["DatabasePort"] ?? "1433";
			var user = Configuration["DatabaseUser"] ?? "sa";
			var password = Configuration["DatabasePassword"] ?? "Docker2024";
			var database = Configuration["DatabaseName"] ?? "icidb";

			string connectionString = $"Server={server},{port};Initial Catalog={database};User ID={user};Password={password}";

			services.AddDbContext<ApplicationDbContext>(options =>
			{
                options.UseSqlServer(connectionString);
            });

			services.AddControllersWithViews();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			DatabaseService.Initialize(app);

			app.UseDeveloperExceptionPage();

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
									name: "default",
									pattern: "{controller=Home}/{action=Index}/{id?}");
			});
		}
	}
}
