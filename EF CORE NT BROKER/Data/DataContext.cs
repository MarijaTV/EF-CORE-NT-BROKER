using EF_CORE_NT_BROKER.Models;
using Microsoft.EntityFrameworkCore;

namespace EF_CORE_NT_BROKER.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Broker> Brokers { get; set; }
        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Company> CompanyBrokers { get; set; }
        //public DbSet<CompanyApartments> CompanyApartments { get; set; }
        public DataContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>()
                .Property(b => b.City)
                .HasPrecision(20, 2);

            //modelBuilder.Entity<Company>()
            //    .HasMany(s => s.Brokers)
            //    .WithOne(si => si.Companies)
            //    .HasForeignKey(si => si.Id);
        }
    }
}
