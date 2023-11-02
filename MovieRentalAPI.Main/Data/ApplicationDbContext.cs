using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MovieRental.Core.Models;

namespace MovieRentalAPI.Main.Data
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IConfiguration _configuration;
        private const string CONSTRING = "Data Source=.\\SQLEXPRESS;Database=dbo.MovieRental;Integrated Security=false;User ID=sa;Password=,rhsm098;Encrypt=false";
        public ApplicationDbContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration; 
        }

        public DbSet<Costumer> Costumers { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieTransaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(CONSTRING);
            }
        }
    }
}
