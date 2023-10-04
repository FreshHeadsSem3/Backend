using FreshHeadBackend.Business;

namespace FreshHeadBackend.Interfaces
{
    public interface ICompanyService
    {
        Company getCompanyByID(Guid companyID);
    }
}
