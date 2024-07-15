using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Autotech.Core.Models;

namespace Autotech.Main.Data
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public ApplicationDbContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        public DbSet<Accounts> Accounts { get; set; }
        public DbSet<AccountDetails> AccountDetails { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Accounts>()
                .ToTable("Accounts");

            modelBuilder.Entity<Product>()
                .ToTable("Products");

            modelBuilder.Entity<Accounts>()
            .HasKey(b => b.Id);

            modelBuilder.Entity<Accounts>()
                .HasOne(a => a.AccountDetails)
                .WithOne(ad => ad.Accounts)
                .HasForeignKey<AccountDetails>(ad => ad.Id);

        }
    }
}
