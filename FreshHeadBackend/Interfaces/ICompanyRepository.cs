using FreshHeadBackend.Business;

namespace FreshHeadBackend.Interfaces
{
    public interface ICompanyRepository
    {
        List<Company> GetAllCompanies();
        Company GetCompany(Guid companyID);
        Company GetCompanyByID(Guid companyID);
        Company GetCompanyByDealID(Guid dealID);
        Company CreateCompany(Company companyEntity);
        List<Company> GetCompanies();
        CompanyImage CreateCompanyImage(CompanyImage imageEntity);
        List<CompanyImage> GetCompanyImageByCompanyID(Guid companyID);
        Company GetCompanyByEmail(string email);
        void Save();
        void Save(bool acceptChangesOnSuccess);
    }
}
