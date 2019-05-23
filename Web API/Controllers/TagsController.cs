using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess;
using DataAccess.Models;
using Microsoft.AspNetCore.Authorization;
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

        [HttpGet]
        [Route("popular")]
        public IActionResult GetPopularTags()
        {
            var tags = this.unitOfWork.TagsRepository.GetPopularTags();
            return Ok(tags);
        }

        [HttpGet("post/{id}")]
        public IActionResult GetPostTags(long id)
        {
            var tags = this.unitOfWork.TagsRepository.GetTagsByPostId(id);
            return Ok(tags);
        }

        [HttpDelete("posttag")]
        public async Task<IActionResult> DeletePostTag(PostTagDeletionViewModel model)
        {
            if (ModelState.IsValid)
            {
                var postTag = this.unitOfWork.TagsRepository.GetPostTag(model.PostId, model.TagId);
                if (postTag == null)
                    return NotFound();
                else
                {
                    this.unitOfWork.PostsRepository.DeletePostTag(postTag);
                    await this.unitOfWork.Save();
                    return NoContent();
                }
            }
            else
                return BadRequest();
        }

        [Authorize(Roles = "Administrator")]
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

        
        [Authorize(Roles = "Administrator")]
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
