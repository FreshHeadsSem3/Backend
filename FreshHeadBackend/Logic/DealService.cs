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
        public DealService(IMapper mapper, IDealRepository dealRepository)
        {
            this.mapper = mapper;
            this.dealRepository = dealRepository;
        }

        public List<DealModel> GetAllDeals()
        {
            DealModel deal = new DealModel(new Guid(), "Test", "Dit is een test", new List<string>());
            List<DealModel> dealModels = new List<DealModel>();
            dealModels.Add(deal);

            return dealModels;
        }
        public Deal CreateDeal(DealModel insertDeal)
        {
            Deal deal = dealRepository.CreateDeal(mapper.Map<Deal>(insertDeal));
            Deal dto = mapper.Map<Deal>(deal);
            dealRepository.Save();
            return dto;
        }
    }
}
