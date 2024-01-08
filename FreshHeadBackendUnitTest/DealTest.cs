using AutoMapper;
using FreshHeadBackend;
using FreshHeadBackend.Business;
using FreshHeadBackend.Interfaces;
using FreshHeadBackend.Logic;
using FreshHeadBackend.Models;
using FreshHeadBackend.Repositories;
using FreshHeadBackendUnitTest.STUB;
using Microsoft.AspNetCore.DataProtection.KeyManagement.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Identity.Client;
using Moq;
using Moq.EntityFrameworkCore;

namespace FreshHeadBackendUnitTest
{
    [TestClass]
    public class DealTest
    {
        private readonly DealRepository _dealRepository;
        private readonly IDealCategoryRepository _idealCategoryRepository;
        private readonly DealStub _dealStub = new DealStub();
        
        

        [TestMethod]
        public void Test_GetAllDeals_Should_ReturnDeals()
        {
            // Arrange
            
            DealStub _dealStub = new DealStub();
            DealRepository dealRepository = new DealRepository(_dealStub._dbContext);
            IMapper _mapper = new MapperConfiguration(cfg => cfg.AddProfile(new MappingProfiles())).CreateMapper();
            ICompanyRepository _companyRepository = new CompanyRepository((DBContext)_dealStub._dbContext);
            IMailService _mailService = new MailService();
            DealService _dealService = new DealService(_mapper, dealRepository, _companyRepository, _mailService);

            var deals = _dealService.GetAllDeals();

            // Assert
           
            Assert.AreEqual(1, deals.Count());
            Assert.AreEqual(new DateTime (2024, 12, 31), deals.First().ActiveTill);
            Assert.AreEqual("Exciting Deal 1", deals.First().Title);

            
        }
        [TestMethod]
        public void Test_Claim_Deals_Should_ReturnDeals()
        {
            // Arrange
             DealRepository _dealRepository;
             
             DealStub _dealStub = new DealStub();
             IMapper _mapper = new MapperConfiguration(cfg => cfg.AddProfile(new MappingProfiles())).CreateMapper();
             ICompanyRepository _companyRepository = new CompanyRepository((DBContext)_dealStub._dbContext);
             IMailService _mailService = new MailService();
             DealService _dealService = new DealService(_mapper, _dealStub, _companyRepository, _mailService);

            ClaimDealModel claimDealModel = new ClaimDealModel()
            {
                DealID = new Guid("00000000-0000-0000-0000-000000000001"),
                MailUser = "amin.el.mohamadi@hotmail.com",
                MailMSG = "whahahaaa"
            };

            var deal = _dealService.ClaimDeal(claimDealModel);
            

            // Assert

            Assert.AreEqual(true, deal);
        }
    }



}
