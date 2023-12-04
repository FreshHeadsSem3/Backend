using AutoMapper;
using FreshHeadBackend.Interfaces;
using FreshHeadBackend.Models;
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
            this.companyService = companyLogic;
            this.mapper = mapper;
            this.configuration = configuration;
        }

        [HttpGet]
        [Route("{ID}")]
        public IActionResult GetCompanyByID(Guid ID)
        {
            return Ok(companyService.GetCompanyByID(ID));
        }


        [HttpGet]
        public IActionResult GetCompanyByEmail(string email)
        {
            return Ok(companyService.GetCompanyByEmail(email));
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
        public IActionResult GetCompanies()
        {
            return Ok(companyService.GetCompanies());
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            // Validate user credentials (example logic)
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data");

            }
            var company = companyService.GetCompanyByEmail(model.Email);

            if (company == null)
            {
                return Unauthorized("Invalid credentials");
            }

            var token = GenerateJwtToken(model.Email, company.ID);

            // Invalid credentials
            return Ok(new { Token = token, ID = company.ID });
        }


        private string GenerateJwtToken(string email, Guid ID)
        {
            var secretKey = KeyProvider.GetSecretKey();
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
            new Claim(ClaimTypes.Name, email),
            new Claim(ClaimTypes.NameIdentifier, ID.ToString())
            // Voeg eventuele andere claims toe die je nodig hebt.
        };

            var token = new JwtSecurityToken(
                configuration["Jwt:Issuer"],
                configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(configuration["Jwt:ExpirationInMinutes"])),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
