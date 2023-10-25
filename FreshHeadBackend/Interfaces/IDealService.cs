using FreshHeadBackend.Models;

namespace FreshHeadBackend.Interfaces
{
    public interface IDealService
    {
        List<DealModel> GetAllDeals();
        DealModel GetDealByID(Guid dealID);
        List<DealModel> GetDealByCategory(string category);
        DealModel CreateDeal(CreateDealModel deal);
    }
}
