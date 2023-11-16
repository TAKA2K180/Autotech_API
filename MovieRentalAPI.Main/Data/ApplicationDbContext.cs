using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MovieRental.Core.Models;

namespace MovieRentalAPI.Main.Data
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public ApplicationDbContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieTransaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Movie>()
            .ToTable("Movies"); 

            modelBuilder.Entity<Customer>()
                .ToTable("Customers");

            modelBuilder.Entity<MovieTransaction>()
                .ToTable("Transactions");

            modelBuilder.Entity<MovieTransaction>()
                .HasKey(mt => mt.Id);

            modelBuilder.Entity<Movie>()
                .HasKey(m => m.Id);

            modelBuilder.Entity<Customer>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<MovieTransaction>()
                .HasOne(mt => mt.Movie)
                .WithMany(m => m.MovieTransactions)
                .HasForeignKey(mt => mt.MovieId);

            modelBuilder.Entity<MovieTransaction>()
                .HasOne(mt => mt.Customer)
                .WithMany(c => c.MovieTransactions)
                .HasForeignKey(mt => mt.CustomerId);
        }
    }
}
