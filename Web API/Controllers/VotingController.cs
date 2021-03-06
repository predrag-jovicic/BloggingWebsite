﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.ViewModels.Input;
using DataAccess;
using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web_API.Controllers
{
    [Route("api/[controller]")]
    public class VotingController : Controller
    {
        private UserManager<User> userManager;
        private IUnitOfWork unitOfWork;
        public VotingController(IUnitOfWork unitOfWork, UserManager<User> userManager)
        {
            this.unitOfWork = unitOfWork;
            this.userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]NewVoteViewModel model)
        {
            var poll = this.unitOfWork.PollsRepository.GetById(model.PollId);
            if (poll == null)
                return BadRequest();
            string ipAddress = HttpContext.Connection.RemoteIpAddress.ToString();
            var flag = this.unitOfWork.VotesRepository.AlreadyVoted(ipAddress, model.PollId);
            if (flag)
                return Conflict();
            else
            {
                if (!poll.MultipleAnswers && model.VotedFor.Count > 1)
                    return BadRequest("You've chosen more than 1 option");
                VotingGroup votingGroup = new VotingGroup
                {
                    IpAddress = ipAddress,
                    DateTime = DateTime.Now,
                    PollId = model.PollId
                };
                this.unitOfWork.VotesRepository.AddVoteGroup(votingGroup);
                foreach (var id in model.VotedFor)
                {
                    Vote newVote = new Vote
                    {
                        PollAnswerId = id,
                        VotingGroupId = votingGroup.VotingGroupId,
                    };
                    this.unitOfWork.VotesRepository.AddVote(newVote);
                }
                await this.unitOfWork.Save();
                return StatusCode(201);
            }
        }
    }
}
