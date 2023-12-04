using FreshHeadBackend.Business;
using FreshHeadBackend.Models;

namespace FreshHeadBackend.Interfaces
{
    public interface ICompanyService
    {
        CompanyModel GetCompanyByID(Guid companyID);
        CompanyModel CreateCompany(CreateCompanyModel company);
        List<CompanyModel> GetCompanies();
        Company GetCompanyByEmail(string email);
        Task<bool> ValidateCompany(LoginModel model);
    }
}
