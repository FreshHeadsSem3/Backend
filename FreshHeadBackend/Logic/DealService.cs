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
        public DealService(IMapper mapper, IDealRepository dealRepository, ICompanyRepository companyRepository)
        {
            this.mapper = mapper;
            this.dealRepository = dealRepository;
            this.companyRepository = companyRepository;
        }

        public List<DealModel> GetAllDeals()
        {
            DealModel deal = new DealModel(new Guid(), "Test", "Dit is een test", new List<string>());
            List<DealModel> dealModels = new List<DealModel>();
            dealModels.Add(deal);

            return dealModels;
        }
        public DealModel CreateDeal(CreateDealModel insertDeal)
        {
            Deal deal = new Deal();
            deal.Title = insertDeal.title;
            deal.Description = insertDeal.description;
            deal.Company = companyRepository.GetCompany(insertDeal.companyID);
            deal.Images = new List<DealImage>();
            foreach(string image in insertDeal.images) {
                DealImage dealimage = new DealImage(image);
                deal.Images.Add(dealimage);
            }
            Deal returnedDeal = dealRepository.CreateDeal(deal);
            dealRepository.Save();
            return new DealModel(returnedDeal);
        }
    }
}
