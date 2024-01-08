using FreshHeadBackend.Business;
using FreshHeadBackend.Models;

namespace FreshHeadBackend.Interfaces
{
    public interface IDealService
    {
        List<DealModel> GetAllDeals();
        DealModel GetDealByID(Guid dealID);
        List<DealModel> GetDealByCategory(Guid categoryID);
        List<DealModel> GetDealByTitle(string title);
        List<DealModel> GetDealByCompany(Guid companyID);
        List<DealModel> GetDealByCompanyOnlyValid(Guid companyID);
        List<DealModel> GetDealByCompanyName(string companyName);
        DealModel UpdateDeal(DealModel deal);
        DealModel CreateDeal(CreateDealModel deal);
        bool ClaimDeal(ClaimDealModel claimDeal);
        bool CancleDeal(CancelDealModel cancleDeal);
    }
}
