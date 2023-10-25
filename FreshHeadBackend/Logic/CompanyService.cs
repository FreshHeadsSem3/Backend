﻿using AutoMapper;
using FreshHeadBackend.Business;
using FreshHeadBackend.Interfaces;
using FreshHeadBackend.Models;

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
    }
}