using FreshHeadBackend.Business;
using FreshHeadBackend.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace FreshHeadBackend.Repositories
{
    public class CompanyRepository : DBContext, ICompanyRepository
    {
        public CompanyRepository(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
        public Company GetCompany(Guid companyID)
        {
            Company company = Companies.Find(companyID);
            if (company == null) {
                throw new Exception("Company not found");
            }
            return company;
        }
    }
}
