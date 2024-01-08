using FreshHeadBackend.Business;
using FreshHeadBackend.Interfaces;
using FreshHeadBackend.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreshHeadBackendUnitTest.STUB
{
    public class DealStub : IDealRepository
    {
        private readonly DealRepository _dealRepository;
        public readonly IDBContext _dbContext;
        public List<Deal> deals = new List<Deal>();
        public DealImage dealImage = new DealImage();
        public DealStub()
        {
            
            var options = new DbContextOptionsBuilder<DBContext>()
               .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;

            _dbContext = new DBContext(options);

            _dealRepository = new DealRepository(_dbContext);

            SeedDatabase(); 

            deals.Add(new Deal()
            {
                ID = new Guid("00000000-0000-0000-0000-000000000001"),
                Title = "Exciting Deal 1",
                Description = "Don't miss out on this fantastic opportunity!",
                Location = "City C",
                MaxParticipants = 75,
                ActiveTill = new DateTime(2024, 12, 31),
                CategoryID = new Guid("10000000-0000-0000-0000-000000000001")
            });

            deals.Add(new Deal()
            {
                ID = new Guid("00000000-0000-0000-0000-000000000002"),
                Title = "Exciting Deal 2",
                Description = "Very good very nice!",
                Location = "City A",
                MaxParticipants = 5,
                ActiveTill = new DateTime(2023, 12, 31),
                CategoryID = new Guid("20000000-0000-0000-0000-000000000001")
            });
            deals.Add(new Deal()
            {
                ID = new Guid("00000000-0000-0000-0000-000000000003"),
                Title = "Exciting Deal 3",
                Description = "Very good very nice!",
                Location = "City B",
                MaxParticipants = 5,
                ActiveTill = new DateTime(2023, 12, 31),
                CategoryID = new Guid("30000000-0000-0000-0000-000000000001")
            });
            deals.Add(new Deal()
            {
                ID = new Guid("00000000-0000-0000-0000-000000000004"),
                Title = "Exciting Deal 4",
                Description = "Very good very nice!",
                Location = "City C",
                MaxParticipants = 5,
                ActiveTill = new DateTime(2023, 12, 31),
                CategoryID = new Guid("40000000-0000-0000-0000-000000000001")
            });
            deals.Add(new Deal()
            {
                ID = new Guid("00000000-0000-0000-0000-000000000005"),
                Title = "Exciting Deal 5",
                Description = "Very good very nice!",
                Location = "City D",
                MaxParticipants = 5,
                ActiveTill = new DateTime(2023, 12, 31),
                CategoryID = new Guid("50000000-0000-0000-0000-000000000001")
            });


            dealImage = new DealImage()
            {
                ImageUrl = "Url1",
                DealID = new Guid("00000000-0000-0000-0000-000000000001")
                
            };
        }

        private void SeedDatabase()
        {
            if (!_dbContext.Deals.Any())
            {
                _dbContext.Deals.Add(new Deal
                {
                    ID = new Guid("00000000-0000-0000-0000-000000000001"),
                    Title = "Exciting Deal 1",
                    Description = "Don't miss out on this fantastic opportunityyyy!",
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
        public Deal CreateDeal(Deal dealEntity)
        {
            deals.Add(dealEntity);
            return dealEntity;
            
        }

        public DealImage CreateDealImage(DealImage imageEntity)
        {
            return dealImage;
           
        }

        public DealParticipants CreateDealParticipant(DealParticipants participantEntity)
        {
            return null;
        }

        public List<Deal> GetAllDeals()
        {
            return deals;
        }

        public List<Deal> GetDealByCategory(Guid categoryID)
        {
            return deals.FindAll(x => x.CategoryID == categoryID);
        }

        public List<Deal> GetDealByCompany(Guid companyID)
        {
            throw new NotImplementedException();
        }

        public List<Deal> GetDealByCompanyName(string companyName)
        {
            return deals.FindAll(x => x.Company.Title == companyName);
        }

        public Deal GetDealById(Guid dealID)
        {
            
            return deals.Find(x => x.ID == dealID);
        }

        public List<Deal> GetDealByTitle(string title)
        {
            return deals.FindAll(x => x.Title == title);
        }

        public List<DealImage> GetDealImageByDealID(Guid dealID)
        {
            return null;

        }

        public List<Deal> GetDealsByCompanyOnlyValid(Guid companyID)
        {
            throw new NotImplementedException();
        }

        public bool RemoveDealParticipant(Guid dealID, string usermail)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public Deal UpdateDeal(Deal deal, List<string> images)
        {
            throw new NotImplementedException();
        }

        public List<string> GetParticipantsEmailByDeal(Guid dealID)
        {
            throw new NotImplementedException();
        }
    }
}
