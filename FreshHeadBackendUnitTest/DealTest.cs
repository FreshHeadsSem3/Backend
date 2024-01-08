using AutoMapper;
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
        private readonly IDBContext _dbContext;

        public DealTest()
        {
            var options = new DbContextOptionsBuilder<DBContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            _dbContext = new DBContext(options); // Assuming DBContext implements IDBContext

            

            _dealRepository = new DealRepository(_dbContext);

            SeedDatabase(); // Separating the seeding logic
        }

        private void SeedDatabase()
        {
            if (!_dbContext.Deals.Any())
            {
                _dbContext.Deals.Add(new Deal
                {
                    ID = new Guid("00000000-0000-0000-0000-000000000001"),
                    Title = "Exciting Deal 1",
                    Description = "Don't miss out on this fantastic opportunity!",
                    Location = "City C",
                    MaxParticipants = 75,
                    ActiveTill = new DateTime(2024, 12, 31),
                    CategoryID = new Guid("10000000-0000-0000-0000-000000000001"),
                    Images = new List<DealImage>()
                    {
                        new DealImage()
                        {
                            DealID = new Guid("00000000-0000-0000-0000-000000000001"),
                            ImageUrl = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.istockphoto.com%2Fphotos%2Fhappy-face&psig=AOvVaw0QZ4Z4Z4Z4Z4Z4Z4Z4Z4Z4&ust=1614780940000000&source=images&cd=vfe&ved=0CAIQjRxqFwoTCJjQ9ZqH_-4CFQAAAAAdAAAAABAD"
                        }
                    },
                    Participants = new List<DealParticipants>()
                    {
                        new DealParticipants()
                        {
                            DealID = new Guid("00000000-0000-0000-0000-000000000001"),
                            Email = "gmdsmdsgmgmsmgmg"
                        }
                    }

                });
                _dbContext.Deals.Add(new Deal
                {
                    ID = new Guid("00000000-0000-0000-0000-000000000011"),
                    Title = "Exciting Deal 1",
                    Description = "Don't miss out on this fantastic opportunity!",
                    Location = "City C",
                    MaxParticipants = 75,
                    ActiveTill = new DateTime(2023, 10, 31),
                    CategoryID = new Guid("10000000-0000-0000-0000-000000000011")

                });


                // ... add more deals if needed

               
                _dbContext.SaveChanges();
                
                // i want to check if the deals are added to the database

            }
        }

        [TestMethod]
        public void Test_Debugging_ViewDeals()
        {
            var deals = _dbContext.Deals.ToList(); // Set a breakpoint on this line

            // Perform some assertions or other logic as needed
            Assert.IsTrue(deals.Any(), "No deals found in the database.");
        }

        [TestMethod]
        public void Test_GetAllDeals_Should_ReturnDeals()
        {
            var deals = _dealRepository.GetAllDeals();

            // Assert
           
            Assert.AreEqual(1, deals.Count());
            Assert.AreEqual(new DateTime (2024, 12, 31), deals.First().ActiveTill);
            Assert.AreEqual("Exciting Deal 1", deals.First().Title);

            
        }
    }



}
