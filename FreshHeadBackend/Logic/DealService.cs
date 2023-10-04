﻿using FreshHeadBackend.Business;
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
            List<DealModel> result = new List<DealModel>();
            foreach(Deal deal in dealRepository.GetAllDeals()) {
                deal.Images = getImagesByDealID(deal.ID);
                result.Add(new DealModel(deal));
            }
            return result;
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
            deal.CompanyID = insertDeal.companyID;
            Deal returnedDeal = dealRepository.CreateDeal(deal);
            foreach(string image in insertDeal.images) {
                DealImage dealimage = new DealImage(image, returnedDeal.ID);
                dealRepository.CreateDealImage(dealimage);
            }
            return new DealModel(returnedDeal);
        }
    }
}
