using System.Net.NetworkInformation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Autotech.BusinessLayer.Data.Contracts;
using Autotech.BusinessLayer.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Autotech.BusinessLayer.Data
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        private readonly DbContextOptions<ApplicationDbContext> _options;
        private readonly IConfiguration _configuration;

        public ApplicationDbContextFactory()
        {
            
        }
        public ApplicationDbContextFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public ApplicationDbContext CreateDbContext(string[] args = null)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

            // Build options
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly("Autotech.BusinessLayer"));


            return new ApplicationDbContext(optionsBuilder.Options, configuration);
        }
        public void ConfigureServices(IServiceCollection services)
        {
            
        }
    }
}
