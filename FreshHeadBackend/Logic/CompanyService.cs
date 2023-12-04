using AutoMapper;
using FreshHeadBackend.Business;
using FreshHeadBackend.Interfaces;
using FreshHeadBackend.Models;
using FreshHeadBackend.Repositories;
using System.ComponentModel.Design;

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

        public List<CompanyModel> GetAllCompanies()
        {
            List<CompanyModel> result = new List<CompanyModel>();
            foreach (Company company in companyRepository.GetAllCompanies())
            {
                company.Images = GetCompanyImageByCompanyID(company.ID);
                result.Add(new CompanyModel(company));
            }
            return result;
        }
        public CompanyModel GetCompanyByDealID(Guid dealID)
        {
            return new CompanyModel(companyRepository.GetCompanyByDealID(dealID));
        }

        public Company GetCompany(Guid companyID)
        {
            return this.companyRepository.GetCompany(companyID);
        }

        public CompanyModel GetCompanyByID(Guid companyID)
        {
            Company company = companyRepository.GetCompanyByID(companyID);
            return new CompanyModel(company);
        }

        private List<CompanyImage> GetCompanyImageByCompanyID(Guid companyID)
        {
            return companyRepository.GetCompanyImageByCompanyID(companyID);
        }

        public CompanyModel CreateCompany(CreateCompanyModel insertCompany)
        {
            Company company = new Company(insertCompany);
            Company returnedCompany = companyRepository.CreateCompany(company);
            foreach (string image in insertCompany.Images)
            {
                CompanyImage companyImage = new CompanyImage(image, returnedCompany.ID);
                companyRepository.CreateCompanyImage(companyImage);
            }
            return new CompanyModel(returnedCompany);
        }

        public List<CompanyModel> GetCompanies()
        {
            List<CompanyModel> companymodels = new List<CompanyModel>();
            List<Company> companies = companyRepository.GetCompanies();
            foreach(Company company in companies)
            {
                companymodels.Add(new CompanyModel(company.ID, company.Title));
            }

            return companymodels;
        }
    }
}