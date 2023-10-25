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
            return Deals.ToList();
        }

        public List<Deal> GetDealByCategory(string category)
        {
            //return Deals.Where(x => x.Category == category).ToList();
            return null;
        }

        public Deal GetDealById(Guid dealID)
        {
            Deal deal = Deals.Where(x => x.ID == dealID).FirstOrDefault();
            deal.Images = GetDealImageByDealID(dealID);
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
