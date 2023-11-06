﻿using FreshHeadBackend.Business;
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
            return Deals.Include(deal => deal.DealCategory).ToList();
        }

        public List<Deal> GetDealByCategory(string category)
        {
           // DealCategory dealCategory = DealCategories.Where(x => x.Name == category).FirstOrDefault();
            //return Deals.Where(x => x.DealCategory.ID == dealCategory.ID).ToList();
            return Deals.Include(deal => deal.DealCategory).Where(x => x.DealCategory.Name == category).ToList();
            
        }

        public Deal GetDealById(Guid dealID)
        {
            Deal deal = Deals
                .Include(deal => deal.DealCategory) // Include the category information
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
