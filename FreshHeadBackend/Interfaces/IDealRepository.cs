﻿using FreshHeadBackend.Business;

namespace FreshHeadBackend.Interfaces
{
    public interface IDealRepository
    {
        List<Deal> GetAllDeals();
        List<Deal> GetDealByCategory(Guid categoryID);
        List<Deal> GetDealByTitle(string title);
        List<Deal> GetDealByCompany(Guid companyID);
        List<Deal> GetDealByCompanyName(string companyName);
        Deal GetDealById(Guid dealID);
        Deal CreateDeal(Deal dealEntity);
        DealImage CreateDealImage(DealImage imageEntity);
        List<DealImage> GetDealImageByDealID(Guid dealID);
        DealParticipants CreateDealParticipant(DealParticipants participantEntity);
        bool RemoveDealParticipant(Guid dealID, string usermail);
        void Save();
        void Save(bool acceptChangesOnSuccess);
    }
}