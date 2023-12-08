using FreshHeadBackend.Business;
using FreshHeadBackend.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreshHeadBackendUnitTest.STUB
{
    public class DealStub : IDealRepository
    {
        public List<Deal> deals = new List<Deal>();
        public DealImage dealImage = new DealImage();
        public DealStub()
        {
            deals.Add(new Deal()
            {
                ID = new Guid("00000000-0000-0000-0000-000000000001"),
                Title = "Exciting Deal 1",
                Description = "Don't miss out on this fantastic opportunity!",
                Location = "City C",
                MaxParticipants = 75,
                ActiveTill = new DateTime(2023, 12, 31),
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
            throw new NotImplementedException();
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

        public bool RemoveDealParticipant(Guid dealID, string usermail)
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
