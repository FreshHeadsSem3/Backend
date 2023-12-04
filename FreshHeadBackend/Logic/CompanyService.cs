using AutoMapper;
using FreshHeadBackend.Business;
using FreshHeadBackend.Interfaces;
using FreshHeadBackend.Models;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.Design;

namespace FreshHeadBackend.Logic
{
    public class CompanyService : ICompanyService
    {
        private readonly IMapper mapper;
        private readonly ICompanyRepository companyRepository;
        private readonly UserManager<Company> companymanager;
        private readonly SignInManager<Company> signInManager;

        public CompanyService(IMapper mapper, ICompanyRepository companyRepository, UserManager<Company> companymanager, SignInManager<Company> signInManager)
        {
            this.mapper = mapper;
            this.companyRepository = companyRepository;
            this.companymanager = companymanager;
            this.signInManager = signInManager;
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
            Company company = new Company();
            company.Title = insertCompany.Title;
            company.Description = insertCompany.Description;
            company.KVK = insertCompany.KVK;
            Company returnedCompany = companyRepository.CreateCompany(company);
            foreach(string image in insertCompany.Images)
            {
                CompanyImage companyImage = new CompanyImage(image, returnedCompany.ID);
                companyRepository.CreateCompanyImage(companyImage);
            }
            return new CompanyModel(returnedCompany);
        }

        public Company GetCompanyByEmail(string email)
        {
            return companyRepository.GetCompanyByEmail(email);

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

        public async Task<bool> ValidateCompany(LoginModel model)
        {
            var company = await companymanager.FindByIdAsync(model.ID.ToString());

            if (company != null)
            {
                var signInResult = await signInManager.CheckPasswordSignInAsync(company, model.Password, false);
                return signInResult.Succeeded;

            }

            return false;
        }
    }
}
