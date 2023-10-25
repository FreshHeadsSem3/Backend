using FreshHeadBackend.Interfaces;
using FreshHeadBackend.Models;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using FreshHeadBackend.Business;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

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
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Company")]
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

        //deal/company/"companyID"
        [HttpGet]
        [Route("company/{companyID}")]
        public IActionResult GetDealByCompany(Guid companyID)
        {
            return Ok(dealService.GetDealByCompany(companyID));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Company")]
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

