using FreshHeadBackend.Business;

namespace FreshHeadBackend.Interfaces
{
    public interface IDealCategoryRepository
    {
        List<DealCategory> GetAllDealCategories();
    }
}
