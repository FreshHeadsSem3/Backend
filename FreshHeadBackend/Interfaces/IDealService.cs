using FreshHeadBackend.Models;

namespace FreshHeadBackend.Interfaces
{
    public interface IDealService
    {
        List<DealModel> GetAllDeals();
        DealModel GetDealByID(Guid dealID);
        List<DealModel> GetDealByCategory(Guid categoryID);
        List<DealModel> GetDealByTitle(string title);
        List<DealModel> GetDealByCompanyName(string companyName);
        DealModel CreateDeal(CreateDealModel deal);
        bool ClaimDeal(ClaimDealModel claimDeal);
    }
}
