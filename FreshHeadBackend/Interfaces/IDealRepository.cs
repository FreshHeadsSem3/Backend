﻿using FreshHeadBackend.Business;

namespace FreshHeadBackend.Interfaces
{
    public interface IDealRepository
    {
        List<Deal> GetAllDeals();
        Deal GetDealById(Guid dealID);
        Deal CreateDeal(Deal dealEntity);
        DealImage CreateDealImage(DealImage imageEntity);
        List<DealImage> GetDealImageByDealID(Guid dealID);
        void Save();
        void Save(bool acceptChangesOnSuccess);
    }
}