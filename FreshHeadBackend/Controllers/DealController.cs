﻿using FreshHeadBackend.Interfaces;
using FreshHeadBackend.Models;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using FreshHeadBackend.Business;

namespace FreshHeadBackend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DealController : Controller
    {
        private readonly IDealService dealService;
        private readonly IMapper mapper;
        public DealController(IDealService dealLogic, IMapper mapper)
        {
            this.dealService = dealLogic;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Ok(dealService.GetAllDeals());
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetDealByID(Guid id)
        {
            DealModel deal = dealService.GetDealByID(id);
            if (deal == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(deal);
            }
            
        }

        [HttpGet]
        [Route("deals/category/{category}")]
        public IActionResult GetDealByCategory(Guid categoryID)
        {
            return Ok(dealService.GetDealByCategory(categoryID));
        }

        //deal/deals/title/""
        [HttpGet]
        [Route("deals/title/{title}")]
        public IActionResult GetDealByTitle(string title)
        {
            return Ok(dealService.GetDealByTitle(title));
        }
        [HttpGet]
        [Route("deals/company/{companyName}")]
        public IActionResult GetDealByCompanyName(string companyName)
        {
            return Ok(dealService.GetDealByCompanyName(companyName));
        }

        [HttpPost]
        public IActionResult CreateDeal(CreateDealModel model)
        {//verbeteren
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            DealModel result = dealService.CreateDeal(model);

            return Ok(result);
        }

        //dealClaimDeal
        [HttpPost]
        [Route("ClaimDeal")]
        public IActionResult ClaimDeal(ClaimDealModel model)
        {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            return Ok(dealService.ClaimDeal(model));
        }

    }
}

