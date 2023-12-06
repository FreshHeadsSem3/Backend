using FreshHeadBackend.Models;
using FreshHeadBackend.Logic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using FreshHeadBackend.Interfaces;

namespace FreshHeadBackend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private IConfiguration _config;
        private ICompanyService companyService;
        public LoginController(IConfiguration config, ICompanyService _companyService)
        {
            _config = config;
            companyService = _companyService;
        }

        [HttpGet]
        public IActionResult GetCompanyByEmail(string email)
        {
            return Ok(companyService.GetCompanyByEmail(email));
        }

    
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            // Validate user credentials (example logic)
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data");

            }
            var company = companyService.GetCompanyByEmail(model.UserEmail);

            if (company == null)
            {
                return Unauthorized("Invalid credentials");
            }

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var Sectoken = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Audience"],
              claims: new List<Claim>
              {
                  new Claim(ClaimTypes.Role, "Company"),
                  new Claim(ClaimTypes.Name, "CompanyName"),
                  new Claim(ClaimTypes.NameIdentifier, company.ID.ToString())
              },
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            var token = new JwtSecurityTokenHandler().WriteToken(Sectoken);
            Response.Headers.Add("Content-Type", "text/plain");
            return Ok(token);
        }

    }
}
