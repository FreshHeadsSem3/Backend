using FreshHeadBackend.Business;
using FreshHeadBackend.Models;
using Microsoft.AspNetCore.Mvc;

namespace FreshHeadBackend.Interfaces
{
    public interface IDealService
    {
        List<DealModel> GetAllDeals();
        Deal CreateDeal(DealModel deal);
    }
}
