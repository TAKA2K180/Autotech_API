using System.Net.NetworkInformation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using MovieRentalAPI.Main.Data.Contracts;

namespace MovieRentalAPI.Main.Data
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        private readonly DbContextOptions<ApplicationDbContext> _options;
        private readonly IConfiguration _configuration;
        private const string CONSTRING = "Data Source=.\\SQLEXPRESS;Database=dbo.MovieRental;Integrated Security=false;User ID=sa;Password=,rhsm098;Encrypt=false";

        public ApplicationDbContextFactory()
        {
            
        }
        public ApplicationDbContextFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public ApplicationDbContext CreateDbContext(string[] args = null)
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>();
            options.UseSqlServer(CONSTRING);
            return new ApplicationDbContext(options.Options,_configuration);
        }
    }
}
