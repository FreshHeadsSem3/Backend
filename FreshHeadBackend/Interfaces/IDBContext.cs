using FreshHeadBackend.Business;
using Microsoft.EntityFrameworkCore;

namespace FreshHeadBackend.Interfaces
{
    public interface IDBContext : IDisposable
    {
        DbSet<Company> Companies { get; set; }
        DbSet<Deal> Deals { get; set; }
        DbSet<CompanyImage> CompanyImages { get; set; }
        DbSet<DealImage> DealImages { get; set; }
        DbSet<DealCategory> DealCategories { get; set; }
        DbSet<DealParticipants> DealParticipants { get; set; }

        int SaveChanges();
        void InitializeDatabase();

    }
}
