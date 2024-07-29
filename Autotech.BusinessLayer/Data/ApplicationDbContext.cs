using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Autotech.Core.Models;

namespace Autotech.BusinessLayer.Data
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
        public DbSet<Locations> Locations { get; set; }
        public DbSet<Items> Items { get; set; }
        public DbSet<ItemDetails> ItemDetails { get; set; }
        public DbSet<Agents> Agents { get; set; }
        public DbSet<Sales> Sales { get; set; }
        public DbSet<InvoicePayments> Invoices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Accounts>()
                .ToTable("Accounts");
            modelBuilder.Entity<Locations>()
                .ToTable("Locations");
            modelBuilder.Entity<Items>()
                .ToTable("Items");
            modelBuilder.Entity<ItemDetails>()
                .ToTable("ItemDetails");
            modelBuilder.Entity<Agents>()
                .ToTable("Agents");
            modelBuilder.Entity<Sales>()
                .ToTable("Sales");
            modelBuilder.Entity<InvoicePayments>()
                .ToTable("Invoices");

            modelBuilder.Entity<Accounts>()
            .HasKey(b => b.Id);

            modelBuilder.Entity<Locations>()
                .HasKey(l => l.Id);
            modelBuilder.Entity<Items>()
                .HasKey(l => l.Id);

            modelBuilder.Entity<Accounts>()
                .HasOne(a => a.AccountDetails)
                .WithOne(ad => ad.Accounts)
                .HasForeignKey<AccountDetails>(ad => ad.Id);

            // Configuring the one-to-many relationship between Location and Sales
            modelBuilder.Entity<Sales>()
                .HasOne(s => s.Location)
                .WithMany(l => l.Sales)
                .HasForeignKey(s => s.LocationId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configuring the one-to-many relationship between Location and Agents
            modelBuilder.Entity<Agents>()
                .HasOne(a => a.Location)
                .WithMany(l => l.Agents)
                .HasForeignKey(a => a.LocationId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configuring the one-to-many relationship between Location and Accounts
            modelBuilder.Entity<Accounts>()
                .HasOne(a => a.Location)
                .WithMany(l => l.Accounts)
                .HasForeignKey(a => a.LocationId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
