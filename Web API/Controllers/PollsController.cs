using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess;
using DataAccess.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shared_Library.ViewModels.Input;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web_API.Controllers
{
    [Route("api/[controller]")]
    public class PollsController : Controller
    {
        private UserManager<User> userManager;
        private IUnitOfWork unitOfWork;
        public PollsController(UserManager<User> userManager, IUnitOfWork unitOfWork)
        {
            this.userManager = userManager;
            this.unitOfWork = unitOfWork;
        }
        // GET: api/<controller>
        [HttpGet]
        [ActionName("GetPoll")]
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
        [Authorize(Roles = "Blogger")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]NewPollViewModel model)
        {
            var userId = this.userManager.GetUserId(User);
            if (ModelState.IsValid)
            {
                Poll newPoll = new Poll
                {
                    Question = model.Question,
                    Active = true,
                    ActiveUntil = model.ActiveUntil,
                    MultipleAnswers = model.MultipleAnswers,
                    UserId = userId
                };
                this.unitOfWork.PollsRepository.Add(newPoll);
                foreach(var answer in model.Answers)
                {
                    PollAnswer newAnswer = new PollAnswer
                    {
                        Name = answer,
                        PollId = newPoll.PollId,
                    };
                    this.unitOfWork.PollAnswersRepository.Add(newAnswer);
                }
                await this.unitOfWork.Save();
                return CreatedAtAction("GetPoll", new { id = newPoll.PollId });
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
        [Authorize(Roles = "Blogger")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var poll = this.unitOfWork.PollsRepository.GetById(id);
            if (poll == null)
                return BadRequest();
            else
            {
                var userId = this.userManager.GetUserId(User);
                if (userId != poll.UserId)
                    return Forbid();
                else
                {
                    this.unitOfWork.PollsRepository.Delete(poll);
                    await this.unitOfWork.Save();
                    return NoContent();
                }
            }
        }
    }
}
