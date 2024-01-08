using FreshHeadBackend.Business;
using FreshHeadBackend.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq;

namespace FreshHeadBackend.Repositories
{
    public class DealRepository :  IDealRepository
    {
        private DateTime DateTime = new DateTime(2000, 1, 1);
        private IDBContext _dbContext;
        public DealRepository( IDBContext dbContext )
        {
           
            _dbContext = dbContext;
        }

        public List<Deal> GetAllDealsForCompany()
        {
            List<Deal> deals = _dbContext.Deals.Include(deal => deal.DealCategory).Include(deal => deal.Participants).ToList();
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
            List<Deal> deals = _dbContext.Deals
                .Where(x => x.ActiveTill < DateTime || x.ActiveTill > DateTime.Now).Where(x => x.MaxParticipants == 0 || x.MaxParticipants > x.Participants.Count)
                 .ToList();
            return deals;
        }

        public List<Deal> GetDealByCategory(Guid categoryID)
        {
            return _dbContext.Deals
                .Where(x => x.ActiveTill < DateTime || x.ActiveTill > DateTime.Now)
                .Where(x => x.MaxParticipants == 0 || x.MaxParticipants > x.Participants.Count)
                .Include(deal => deal.DealCategory).Include(deal => deal.Participants).Where(x => x.DealCategory.ID == categoryID).ToList();
        }

        public List<Deal> GetDealByTitle(string title)
        {
            List<Deal> deals = _dbContext.Deals.Include(deal => deal.DealCategory).Where(x => x.Title.Contains(title)).ToList();

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
            List<Deal> deals = _dbContext.Deals
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
            Deal SavedDeal = _dbContext.Deals.Where(x => x.ID == deal.ID).Include(deal => deal.Images).Include(deal => deal.DealCategory).FirstOrDefault();
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
            return _dbContext.Deals
                .Include(deal => deal.DealCategory)
                .Include(deal => deal.Participants)
                .Include(deal => deal.Images)
                .Where(x => x.CompanyID == companyID).ToList();
        }

        public List<Deal> GetDealsByCompanyOnlyValid(Guid companyID)
        {
            return _dbContext.Deals
                .Where(x => x.ActiveTill < DateTime || x.ActiveTill > DateTime.Now)
                .Where(x => x.MaxParticipants == 0 || x.MaxParticipants > x.Participants.Count)
                .Include(deal => deal.DealCategory)
                .Include(deal => deal.Participants)
                .Include(deal => deal.Images)
                .Where(x => x.CompanyID == companyID).ToList();
        }

        public Deal GetDealById(Guid dealID)
        {
            Deal deal = _dbContext.Deals
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
                _dbContext.Deals.Add(dealEntity);
                Save();
                return dealEntity;
            }
            

           
        }

        public DealImage CreateDealImage(DealImage imageEntity)
        {
            _dbContext.DealImages.Add(imageEntity);
            Save();
            return imageEntity;
        }

        public List<DealImage> GetDealImageByDealID(Guid dealID)
        {
            return _dbContext.DealImages.Where(x => x.DealID == dealID).ToList();
        }

        public DealParticipants CreateDealParticipant(DealParticipants participantEntity)
        {
            _dbContext.DealParticipants.Add(participantEntity);
            Save();
            return participantEntity;
        }

        public bool RemoveDealParticipant(Guid dealID, string usermail)
        {
            DealParticipants participantToRemove = _dbContext.DealParticipants
                .Where(x => x.DealID == dealID && x.Email == usermail)
                .FirstOrDefault();
            if (participantToRemove != null) {
                _dbContext.DealParticipants.Remove(participantToRemove);
                Save();
                return true; // Return true if removal was successful
            }
            return false; // Return false if no matching participant was found
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public List<string> GetParticipantsEmailByDeal(Guid dealID)
        {
            return _dbContext.DealParticipants
                .Where(x => x.DealID == dealID)
                .Select(p => p.Email)
                .ToList();
        }
    }
}
