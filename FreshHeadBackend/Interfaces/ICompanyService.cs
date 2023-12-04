using FreshHeadBackend.Business;
using FreshHeadBackend.Models;

namespace FreshHeadBackend.Interfaces
{
    public interface ICompanyService
    {
        List<CompanyModel> GetAllCompanies();
        CompanyModel GetCompanyByID(Guid companyID);
        CompanyModel CreateCompany(CreateCompanyModel company);
        CompanyModel GetCompanyByDealID(Guid dealID);
        List<CompanyModel> GetCompanies();
    }
}
