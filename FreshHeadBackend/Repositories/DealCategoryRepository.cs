using FreshHeadBackend.Business;
using FreshHeadBackend.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FreshHeadBackend.Repositories
{
    public class DealCategoryRepository : IDealCategoryRepository
    {
        private DBContext _dbContext;
        public DealCategoryRepository(DBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<DealCategory> GetAllDealCategories()
        {
            return _dbContext.DealCategories.ToList();
        }
        
        

    }
}
