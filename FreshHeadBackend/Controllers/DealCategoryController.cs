using AutoMapper;
using FreshHeadBackend.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FreshHeadBackend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DealCategoryController : Controller
    {
        private readonly IDealCategoryService dealCategoryService;
        private readonly IMapper mapper;

        public DealCategoryController(IDealCategoryService dealCategoryService, IMapper mapper) 
        { 
            this.dealCategoryService = dealCategoryService;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Ok(dealCategoryService.GetAllDealCategories());
        }
        
    }
}
