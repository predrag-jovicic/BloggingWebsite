using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;
using Shared_Library.ViewModels.Input;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Shared_Library.ViewModels.Output;

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
        
        //Test controller - it works
        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public IActionResult Get()
        {
            var users = this.userManager.Users;
            return Ok(users);
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var user = await this.userManager.FindByIdAsync(id);
            if (user == null)
                return NotFound();
            else
            {
                var vm = new UserViewModel
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Username = user.UserName,
                    Biography = user.Biography,
                    UrlFacebook = user.UrlFacebook,
                    UrlLinkedIn = user.UrlLinkedIn,
                    UrlTwitter = user.UrlTwitter,
                };
                return Ok(vm);
            }
        }

        [HttpGet]
        [Route("checkusernameavailability/{name}")]
        public IActionResult DoesExist(string name)
        {
            var user = this.userManager.FindByNameAsync(name).Result;
            if (user == null)
                return Ok(true);
            else
                return Ok(false);
        }

        // This method is invoked by a SignIn method
        private IActionResult GetToken(ClaimsIdentity claimsIdentity)
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
                    result = await this.userManager.AddToRoleAsync(user, "Blogger");
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

        //I don't have a logout method because it's not required to have one. If a user logs out, it's gonna delete the jwt token on the client.
        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> SignIn(LogInViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByNameAsync(model.Username);
                if (user != null)
                {
                    if (await this.userManager.IsLockedOutAsync(user))
                    {
                        ModelState.AddModelError("userbanned", "Your account has been disabled by an administrator.");
                        return Conflict(ModelState);
                    }
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
                        ModelState.AddModelError("wrongpass", "The password you entered is incorrect");
                        return Conflict(ModelState);
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
        [HttpPatch("editpersonaldata/{id}")]
        [Authorize(Roles = "Blogger")]
        public async Task<IActionResult> EditPersonalData(string id, [FromBody]EditUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                string userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
                if (id != userId)
                    return Forbid();
                else
                {
                    var user = await userManager.GetUserAsync(User);
                    if (user == null)
                        return BadRequest();
                    user.FirstName = user.FirstName;
                    user.LastName = user.LastName;
                    user.Biography = user.Biography;
                    user.UrlFacebook = user.UrlFacebook;
                    user.UrlLinkedIn = user.UrlLinkedIn;
                    user.UrlTwitter = user.UrlTwitter;
                    await this.userManager.UpdateAsync(user);
                    return NoContent();
                }
            }
            else
                return BadRequest();
        }

        [HttpPatch("changepassword/{id}")]
        [Authorize]
        public async Task<IActionResult> ChangePassword(string id, ChangePasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                string userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
                if (userId != id)
                    return Forbid();
                else
                {
                    var user = await this.userManager.GetUserAsync(User);
                    if (user == null)
                        return BadRequest();
                    var result = await this.userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
                    if (result.Succeeded)
                        return NoContent();
                    else
                        return Conflict();
                }
            }
            else
                return BadRequest();
        }
        
        [Authorize(Roles = "Administrator")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            User user = await this.userManager.FindByIdAsync(id);
            if (user == null)
                return BadRequest();
            var result = await this.userManager.DeleteAsync(user);
            if (result.Succeeded)
                return NoContent();
            else
                return StatusCode(500);
        }

        [Authorize(Roles = "Administrator")]
        [HttpPatch("ban/{id}")]
        public async Task<IActionResult> BanUser(string id)
        {
            User user = await this.userManager.FindByIdAsync(id);
            if (user == null)
                return BadRequest();
            var result = await this.userManager.SetLockoutEnabledAsync(user, true);
            if (result.Succeeded)
            {
                return NoContent();
            }
            else
                return StatusCode(500);
        }
    }
}
