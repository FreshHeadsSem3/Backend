using FreshHeadBackend.Business;
using FreshHeadBackend.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq;

namespace FreshHeadBackend.Repositories
{
    public class DealRepository : DBContext, IDealRepository
    {
        private DateTime DateTime = new DateTime(2000, 1, 1);
        public DealRepository(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        public List<Deal> GetAllDealsForCompany()
        {
            List<Deal> deals = Deals.Include(deal => deal.DealCategory).Include(deal => deal.Participants).ToList();
            if (deals == null)
            {
                return null;
            }
            else
            {
                return deals;
            }

            
        }


        public List<Deal> GetAllDeals()
        {
            

            List<Deal> deals = Deals
                .Where(x => x.ActiveTill < DateTime || x.ActiveTill > DateTime.Now).Where(x => x.MaxParticipants == 0 || x.MaxParticipants > x.Participants.Count)
                 .Include(deal => deal.DealCategory)
                 .ToList();
            

            if (deals.Count == 0)
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
            return Deals
                .Where(x => x.ActiveTill < DateTime || x.ActiveTill > DateTime.Now)
                .Where(x => x.MaxParticipants == 0 || x.MaxParticipants > x.Participants.Count)
                .Include(deal => deal.DealCategory).Include(deal => deal.Participants).Where(x => x.DealCategory.ID == categoryID).ToList();
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
            List<Deal> deals = Deals
                .Where(x => x.ActiveTill < DateTime || x.ActiveTill > DateTime.Now)
                .Where(x => x.MaxParticipants == 0 || x.MaxParticipants > x.Participants.Count).Include(deal => deal.DealCategory)
                .Where(x => x.Company.Title.Contains(companyName)).ToList();

            if (deals != null)
            {
                return deals;
            }
            else
            {
                return null;
            }
        }

        public Deal UpdateDeal(Deal deal, List<string> images)
        {
            Deal SavedDeal = Deals.Where(x => x.ID == deal.ID).Include(deal => deal.Images).Include(deal => deal.DealCategory).FirstOrDefault();
            SavedDeal.Images.First().ImageUrl = images[0];
            SavedDeal.CategoryID = deal.CategoryID;
            SavedDeal.Title = deal.Title;
            SavedDeal.Description = deal.Description;
            SavedDeal.Location = deal.Location;
            SavedDeal.ActiveTill = deal.ActiveTill;
            SavedDeal.EventDate = deal.EventDate;
            SavedDeal.MaxParticipants = deal.MaxParticipants;
            Save();
            return SavedDeal;
        }

        public List<Deal> GetDealByCompany(Guid companyID)
        {
            return Deals
                .Include(deal => deal.DealCategory)
                .Where(x => x.CompanyID == companyID).ToList();
        }

        public Deal GetDealById(Guid dealID)
        {
            Deal deal = Deals
                .Where(x => x.ActiveTill < DateTime || x.ActiveTill > DateTime.Now)
                .Where(x => x.MaxParticipants == 0 || x.MaxParticipants > x.Participants.Count)
                .Include(deal => deal.DealCategory) 
                .Include(deal => deal.Participants)
                .Where(x => x.ID == dealID)
                .FirstOrDefault();
            if(deal == null) {
                throw new Exception("DealNotFound");
            }
            if (deal != null)
            {
                deal.Images = GetDealImageByDealID(dealID);
                return deal;
            }
            else
            {
                return null;
            }
            return deal;
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

        public DealParticipants CreateDealParticipant(DealParticipants participantEntity)
        {
            DealParticipants.Add(participantEntity);
            Save();
            return participantEntity;
        }

        public bool RemoveDealParticipant(Guid dealID, string usermail)
        {
            DealParticipants participantToRemove = DealParticipants
                .Where(x => x.DealID == dealID && x.Email == usermail)
                .FirstOrDefault();
            if (participantToRemove != null) {
                DealParticipants.Remove(participantToRemove);
                Save();
                return true; // Return true if removal was successful
            }
            return false; // Return false if no matching participant was found
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
