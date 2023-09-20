using FreshHeadBackend.Business;
using FreshHeadBackend.Interfaces;
using FreshHeadBackend.Models;

namespace FreshHeadBackend.Logic
{
    public class DealLogic : IDeal
    {
        public List<DealModel> GetAllDeals()
        {
            DealModel deal = new DealModel(1, "Test", "Dit is een test", new List<string>());
            List<DealModel> dealModels = new List<DealModel>();
            dealModels.Add(deal);

            return dealModels;
        }
    }
}
