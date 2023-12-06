using FreshHeadBackend.Business;
using FreshHeadBackend.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreshHeadBackendUnitTest.STUB
{
    public class CompanyStub : ICompanyRepository
    {
        public Company CreateCompany(Company companyEntity)
        {
            throw new NotImplementedException();
        }

        public CompanyImage CreateCompanyImage(CompanyImage imageEntity)
        {
            throw new NotImplementedException();
        }

        public List<Company> GetAllCompanies()
        {
            throw new NotImplementedException();
        }

        public List<Company> GetCompanies()
        {
            throw new NotImplementedException();
        }

        public Company GetCompany(Guid companyID)
        {
            throw new NotImplementedException();
        }

        public Company GetCompanyByDealID(Guid dealID)
        {
            throw new NotImplementedException();
        }

        public Company GetCompanyByID(Guid companyID)
        {
            throw new NotImplementedException();
        }

        public List<CompanyImage> GetCompanyImageByCompanyID(Guid companyID)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Save(bool acceptChangesOnSuccess)
        {
            throw new NotImplementedException();
        }
    }
}
