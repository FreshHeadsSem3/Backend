using FreshHeadBackend.Models;

namespace FreshHeadBackend.Interfaces
{
    public interface IDeal
    {
        List<DealModel> GetAllDeals();
    }
}
