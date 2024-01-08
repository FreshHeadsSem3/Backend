using FreshHeadBackend.Business;
using FreshHeadBackend.Interfaces;
using FreshHeadBackend.Models;

namespace FreshHeadBackend.Logic
{
    public class DealCategoryService : IDealCategoryService
    {
        private readonly IDealCategoryRepository dealCategoryRepository;
        public DealCategoryService(IDealCategoryRepository dealCategoryRepository)
        {
            this.dealCategoryRepository = dealCategoryRepository;
        }
        public List<DealCategoryModel> GetAllDealCategories()
        {

            List<DealCategory> dealCategories = dealCategoryRepository.GetAllDealCategories();
            List<DealCategoryModel> dealCategoryModels = new List<DealCategoryModel>();
            foreach (DealCategory dealCategory in dealCategories)
            {
                dealCategoryModels.Add(new DealCategoryModel(dealCategory.ID, dealCategory.Name));
            }
            return dealCategoryModels;
           
        }

       
    }
}
