using FreshHeadBackend.Business;
using FreshHeadBackend.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreshHeadBackendUnitTest.STUB
{
    public class DealNullStub : IDealRepository
    {
        public Deal CreateDeal(Deal dealEntity)
        {
            throw new NotImplementedException();
        }

        public DealImage CreateDealImage(DealImage imageEntity)
        {
            throw new NotImplementedException();
        }

        public DealParticipants CreateDealParticipant(DealParticipants participantEntity)
        {
            throw new NotImplementedException();
        }

        public List<Deal> GetAllDeals()
        {
            return null;
        }

        public List<Deal> GetDealByCategory(Guid categoryID)
        {
            throw new NotImplementedException();
        }

        public List<Deal> GetDealByCompany(Guid companyID)
        {
            throw new NotImplementedException();
        }

        public List<Deal> GetDealByCompanyName(string companyName)
        {
            throw new NotImplementedException();
        }

        public Deal GetDealById(Guid dealID)
        {
            throw new NotImplementedException();
        }

        public List<Deal> GetDealByTitle(string title)
        {
            throw new NotImplementedException();
        }

        public List<DealImage> GetDealImageByDealID(Guid dealID)
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


    }
}
