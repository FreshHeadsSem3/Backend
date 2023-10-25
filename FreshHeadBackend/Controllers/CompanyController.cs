using AutoMapper;
using FreshHeadBackend.Interfaces;
using FreshHeadBackend.Models;
using Microsoft.AspNetCore.Mvc;

namespace FreshHeadBackend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CompanyController : Controller
    {
        private readonly ICompanyService companyService;
        private readonly IMapper mapper;

        public CompanyController(ICompanyService companyLogic, IMapper mapper)
        {
            this.companyService = companyLogic;
            this.mapper = mapper;
        }

        //[HttpGet]
        //public IActionResult Index()
        //{
        //    return Ok(CreateCompany);
        //}

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
    }
}
