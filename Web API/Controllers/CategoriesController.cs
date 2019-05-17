using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DataAccess;
using Shared_Library.ViewModels.Input;
using DataAccess.Models;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web_API.Controllers
{
    [Route("api/[controller]")]
    public class CategoriesController : Controller
    {
        UnitOfWork unitOfWork;
        public CategoriesController(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        

        [HttpGet]
        public IActionResult Get()
        {
            var categories = this.unitOfWork.CategoriesRepository.GetAll();
            return Ok(categories);
        }
        
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        [ActionName("CategoryPost")]
        public async Task<IActionResult> Post([FromBody]CategoryInput model)
        {
            if (ModelState.IsValid)
            {
                var category = this.unitOfWork.CategoriesRepository.GetByName(model.Name);
                if (category == null)
                {
                    category = new Category
                    {
                        Name = model.Name
                    };
                    this.unitOfWork.CategoriesRepository.Add(category);
                    await this.unitOfWork.Save();
                    return Created("CategoryPost", new { Id = category.CategoryId });
                }
                else
                {
                    ModelState.AddModelError("exists", "A category with the name you entered already exists");
                    return BadRequest(ModelState);
                }
            }
            else
                return BadRequest(ModelState);
        }

        [Authorize(Roles ="Administrator")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(short id, [FromBody]CategoryInput model)
        {
            if (ModelState.IsValid)
            {
                var category = this.unitOfWork.CategoriesRepository.GetById(id);
                if (category == null)
                    return NotFound();
                else
                {
                    category.Name = model.Name;
                    this.unitOfWork.CategoriesRepository.Update(category);
                    await this.unitOfWork.Save();
                    return NoContent();
                }
            }
            return BadRequest();
        }

        [Authorize(Roles="Administrator")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(short id)
        {
            var category = this.unitOfWork.CategoriesRepository.GetById(id);
            if (category == null)
                return NotFound();
            else
            {
                this.unitOfWork.CategoriesRepository.Delete(category);
                await this.unitOfWork.Save();
                return NoContent();
            }
        }
    }
}
