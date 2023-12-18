using FreshHeadBackend.Business;
using FreshHeadBackend.Interfaces;
using FreshHeadBackend.Models;
using AutoMapper;

namespace FreshHeadBackend.Logic
{
    public class DealService : IDealService
    {

        private readonly IMapper mapper;
        private readonly IDealRepository dealRepository;
        private readonly ICompanyRepository companyRepository;
        private readonly IMailService mailService;
        public DealService(IMapper mapper, IDealRepository dealRepository, ICompanyRepository companyRepository, IMailService mailService)
        {
            this.mapper = mapper;
            this.dealRepository = dealRepository;
            this.companyRepository = companyRepository;
            this.mailService = mailService;
        }

        public List<DealModel> GetAllDeals()
        {
            List<DealModel> result = new List<DealModel>();

            if (dealRepository.GetAllDeals() == null)
            {
                return null;
            }

            else
            {
                foreach (Deal deal in dealRepository.GetAllDeals())
                {
                    deal.Images = getImagesByDealID(deal.ID);
                    result.Add(new DealModel(deal));
                }
                return result;
            }


        }

        public List<DealModel> GetDealByCategory(Guid categoryID)
        {
            List<DealModel> result = new List<DealModel>();

            if (dealRepository.GetDealByCategory(categoryID) == null)
            {
                return null;
            }
            else
            {
                foreach (Deal deal in dealRepository.GetDealByCategory(categoryID))
                {
                    deal.Images = getImagesByDealID(deal.ID);
                    result.Add(new DealModel(deal));
                }
                return result;
            }

        }
        public List<DealModel> GetDealByTitle(string title)
        {
            List<DealModel> result = new List<DealModel>();


            if (dealRepository.GetDealByTitle(title) == null)
            {
                return null;
            }
            else
            {
                foreach (Deal deal in dealRepository.GetDealByTitle(title))
                {
                    deal.Images = getImagesByDealID(deal.ID);
                    result.Add(new DealModel(deal));
                }
                return result;
            }

        }
        public List<DealModel> GetDealByCompanyName(string companyName)
        {
            List<DealModel> result = new List<DealModel>();

            if (dealRepository.GetDealByCompanyName(companyName) == null)
            {
                return null;
            }
            else
            {
                foreach (Deal deal in dealRepository.GetDealByCompanyName(companyName))
                {
                    deal.Images = getImagesByDealID(deal.ID);
                    result.Add(new DealModel(deal));
                }
                return result;
            }


        }

        public List<DealModel> GetDealByCompany(Guid companyID)
        {
            List<DealModel> result = new List<DealModel>();
            foreach (Deal deal in dealRepository.GetDealByCompany(companyID))
            {
                deal.Images = getImagesByDealID(deal.ID);
                result.Add(new DealModel(deal));
            }
            return result;
        }

        public DealModel GetDealByID(Guid dealID)
        {
            Deal deal = dealRepository.GetDealById(dealID);
            if (deal == null)
            {
                return null;
            }
            else
            {
                return new DealModel(deal);
            }

        }
        private List<DealImage> getImagesByDealID(Guid dealID)
        {
            return dealRepository.GetDealImageByDealID(dealID);
        }

        public DealModel CreateDeal(CreateDealModel insertDeal)
        {

            if (insertDeal == null)
            {
                return null;
            }
            else
            {
                Deal deal = new Deal(insertDeal);
                Deal returnedDeal = dealRepository.CreateDeal(deal);
                foreach (string image in insertDeal.images)
                {
                    DealImage dealimage = new DealImage(image, returnedDeal.ID);
                    dealRepository.CreateDealImage(dealimage);
                }
                return new DealModel(returnedDeal);
            }

        }

        public bool ClaimDeal(ClaimDealModel model)
        {
            Deal deal = dealRepository.GetDealById(model.DealID);
            if (deal.MaxParticipants > 0 && deal.GetParticipantsCount() == deal.MaxParticipants) return false; //als maxparticipent bereikt is mag de deal niet geclaimed worden.
            if (deal.ActiveTill <= new DateTime()) return false; //als het op de datum of na de datum is mag de deal niet geclaimed worden.
            bool result = mailService.SendEmailAsync(model.MailUser, deal.Title, model.MailMSG);
            if (result)
            {
                dealRepository.CreateDealParticipant(new DealParticipants(model.DealID, model.MailUser)); //als de deal een max participants heeft wordt er een deal geclaimed, alleen als de mail verstuurd is.
            }
            if (deal.MaxParticipants > 0)
            {
               double remaining = deal.GetParticipantsCount()/ deal.MaxParticipants * 100;
                if (remaining < 15)
                {
                    //sendEmail
                }
            }
            return result; //als de mail verzonden is return true. als de mail niet verzonden is return false
        }

        public bool CancleDeal(CancelDealModel cancleDeal)
        {
            return dealRepository.RemoveDealParticipant(cancleDeal.DealID, cancleDeal.MailUser);
        }
    }
}
