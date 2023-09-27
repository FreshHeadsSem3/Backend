using FreshHeadBackend.Business;
using FreshHeadBackend.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace FreshHeadBackend.Repositories
{
    public class DealRepository : DBContext, IDealRepository
    {
        public DealRepository(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
        public Deal CreateDeal(Deal dealEntity)
        {
            EntityEntry entry = Add(dealEntity);
            if (entry.State != EntityState.Added)
            {
                 throw new Exception("Service already exists!");
            }
            Deal entity = entry.Entity as Deal;
            return entity;
        }

        public void Save()
        {
            SaveChanges(true);
        }

        public void Save(bool acceptChangesOnSuccess)
        {
            SaveChanges(acceptChangesOnSuccess);
        }
    }
}
