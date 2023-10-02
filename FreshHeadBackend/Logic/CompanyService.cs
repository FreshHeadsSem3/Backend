using AutoMapper;
using FreshHeadBackend.Business;
using FreshHeadBackend.Interfaces;

namespace FreshHeadBackend.Logic
{
    public class CompanyService : ICompanyService
    {
        private readonly IMapper mapper;
        private readonly ICompanyRepository companyRepository;

        public CompanyService(IMapper mapper, ICompanyRepository companyRepository)
        {
            this.mapper = mapper;
            this.companyRepository = companyRepository;
        }

        public Company getCompanyByID(Guid companyID)
        {
            return this.companyRepository.GetCompany(companyID);
        }
    }
}
