using FreshHeadBackend.Business;
using FreshHeadBackend.Interfaces;
using FreshHeadBackend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace FreshHeadBackend.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private DBContext _dbContext;
        public CompanyRepository(DBContext dbContext)
        {
            _dbContext = dbContext;
        }
        

        public List<Company> GetAllCompanies()
        {
            return _dbContext.Companies.ToList();
        }

        public Company GetCompany(Guid companyID)
        {
            Company company = _dbContext.Companies.Find(companyID);
            if (company == null)
            {
                throw new Exception("Company not found");
            }
            return company;
        }

        public Company GetCompanyByID(Guid companyID)
        {
            Company company = _dbContext.Companies.Where(x => x.ID == companyID).FirstOrDefault();
            company.Images = GetCompanyImageByCompanyID(companyID);
            if (company == null)
            {
                throw new Exception("Company not found");
            }
            return company;
        }

        public List<Company> GetCompanyByTitle(string title)
        {
            List<Company> companies = _dbContext.Companies.Where(x => x.Title.Contains(title)).ToList();

            if (companies != null)
            {
                return companies;
            }
            else
            {
                return null;
            }
        }

        public Company GetCompanyByLoginData(LoginModel model)
        {
            Company company = null;
            try
            {
                company = _dbContext.Companies.FirstOrDefault(x => x.UserEmail == model.UserEmail && x.UserPassword == model.UserPassword);
                if (company == null)
                {
                    Console.WriteLine("Gebruiker niet gevonden");
                }
                else
                {
                    return company;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Er is een fout opgetreden: {ex.Message}");
            }
            return company;
        }


        public Company GetCompanyByDealID(Guid dealID)

        {

            return _dbContext.Companies.Where(x => x.Deals.Any(d => d.ID == dealID)).FirstOrDefault();

        }

        public Company CreateCompany(Company companyEntity)
        {
            _dbContext.Companies.Add(companyEntity);
            Save();
            return companyEntity;
        }

        public CompanyImage CreateCompanyImage(CompanyImage imageEntity)
        {
            _dbContext.CompanyImages.Add(imageEntity);
            Save();
            return imageEntity;
        }

        public List<CompanyImage> GetCompanyImageByCompanyID(Guid companyID)
        {
            return _dbContext.CompanyImages.Where(x => x.CompanyID == companyID).ToList();
        }

        public List<Company> GetCompanies()
        {
            return _dbContext.Companies.ToList();
        }

        public void Save()
        {
            _dbContext.SaveChanges(true);
        }

        public void Save(bool acceptChangesOnSuccess)
        {
            _dbContext.SaveChanges(acceptChangesOnSuccess);
        }
    }
}
