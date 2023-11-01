using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace FreshHeadBackend.Business
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions options) : base(options)
        {

        }

        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Deal> Deals { get; set; }
        public virtual DbSet<CompanyImage> CompanyImages { get; set; }
        public virtual DbSet<DealImage> DealImages { get; set; }
        public virtual DbSet<DealCategory> DealCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Company>().Property(Companies => Companies.ID).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<Deal>().Property(Deals => Deals.ID).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<CompanyImage>().Property(CompanyImages => CompanyImages.ID).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<DealImage>().Property(DealImage => DealImage.ID).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<DealCategory>().Property(DealCategory => DealCategory.ID).HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<Deal>()
                .HasOne(d => d.Company)
                .WithMany(c => c.Deals)
                .HasForeignKey(d => d.CompanyID);
            modelBuilder.Entity<CompanyImage>()
                .HasOne(i => i.Company)
                .WithMany(c => c.Images)
                .HasForeignKey(i => i.CompanyID);
            modelBuilder.Entity<DealImage>()
                .HasOne(i => i.Deal)
                .WithMany(d => d.Images)
                .HasForeignKey(i => i.DealID);               
        }
    }
}
