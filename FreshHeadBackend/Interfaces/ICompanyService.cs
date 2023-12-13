using FreshHeadBackend.Models;
using FreshHeadBackend.Business;

namespace FreshHeadBackend.Interfaces
{
    public interface ICompanyService
    {
        List<CompanyModel> GetAllCompanies();
        CompanyModel GetCompanyByID(Guid companyID);
        List<CompanyModel> GetCompanyByTitle(string title);
        CompanyModel CreateCompany(CreateCompanyModel company);
        CompanyModel GetCompanyByDealID(Guid dealID);
        List<CompanyModel> GetCompanies();
        Company GetCompanyByLoginData(LoginModel model);
    }
}
