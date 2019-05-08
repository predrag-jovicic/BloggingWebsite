using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Shared_Library.ViewModels.Input;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web_API.Controllers
{
    [Route("api/[controller]")]
    public class TagsController : Controller
    {
        private UnitOfWork unitOfWork;
        public TagsController(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        // GET: api/<controller>
        [HttpGet]
        [Route("populartags")]
        public IActionResult GetPopularTags()
        {
            var tags = this.unitOfWork.TagsFetcher.GetPopularTags();
            return Ok(tags);
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        [ActionName("TagPost")]
        public async Task<IActionResult> Post([FromBody]TagInput model)
        {
            if (ModelState.IsValid)
            {
                if (this.unitOfWork.TagsRepository.GetByName(model.Name) != null)
                {
                    ModelState.AddModelError("exists", "A tag with the name you entered already exists");
                    return BadRequest(ModelState);
                }
                else
                {
                    Tag tag = new Tag
                    {
                        Name = model.Name
                    };
                    this.unitOfWork.TagsRepository.Add(tag);
                    await this.unitOfWork.Save();
                    return CreatedAtAction("TagPost", new { Id = tag.TagId });
                }
            }
            else
                return BadRequest(ModelState);
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(short id, [FromBody]TagInput model)
        {
            if (ModelState.IsValid)
            {
                var tag = this.unitOfWork.TagsRepository.GetById(id);
                if (tag == null)
                    return NotFound();
                else
                {
                    tag.Name = model.Name;
                    this.unitOfWork.TagsRepository.Update(tag);
                    await this.unitOfWork.Save();
                    return NoContent();
                }
            }
            else
                return BadRequest();
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(short id)
        {
            var tag = this.unitOfWork.TagsRepository.GetById(id);
            if (tag == null)
                return NotFound();
            else
            {
                this.unitOfWork.TagsRepository.Delete(tag);
                await this.unitOfWork.Save();
                return NoContent();
            }
        }
    }
}
