using AutoMapper;
using FreshHeadBackend.Interfaces;
using FreshHeadBackend.Logic;
using FreshHeadBackend.Models;
using FreshHeadBackendUnitTest.STUB;

namespace FreshHeadBackendUnitTest
{
    [TestClass]
    public class DealTest
    {
        
        private readonly IMapper mapper;

        [TestMethod]
        public void GetAllDeals()
        {
            // arrange
            DealStub dealStub = new DealStub();
            CompanyStub companyStub = new CompanyStub();
            MailStub mailStub = new MailStub();
            DealService dealLogic = new DealService(mapper, dealStub, companyStub, mailStub);
            

            // act
            List<DealModel> result = dealLogic.GetAllDeals();

            // assert
            Assert.AreEqual(5, result.Count);
            Assert.AreEqual(new Guid("00000000-0000-0000-0000-000000000001"), result[0].ID);
            Assert.AreEqual("Exciting Deal 1", result[0].Title);
            Assert.AreEqual("Don't miss out on this fantastic opportunity!", result[0].Description);
            Assert.AreEqual("City C", result[0].Location);
            Assert.AreEqual(75, result[0].MaxParticipants);
            Assert.AreEqual(new DateTime(2023, 12, 31), result[0].ActiveTill);
            Assert.AreEqual(new Guid("10000000-0000-0000-0000-000000000001"), result[0].DealCategoryID);

            Assert.AreEqual(new Guid("00000000-0000-0000-0000-000000000002"), result[1].ID);
            Assert.AreEqual("Exciting Deal 2", result[1].Title);
            Assert.AreEqual("Very good very nice!", result[1].Description);
            Assert.AreEqual("City A", result[1].Location);
            Assert.AreEqual(5, result[1].MaxParticipants);
            Assert.AreEqual(new DateTime(2023, 12, 31), result[1].ActiveTill);
            Assert.AreEqual(new Guid("20000000-0000-0000-0000-000000000001"), result[1].DealCategoryID);

            Assert.AreEqual(new Guid("00000000-0000-0000-0000-000000000003"), result[2].ID);
            Assert.AreEqual("Exciting Deal 3", result[2].Title);
            Assert.AreEqual("Very good very nice!", result[2].Description);
            Assert.AreEqual("City B", result[2].Location);
            Assert.AreEqual(5, result[2].MaxParticipants);
            Assert.AreEqual(new DateTime(2023, 12, 31), result[2].ActiveTill);
            Assert.AreEqual(new Guid("30000000-0000-0000-0000-000000000001"), result[2].DealCategoryID);

            Assert.AreEqual(new Guid("00000000-0000-0000-0000-000000000004"), result[3].ID);
            Assert.AreEqual("Exciting Deal 4", result[3].Title);
            Assert.AreEqual("Very good very nice!", result[3].Description);
            Assert.AreEqual("City C", result[3].Location);
            Assert.AreEqual(5, result[3].MaxParticipants);
            Assert.AreEqual(new DateTime(2023, 12, 31), result[3].ActiveTill);
            Assert.AreEqual(new Guid("40000000-0000-0000-0000-000000000001"), result[3].DealCategoryID);

            Assert.AreEqual(new Guid("00000000-0000-0000-0000-000000000005"), result[4].ID);
            Assert.AreEqual("Exciting Deal 5", result[4].Title);
            Assert.AreEqual("Very good very nice!", result[4].Description);
            Assert.AreEqual("City D", result[4].Location);
            Assert.AreEqual(5, result[4].MaxParticipants);
            Assert.AreEqual(new DateTime(2023, 12, 31), result[4].ActiveTill);
            Assert.AreEqual(new Guid("50000000-0000-0000-0000-000000000001"), result[4].DealCategoryID);

        }
        [TestMethod]
        public void GetAllDealsResultIsNull()
        {
            // arrange
            DealNullStub dealNullStub = new DealNullStub();
            CompanyStub companyStub = new CompanyStub();
            MailStub mailStub = new MailStub();
            DealService dealLogic = new DealService(mapper, dealNullStub, companyStub, mailStub);


            // act
            List<DealModel> result = dealLogic.GetAllDeals();
            // assert
            Assert.IsNull(result);

        }
        [TestMethod]
        public void GetDealByID()
        {
            // arrange
            DealStub dealStub = new DealStub();
            CompanyStub companyStub = new CompanyStub();
            MailStub mailStub = new MailStub();
            DealService dealLogic = new DealService(mapper, dealStub, companyStub, mailStub);
            // act
            DealModel result = dealLogic.GetDealByID(new Guid("00000000-0000-0000-0000-000000000001"));
            // assert
            Assert.AreEqual(new Guid("00000000-0000-0000-0000-000000000001"), result.ID);
            Assert.AreEqual("Exciting Deal 1", result.Title);
            Assert.AreEqual("Don't miss out on this fantastic opportunity!", result.Description);
            Assert.AreEqual("City C", result.Location);
            Assert.AreEqual(75, result.MaxParticipants);
            Assert.AreEqual(new DateTime(2023, 12, 31), result.ActiveTill);
            Assert.AreEqual(new Guid("10000000-0000-0000-0000-000000000001"), result.DealCategoryID);
        }
        [TestMethod]
        public void GetDealByIDResultIsNull()
        {
            // arrange
            DealStub dealStub = new DealStub();
            CompanyStub companyStub = new CompanyStub();
            MailStub mailStub = new MailStub();
            DealService dealLogic = new DealService(mapper, dealStub, companyStub, mailStub);
            // act
            DealModel result = dealLogic.GetDealByID(new Guid("00000000-0000-0000-0000-000000000007"));
            // assert
            
                Assert.IsNull (result);
           
        }

        [TestMethod]
        public void GetDealByTitle()
        {
            // arrange
            DealStub dealStub = new DealStub();
            CompanyStub companyStub = new CompanyStub();
            MailStub mailStub = new MailStub();
            DealService dealLogic = new DealService(mapper, dealStub, companyStub, mailStub);
            // act
            List<DealModel> result = dealLogic.GetDealByTitle("Exciting Deal 1");
            // assert
            Assert.AreEqual(new Guid("00000000-0000-0000-0000-000000000001"), result[0].ID);
            Assert.AreEqual("Exciting Deal 1", result[0].Title);
            Assert.AreEqual("Don't miss out on this fantastic opportunity!", result[0].Description);
            Assert.AreEqual("City C", result[0].Location);
            Assert.AreEqual(75, result[0].MaxParticipants);
            Assert.AreEqual(new DateTime(2023, 12, 31), result[0].ActiveTill);
            Assert.AreEqual(new Guid("10000000-0000-0000-0000-000000000001"), result[0].DealCategoryID);
        }

        [TestMethod]
        public void GetDealByTitleResultIsNull()
        {
            // arrange
            DealStub dealStub = new DealStub();
            CompanyStub companyStub = new CompanyStub();
            MailStub mailStub = new MailStub();
            DealService dealLogic = new DealService(mapper, dealStub, companyStub, mailStub);
            // act
            List<DealModel> result = dealLogic.GetDealByTitle("Exciting Deal 777");
            // assert
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void GetDealByCategoryID()
        {
            // arrange
            DealStub dealStub = new DealStub();
            CompanyStub companyStub = new CompanyStub();
            MailStub mailStub = new MailStub();
            DealService dealLogic = new DealService(mapper, dealStub, companyStub, mailStub);
            // act
            List<DealModel> result = dealLogic.GetDealByCategory(new Guid("10000000-0000-0000-0000-000000000001"));
            // assert
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(new Guid("00000000-0000-0000-0000-000000000001"), result[0].ID);
            Assert.AreEqual("Exciting Deal 1", result[0].Title);
            Assert.AreEqual("Don't miss out on this fantastic opportunity!", result[0].Description);
            Assert.AreEqual("City C", result[0].Location);
            Assert.AreEqual(75, result[0].MaxParticipants);
            Assert.AreEqual(new DateTime(2023, 12, 31), result[0].ActiveTill);
            Assert.AreEqual(new Guid("10000000-0000-0000-0000-000000000001"), result[0].DealCategoryID);
        }

        [TestMethod]
        public void GetDealByCategoryIDResultIsNull()
        {
            // arrange
            DealStub dealStub = new DealStub();
            CompanyStub companyStub = new CompanyStub();
            MailStub mailStub = new MailStub();
            DealService dealLogic = new DealService(mapper, dealStub, companyStub, mailStub);
            // act
            List<DealModel> result = dealLogic.GetDealByCategory(new Guid("11000000-0000-0000-0000-000000000001"));
            // assert
            Assert.AreEqual(0, result.Count);
        }


        [TestMethod]
        public void CreateDeal()
        {
            // arrange
            DealStub dealStub = new DealStub();
            CompanyStub companyStub = new CompanyStub();
            MailStub mailStub = new MailStub();
            DealService dealLogic = new DealService(mapper, dealStub, companyStub, mailStub);
            CreateDealModel deal = new CreateDealModel()
            {
                title = "Exciting Deal 2",
                description = "Don't miss out on this fantastic opportunity!",
                location = "City C",
                images = new List<string> { "Url1"},
                maxParticipants = 75,
                activeTill = new DateTime(2023, 12, 31),
                categoryID = new Guid("10000000-0000-0000-0000-000000000001"),
                companyID = new Guid("00000000-0000-0000-0000-000000000001")
            };
            // act
            dealLogic.CreateDeal(deal);
            // assert
            Assert.AreEqual(6, dealStub.deals.Count);
            Assert.AreEqual("Exciting Deal 2", dealStub.deals[5].Title);
            Assert.AreEqual("Don't miss out on this fantastic opportunity!", dealStub.deals[5].Description);
            Assert.AreEqual("City C", dealStub.deals[5].Location);
            Assert.AreEqual("Url1", dealStub.dealImage.ImageUrl);
            Assert.AreEqual(75, dealStub.deals[5].MaxParticipants);
            Assert.AreEqual(new DateTime(2023, 12, 31), dealStub.deals[1].ActiveTill);
            Assert.AreEqual(new Guid("10000000-0000-0000-0000-000000000001"), dealStub.deals[5].CategoryID);
            Assert.AreEqual(new Guid("00000000-0000-0000-0000-000000000001"), dealStub.deals[5].CompanyID);
        }

        [TestMethod]
        public void CreateDealFailed()
        {
            // arrange
            DealStub dealStub = new DealStub();
            CompanyStub companyStub = new CompanyStub();
            MailStub mailStub = new MailStub();
            DealService dealLogic = new DealService(mapper, dealStub, companyStub, mailStub);
            CreateDealModel deal = null;
            // act
            dealLogic.CreateDeal(deal);
            // assert
            Assert.AreEqual(5, dealStub.deals.Count);

        }
    }
}