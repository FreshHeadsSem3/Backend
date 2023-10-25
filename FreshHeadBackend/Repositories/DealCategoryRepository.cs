using FreshHeadBackend.Business;
using FreshHeadBackend.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FreshHeadBackend.Repositories
{
    public class DealCategoryRepository : DBContext, IDealCategoryRepository
    {
        public DealCategoryRepository(DbContextOptions context) : base(context)
        {
        }
        public List<DealCategory> GetAllDealCategories()
        {
            return DealCategories.ToList();
        }
        
        

    }
}
