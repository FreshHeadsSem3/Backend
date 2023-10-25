using FreshHeadBackend.Business;
using FreshHeadBackend.Interfaces;

namespace FreshHeadBackend.Logic
{
    public class DealCategoryService
    {
        private readonly IDealCategoryRepository dealCategoryRepository;
        public DealCategoryService(IDealCategoryRepository dealCategoryRepository)
        {
            this.dealCategoryRepository = dealCategoryRepository;
        }
        public List<DealCategory> GetAllDealCategories()
        {
            return dealCategoryRepository.GetAllDealCategories();
        }
    }
}
