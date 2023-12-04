using FreshHeadBackend.Business;

namespace FreshHeadBackend.Interfaces
{
    public interface ICompanyRepository
    {
        Company GetCompany(Guid companyID);
        Company GetCompanyByID(Guid companyID);
        Company CreateCompany(Company companyEntity);
        List<Company> GetCompanies();
        CompanyImage CreateCompanyImage(CompanyImage imageEntity);
        Company GetCompanyByEmail(string email);
        List<CompanyImage> GetCompanyImageByCompanyID(Guid companyID);
        void Save();
        void Save(bool acceptChangesOnSuccess);
    }
}
