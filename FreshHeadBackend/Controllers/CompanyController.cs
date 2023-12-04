using AutoMapper;
using FreshHeadBackend.Models;
using FreshHeadBackend.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FreshHeadBackend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CompanyController : Controller
    {
        private readonly ICompanyService companyService;
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;

        public CompanyController(ICompanyService companyLogic, IMapper mapper, IConfiguration configuration)
        {
            this.companyService = companyService;
            this.mapper = mapper;
            this.configuration = configuration;
        }

        [HttpGet]
        public IActionResult GetAllCompanies()
        {
            return Ok(companyService.GetAllCompanies());
        }

        [HttpGet]
        [Route("{ID}")]
        public IActionResult GetCompanyByID(Guid ID)
        {
            return Ok(companyService.GetCompanyByID(ID));
        }


        [HttpPost]
        public IActionResult CreateCompany(CreateCompanyModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            CompanyModel result = companyService.CreateCompany(model);

            return Ok(result);
        }

        [HttpGet]
        [Route("deal/{ID}")]
        public IActionResult GetCompanyByDealID(Guid ID)
        {
            return Ok(companyService.GetCompanyByDealID(ID));
        }

        [HttpGet]
        [Route("dealCategory")]
        public IActionResult GetCompanies()
        {
            return Ok(companyService.GetCompanies());
        }

    }
}
