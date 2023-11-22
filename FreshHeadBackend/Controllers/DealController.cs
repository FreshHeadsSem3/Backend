using FreshHeadBackend.Interfaces;
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
            try {
                return Ok(dealService.GetDealByID(id));
            } catch(Exception ex) {
                return Ok(ex);
            }
        }

        [HttpGet]
        [Route("deals/category/{category}")]
        public IActionResult GetDealByCategory(string category)
        {
            return Ok(dealService.GetDealByCategory(category));
        }

        //deal/deals/title/""
        [HttpGet]
        [Route("deals/title/{title}")]
        public IActionResult GetDealByTitle(string title)
        {
            return Ok(dealService.GetDealByTitle(title));
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

        // deal/ClaimDeal
        [HttpPost]
        [Route("ClaimDeal")]
        public IActionResult ClaimDeal(ClaimDealModel model)
        {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            return Ok(dealService.ClaimDeal(model));
        }

        // deal/CancleDeal
        [HttpPost]
        [Route("CancelDeal")]
        public IActionResult CancelDeal(CancelDealModel model)
        {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            return Ok(dealService.CancleDeal(model));
        }
    }
}

