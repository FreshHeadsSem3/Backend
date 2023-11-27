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
            if (company == null)
            {
                throw new Exception("Company not found");
            }
            return company;
        }

        public Company GetCompanyByID(Guid companyID)
        {
            Company company = Companies.Where(x => x.ID == companyID).FirstOrDefault();
            company.Images = GetCompanyImageByCompanyID(companyID);
            if (company == null)
            {
                throw new Exception("Company not found");
            }
            return company;
        }

        public Company GetCompanyByDealID(Guid dealID)
        {
            return Companies.Where(x => x.Deals.Any(d => d.ID == dealID)).FirstOrDefault();
        }

        public Company CreateCompany(Company companyEntity)
        {
            Companies.Add(companyEntity);
            Save();
            return companyEntity;
        }

        public CompanyImage CreateCompanyImage(CompanyImage imageEntity)
        {
            CompanyImages.Add(imageEntity);
            Save();
            return imageEntity;
        }

        public List<CompanyImage> GetCompanyImageByCompanyID(Guid companyID)
        {
            return CompanyImages.Where(x => x.CompanyID == companyID).ToList();
        }

        public List<Company> GetCompanies()
        {
            return Companies.ToList();
        }

        public void Save()
        {
            SaveChanges(true);
        }

        public void Save(bool acceptChangesOnSuccess)
        {
            SaveChanges(acceptChangesOnSuccess);
        }
    }
}
