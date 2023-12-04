﻿using AutoMapper;
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

        public CompanyController(ICompanyService companyService, IMapper mapper)
        {
            this.companyService = companyService;
            this.mapper = mapper;
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
