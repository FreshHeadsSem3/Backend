using FreshHeadBackend.Business;

namespace FreshHeadBackend.Interfaces
{
    public interface ICompanyRepository
    {
        Company GetCompany(Guid companyID);
    }
}
