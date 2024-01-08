using FreshHeadBackend.Business;
using FreshHeadBackend.Models;

namespace FreshHeadBackend.Interfaces
{
    public interface ICompanyRepository
    {
        List<Company> GetAllCompanies();
        Company GetCompany(Guid companyID);
        Company GetCompanyByID(Guid companyID);
        Company GetCompanyByDealID(Guid dealID);
        List<Company> GetCompanyByTitle(string Title);
        Company CreateCompany(Company companyEntity);
        List<Company> GetCompanies();
        CompanyImage CreateCompanyImage(CompanyImage imageEntity);
        List<CompanyImage> GetCompanyImageByCompanyID(Guid companyID);
        Company GetCompanyByLoginData(LoginModel model);
        void Save();
        void Save(bool acceptChangesOnSuccess);
    }
}
