using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;
using DataAccess.ViewModels.Input;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web_API.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private SignInManager<User> signInManager;
        private UserManager<User> userManager;
        private IConfiguration configuration;
        public UserController(SignInManager<User> signInManager, UserManager<User> userManager, IConfiguration configuration)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.configuration = configuration;
        }
        
        //Test controller
        [HttpGet]
        [Authorize(AuthenticationSchemes = "Bearer",Roles = "Administrator")]
        public string Get()
        {
            var user = User;
            return null;
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // This method is invoked by a SignIn method
        public IActionResult GetToken(ClaimsIdentity claimsIdentity)
        {
            var configReference = configuration.GetSection("JWT");
            var symmetricKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configReference["BaseKey"]));
            var credentials = new SigningCredentials(symmetricKey, SecurityAlgorithms.HmacSha256Signature);
            var tokenHander = new JwtSecurityTokenHandler();
            var token = tokenHander.CreateJwtSecurityToken(new SecurityTokenDescriptor {
                Issuer = configReference["Issuer"],
                Audience = configReference["Audience"],
                Expires = DateTime.Now.AddHours(3),
                SigningCredentials = credentials,
                Subject = claimsIdentity,
                IssuedAt = DateTime.Now
                });
            return Ok(new JwtSecurityTokenHandler().WriteToken(token));
        }

        [Route("register")]
        [HttpPost]
        public async Task<IActionResult> Register([FromBody]NewUserViewModel newUser)
        {
            if (ModelState.IsValid)
            {
                User user = new User
                {
                    FirstName = newUser.FirstName,
                    LastName = newUser.LastName,
                    Email = newUser.Email,
                    Biography = newUser.Biography,
                    UrlFacebook = newUser.UrlFacebook,
                    UrlLinkedIn = newUser.UrlLinkedIn,
                    UrlTwitter = newUser.UrlTwitter,
                    UserName = newUser.Username
                };
                var result = await this.userManager.CreateAsync(user, newUser.Password);
                if (result.Succeeded)
                {
                    result = await this.userManager.AddToRoleAsync(user, "blogger");
                    if (!result.Succeeded)
                        return null;
                    else
                        return StatusCode(500);
                }
                else
                    return StatusCode(500);
            }
            else
            {
                return BadRequest();
            }
        }

        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> SignIn(LogInViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByNameAsync(model.Username);
                if (user != null)
                {
                    var result = await signInManager.CheckPasswordSignInAsync(user, model.Password, false);
                    if (result.Succeeded)
                    {
                        string role = userManager.GetRolesAsync(user).Result.FirstOrDefault();
                        List<Claim> claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name,user.UserName),
                            new Claim(ClaimTypes.NameIdentifier,user.Id),
                            new Claim(ClaimTypes.Role,role)
                        };
                        ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims,"jwt");
                        return this.GetToken(claimsIdentity);
                    }
                    else
                    {
                        return Conflict();
                    }
                }
                else
                {
                    return NotFound();
                }
            }
            else
                return BadRequest();
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {

        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }
    }
}
