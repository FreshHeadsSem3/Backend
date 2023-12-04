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

        public List<Deal> GetAllDeals()
        {
            List<Deal> deals = Deals.Include(deal => deal.DealCategory).ToList();
            if (deals == null)
            {
                return null;
            }
            else
            {
                return deals;
            }

            
        }

        public List<Deal> GetDealByCategory(Guid categoryID)
        {
            return Deals.Include(deal => deal.DealCategory).Where(x => x.DealCategory.ID == categoryID).ToList();
            
        }
        public List<Deal> GetDealByTitle(string title)
        {
            List<Deal> deals = Deals.Include(deal => deal.DealCategory).Where(x => x.Title.Contains(title)).ToList();

            if (deals != null)
            {
                return deals;
            }
            else
            {
                return null;
            }
        }
        public List<Deal> GetDealByCompanyName(string companyName)
        {
            List<Deal> deals = Deals.Include(deal => deal.DealCategory).Where(x => x.Company.Title.Contains(companyName)).ToList();

            if (deals != null)
            {
                return deals;
            }
            else
            {
                return null;
            }
        }

        
        public Deal GetDealById(Guid dealID)
        {

            Deal deal = Deals.Include(deal => deal.DealCategory).Where(x => x.ID == dealID).FirstOrDefault();

            if (deal != null)
            {
                deal.Images = GetDealImageByDealID(dealID);
                return deal;
            }
            else
            {
                return null;
            }
        }

        public Deal CreateDeal(Deal dealEntity)
        {
            if (dealEntity == null)
            {
                return null;
            }
            else
            {
                Deals.Add(dealEntity);
                Save();
                return dealEntity;
            }
            

           
        }

        public DealImage CreateDealImage(DealImage imageEntity)
        {
            DealImages.Add(imageEntity);
            Save();
            return imageEntity;
        }

        public List<DealImage> GetDealImageByDealID(Guid dealID)
        {
            return DealImages.Where(x => x.DealID == dealID).ToList();
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
