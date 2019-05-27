using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.ViewModels.Output;
using DataAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web_API.Controllers
{
    [Route("api/[controller]")]
    public class RolesController : Controller
    {
        private RoleManager<IdentityRole> roleManager;
        public RolesController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }

        [Authorize(Roles = "Administrator")]
        [HttpGet]
        public IActionResult Get()
        {
            var roles = this.roleManager.Roles;
            var vm = roles.Select(r => new RoleViewModel
            {
                RoleId = r.Id,
                Name = r.Name
            });
            return Ok(vm);
        }

        [Authorize(Roles = "Administrator")]
        [HttpGet("{id}")]
        [ActionName("GetRole")]
        public async Task<IActionResult> Get(string id)
        {
            var role = await this.roleManager.FindByIdAsync(id);
            if (role == null)
                return NotFound();
            else
            {
                var vm = new RoleViewModel
                {
                    RoleId = role.Id,
                    Name = role.Name
                };
                return Ok(vm);
            }
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]string value)
        {
            IdentityRole role = new IdentityRole
            {
                Name = value
            };
            await this.roleManager.CreateAsync(role);
            return CreatedAtAction("GetRole", new { id = role.Id });
        }

        [Authorize(Roles = "Administrator")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody]RoleViewModel vm)
        {
            IdentityRole role = new IdentityRole
            {
                Name = vm.Name
            };
            await this.roleManager.UpdateAsync(role);
            return NoContent();
        }

        [Authorize(Roles = "Administrator")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var role = await this.roleManager.FindByIdAsync(id);
            if(role == null)
            {
                return NotFound();
            }
            else
            {
                var result = await this.roleManager.DeleteAsync(role);
                if (result.Succeeded)
                {
                    return NoContent();
                }
                else
                {
                    return StatusCode(500);
                }
            }
        }
    }
}
