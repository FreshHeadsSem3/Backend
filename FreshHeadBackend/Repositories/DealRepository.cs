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
            return Deals.Include(deal => deal.DealCategory).Include(deal => deal.Participants).ToList();
        }

        public List<Deal> GetDealByCategory(string category)
        {
            return Deals.Include(deal => deal.DealCategory).Include(deal => deal.Participants).Where(x => x.DealCategory.Name == category).ToList();
            
        }
        public List<Deal> GetDealByTitle(string title)
        {
            return Deals.Include(deal => deal.DealCategory).Include(deal => deal.Participants).Where(x => x.Title.Contains(title)).ToList();
        }

        
        public Deal GetDealById(Guid dealID)
        {
            Deal deal = Deals
                .Include(deal => deal.DealCategory) // Include the category information
                .Include(deal => deal.Participants)
                .Where(x => x.ID == dealID)
                .FirstOrDefault();

            if (deal != null)
            {
                deal.Images = GetDealImageByDealID(dealID);
            }

            return deal;
        }

        public Deal CreateDeal(Deal dealEntity)
        {
            Deals.Add(dealEntity);
            Save();
            return dealEntity;
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

        public DealParticipants CreateDealParticipant(DealParticipants participantEntity)
        {
            DealParticipants.Add(participantEntity);
            Save();
            return participantEntity;
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
