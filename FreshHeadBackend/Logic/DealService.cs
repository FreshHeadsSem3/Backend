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
            foreach(Deal deal in dealRepository.GetAllDeals()) {
                deal.Images = getImagesByDealID(deal.ID);
                result.Add(new DealModel(deal));
            }
            return result;
        }

        public List<DealModel> GetDealByCategory(string category) 
        {
            List<DealModel> result = new List<DealModel>();
            foreach(Deal deal in dealRepository.GetDealByCategory(category))
            {
                deal.Images = getImagesByDealID(deal.ID);
                result.Add(new DealModel(deal));
            }
            return result;
            
        }

        public DealModel GetDealByID(Guid dealID)
        {
            Deal deal = dealRepository.GetDealById(dealID);
            return new DealModel(deal);
        }
        private List<DealImage> getImagesByDealID(Guid dealID)
        {
            return dealRepository.GetDealImageByDealID(dealID);
        }

        public DealModel CreateDeal(CreateDealModel insertDeal)
        {
            Deal deal = new Deal();
            deal.Title = insertDeal.title;
            deal.Description = insertDeal.description;
            deal.CategoryID = insertDeal.categoryID;
            deal.CompanyID = insertDeal.companyID;
            Deal returnedDeal = dealRepository.CreateDeal(deal);
            foreach(string image in insertDeal.images) {
                DealImage dealimage = new DealImage(image, returnedDeal.ID);
                dealRepository.CreateDealImage(dealimage);
            }
            return new DealModel(returnedDeal);
        }
        
        public bool ClaimDeal(ClaimDealModel model)
        {
            Deal deal = dealRepository.GetDealById(model.DealID);
            if (&& deal.MaxParticipents == deal.Claimed) return false; //als maxparticipent bereikt is mag de deal niet geclaimed worden.
            if (deal.ActiveTill <= new DateTime()) return false; //als het op de datum of na de datum is mag de deal niet geclaimed worden.
            bool result = mailService.SendEmailAsync(model.MailUser, deal.Title, model.MailMSG);
            if(result) {
                if(deal)
            }
        }
    }
}
