using FreshHeadBackend.Business;

namespace FreshHeadBackend.Interfaces
{
    public interface IDealRepository
    {
        List<Deal> GetAllDeals();
        List<Deal> GetDealByCategory(string category);
        List<Deal> GetDealByTitle(string title);
        Deal GetDealById(Guid dealID);
        Deal CreateDeal(Deal dealEntity);
        DealImage CreateDealImage(DealImage imageEntity);
        List<DealImage> GetDealImageByDealID(Guid dealID);
        DealParticipants CreateDealParticipant(DealParticipants participantEntity);
        void Save();
        void Save(bool acceptChangesOnSuccess);
    }
}