using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Shared_Library.ViewModels.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.FetchingOperations
{
    public class PollsFetcher : IPollsFetcher
    {
        private BlogDbContext dbContext;
        public PollsFetcher(BlogDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public PollViewModel GetPollById(int id)
        {
            return this.dbContext.Polls
                .Include(p => p.PollAnswers)
                .Select(p => new PollViewModel
                {
                    PollId = p.PollId,
                    Active = p.Active,
                    ActiveUntil = p.ActiveUntil,
                    Question = p.Question,
                    MultipleAnswers = p.MultipleAnswers,
                    Answers = GetPollAnswersByPollId(p.PollId)
                })
                .SingleOrDefault(p => p.PollId == id);
        }

        public IEnumerable<PollRowVotesViewModel> GetPollResults(int id)
        {
            return this.dbContext.PollAnswers
                .Where(p => p.PollId == id)
                .Select(p => new PollRowVotesViewModel
                {
                    Name = p.Name,
                    NumberOfVotes = p.Votes.Count
                });
        }

        public IQueryable<PollViewModel> GetPollsByPostId(long id)
        {
            return this.dbContext.PostPolls
                .Where(p => p.PostId == id)
                .Include(p => p.Poll)
                .ThenInclude(p => p.PollAnswers)
                .Select(p => new PollViewModel
                {
                    PollId = p.PollId,
                    Active = p.Poll.Active,
                    ActiveUntil = p.Poll.ActiveUntil,
                    Question = p.Poll.Question,
                    MultipleAnswers = p.Poll.MultipleAnswers,
                    Answers = GetPollAnswersByPollId(p.PollId)
                });
        }

        public IQueryable<PollViewModel> GetUserPolls(string id)
        {
            return this.dbContext.Polls
                .Where(p => p.UserId == id)
                .Include(p => p.PollAnswers)
                .Select(p => new PollViewModel
                {
                    PollId = p.PollId,
                    Active = p.Active,
                    ActiveUntil = p.ActiveUntil,
                    Question = p.Question,
                    MultipleAnswers = p.MultipleAnswers,
                    Answers = GetPollAnswersByPollId(p.PollId)
                });
        }

        private IQueryable<PollAnswerViewModel> GetPollAnswersByPollId(int id)
        {
            return this.dbContext.PollAnswers
                .Where(p => p.PollId == id)
                .Select(p => new PollAnswerViewModel
                {
                    PollAnswerId = p.PollAnswerId,
                    Name = p.Name
                });
        }
    }
}
