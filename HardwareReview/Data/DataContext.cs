using HardwareReview.Models;
using Microsoft.EntityFrameworkCore;

namespace HardwareReview.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Hardware> Hardwares { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Reviewer> Reviewers { get; set; }
        public DbSet<HardwareCategory> HardwareCategories { get; set; }
        public DbSet<HardwareCompany> HardwareCompanies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HardwareCategory>().HasKey(Hc => new {Hc.HardwareId, Hc.CategoryId });
            modelBuilder.Entity<HardwareCategory>().
                HasOne(H => H.Hardware).WithMany(HC => HC.HardwareCategories).HasForeignKey(H => H.HardwareId);
            modelBuilder.Entity<HardwareCategory>().
                HasOne(C => C.Category).WithMany(HC => HC.HardwareCategories).HasForeignKey(C => C.CategoryId);

            modelBuilder.Entity<HardwareCompany>().HasKey(Hc => new { Hc.HardwareId, Hc.CompanyId });
            modelBuilder.Entity<HardwareCompany>().
                HasOne(H => H.Hardware).WithMany(HC => HC.HardwareCompanies).HasForeignKey(H => H.HardwareId);
            modelBuilder.Entity<HardwareCompany>().
                HasOne(C => C.Company).WithMany(HC => HC.HardwareCompanies).HasForeignKey(C => C.CompanyId);
        }

    }
}
