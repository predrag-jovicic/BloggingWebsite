using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess;
using DataAccess.Models;
using DataAccess.ViewModels.Input;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web_API.Controllers
{
    [Route("api/[controller]")]
    public class CommentsController : Controller
    {
        UnitOfWork unitOfWork;
        public CommentsController(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public async Task Post([FromBody]NewCommentViewModel model)
        {
            if (ModelState.IsValid)
            {
                Comment newComment = new Comment
                {
                    Approved = false,
                    PostedOn = DateTime.Now,
                    Text = model.Content,
                    PostId = model.PostId,
                    ReplyOnId = model.ReplyOnId,
                    UserName = model.Name,
                    UserId = model.UserId
                };
                this.unitOfWork.CommentsRepository.Add(newComment);
                await this.unitOfWork.Save();
            }
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
