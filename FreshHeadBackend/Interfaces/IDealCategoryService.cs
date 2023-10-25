using FreshHeadBackend.Models;

namespace FreshHeadBackend.Interfaces
{
    public interface IDealCategoryService
    {
        List<DealCategoryModel> GetAllDealCategories();
    }
}
