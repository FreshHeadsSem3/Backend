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
        [Route("deals/{id}")]
        public IActionResult GetDealByID(Guid id)
        {
            return Ok(dealService.GetDealByID(id));
        }

        [HttpGet]
        [Route("deals/category/{category}")]
        public IActionResult GetDealByCategory(string category)
        {
            return Ok(dealService.GetDealByCategory(category));
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

    }
}

