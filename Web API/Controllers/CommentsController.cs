using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess;
using DataAccess.Models;
using Shared_Library.ViewModels.Input;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web_API.Controllers
{
    [Route("api/[controller]")]
    public class CommentsController : Controller
    {
        IUnitOfWork unitOfWork;
        public CommentsController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [Route("post/{id}"),HttpGet]
        public IActionResult GetCommentsByPostId(long id)
        {
            return Ok(this.unitOfWork.CommentsFetcher.GetCommentsByPostId(id));
        }

        [Authorize(Roles = "Moderator")]
        [Route("/unapproved")]
        public IActionResult GetUnApprovedComments()
        {
            return Ok(this.unitOfWork.CommentsFetcher.GetUnApproved());
        }

        [Authorize(Roles = "Moderator")]
        [Route("/approve/{id}")]
        [HttpPatch]
        public async Task<IActionResult> ApproveComment(long id)
        {
            Comment comment = this.unitOfWork.CommentsRepository.GetById(id);
            if (comment == null)
                return NotFound();
            else
            {
                this.unitOfWork.CommentsRepository.ApproveComment(comment);
                await this.unitOfWork.Save();
                return NoContent();
            }
        }
        
        [HttpPost]
        [ActionName("CommentPost")]
        public async Task<IActionResult> Post([FromBody]NewCommentViewModel model)
        {
            if (ModelState.IsValid)
            {
                Comment newComment = new Comment();
                if (User.Identity.IsAuthenticated)
                {
                    newComment = new Comment
                    {
                        Approved = false,
                        PostedOn = DateTime.Now,
                        Text = model.Content,
                        PostId = model.PostId,
                        ReplyOnId = model.ReplyOnId,
                        UserId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value
                    };
                }
                else
                {
                    if (model.Name == null)
                        return BadRequest();
                    newComment = new Comment
                    {
                        Approved = false,
                        PostedOn = DateTime.Now,
                        Text = model.Content,
                        PostId = model.PostId,
                        ReplyOnId = model.ReplyOnId,
                        UserName = model.Name
                    };
                }
                this.unitOfWork.CommentsRepository.Add(newComment);
                await this.unitOfWork.Save();
                return CreatedAtAction("CommentPost", new { id = newComment.CommentId });
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Moderator")]
        public async Task<IActionResult> Delete(long id)
        {
            Comment comment = this.unitOfWork.CommentsRepository.GetById(id);
            if (comment != null)
            {
                this.unitOfWork.CommentsRepository.Delete(comment);
                await this.unitOfWork.Save();
                return NoContent();
            }
            else
                return NotFound();
        }
    }
}
