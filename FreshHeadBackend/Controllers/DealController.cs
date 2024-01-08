using FreshHeadBackend.Interfaces;
using FreshHeadBackend.Models;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.IdentityModel.Tokens.Jwt;
using FreshHeadBackend.Logic;

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

            string header = Request.Headers["Authorization"];

            string[] parts = header.Split(new[] { "Bearer" }, StringSplitOptions.RemoveEmptyEntries);
            string token = parts[0].Trim();

            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(token) as JwtSecurityToken;

            if (jsonToken != null) {
                var nameIdentifierClaim = jsonToken.Claims.FirstOrDefault(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier");
                if (nameIdentifierClaim != null) {
                    if (Guid.TryParse(nameIdentifierClaim.Value, out Guid nameIdentifierGuid)) {
                        // Use the nameIdentifierGuid as a Guid
                        model.companyID = nameIdentifierGuid;
                        DealModel result = dealService.CreateDeal(model);
                        return Ok(result);
                    } else {
                        // Handle the case where the value is not a valid Guid
                        return BadRequest("Invalid Guid format");
                    }
                } else {
                    // Handle the case where the NameIdentifier claim is not present
                    return BadRequest("NameIdentifier claim not present");
                }
            } else {
                // Handle the case where the token is not a JwtSecurityToken
                return BadRequest("Invalid JWT token format");
            }
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

        [HttpGet("GetParticipantEmailsByDeal/{dealID}")]
        public ActionResult<IEnumerable<string>> GetParticipantEmailsByDeal(Guid dealID)
        {
            var emails = dealService.GetParticipantsEmailByDeal(dealID);
            if (emails == null || !emails.Any())
            {
                return NotFound();
            }
            return Ok(emails);
        }
    }
}

