using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Shared_Library.ValidationAttributes;
using Shared_Library.ViewModels.Input;
using Shared_Library.ViewModels.Output;

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

        [HttpGet]
        [ActionName("GetPollAnswer")]
        public IActionResult Get(int id)
        {
            var pollAnswer = this.unitOfWork.PollAnswersRepository.GetById(id);
            if (pollAnswer == null)
                return NotFound();
            else
                return Ok(pollAnswer);
        }

        [HttpPost]
        public async Task<IActionResult> Post(NewPollAnswerViewModel model)
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

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]PollAnswerViewModel model)
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
