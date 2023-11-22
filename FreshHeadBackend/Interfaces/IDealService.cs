using FreshHeadBackend.Models;

namespace FreshHeadBackend.Interfaces
{
    public interface IDealService
    {
        List<DealModel> GetAllDeals();
        DealModel GetDealByID(Guid dealID);
        List<DealModel> GetDealByCategory(string category);
        List<DealModel> GetDealByTitle(string title);
        DealModel CreateDeal(CreateDealModel deal);
        bool ClaimDeal(ClaimDealModel claimDeal);
        bool CancleDeal(CancelDealModel cancleDeal);
    }
}
