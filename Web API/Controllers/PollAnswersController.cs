using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.ViewModels.Input;
using Application.ViewModels.Output;
using DataAccess;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web_API.Controllers
{
    [Route("api/[controller]")]
    public class PollAnswersController : Controller
    {
        private IUnitOfWork unitOfWork;
        public PollAnswersController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [ActionName("GetPollAnswer")]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var pollAnswer = this.unitOfWork.PollAnswersRepository.GetById(id);
            if (pollAnswer == null)
                return NotFound();
            else
                return Ok(pollAnswer);
        }

        [Authorize(Roles = "Blogger")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]NewPollAnswerViewModel model)
        {
            if (ModelState.IsValid)
            {
                var newPollAnswer = new PollAnswer { Name = model.Name, PollId = model.PollId };
                this.unitOfWork.PollAnswersRepository.Add(newPollAnswer);
                await this.unitOfWork.Save();
                return CreatedAtAction("GetPollAnswer", new { id = newPollAnswer.PollAnswerId });
            }
            else
                return UnprocessableEntity();
        }

        [Authorize(Roles = "Blogger")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]PollAnswerViewModel model)
        {
            if (ModelState.IsValid)
            {
                var pollAnswer = this.unitOfWork.PollAnswersRepository.GetById(id);
                if (pollAnswer == null)
                    return BadRequest();
                else
                {
                    pollAnswer.Name = model.Name;
                    this.unitOfWork.PollAnswersRepository.Update(pollAnswer);
                    await this.unitOfWork.Save();
                    return NoContent();
                }
            }
            else
                return Unauthorized();
        }

        [Authorize(Roles = "Blogger")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var pollAnswer = this.unitOfWork.PollAnswersRepository.GetById(id);
            if (pollAnswer == null)
                return BadRequest();
            else
            {
                this.unitOfWork.PollAnswersRepository.Delete(pollAnswer);
                await this.unitOfWork.Save();
                return NoContent();
            }
        }
    }
}
