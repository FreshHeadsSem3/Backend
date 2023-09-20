using FreshHeadBackend.Interfaces;
using FreshHeadBackend.Models;
using Microsoft.AspNetCore.Mvc;

namespace FreshHeadBackend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DealController : Controller
    {
        private readonly IDeal dealLogic;

        public DealController(IDeal dealLogic)
        {
            this.dealLogic = dealLogic;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Ok(dealLogic.GetAllDeals());
        }

    }
}

