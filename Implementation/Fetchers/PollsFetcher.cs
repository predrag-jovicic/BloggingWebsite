using Application.Interfaces.FetchingOperations;
using Application.ViewModels.Output;
using DataAccess;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementations.Fetchers
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

        public IQueryable<PollViewModel> GetPollsByPostId(long id, string searchQuery, short numberOfItems, short pageNumber)
        {
            IQueryable<PostPoll> query = this.dbContext.PostPolls
            .Where(p => p.PostId == id)
            .Include(p => p.Poll)
            .ThenInclude(p => p.PollAnswers);

            if (searchQuery != null)
            {
                searchQuery = searchQuery.ToLower();
                query = query.Where(p => p.Poll.Question.ToLower().Contains(searchQuery));
            }

            return query.Skip((pageNumber-1)*numberOfItems)
            .Take(numberOfItems)
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

        public IQueryable<PollViewModel> GetUserPolls(string id, string searchQuery, short numberOfItems, short pageNumber)
        {
            IQueryable<Poll> query = this.dbContext.Polls;
            if(searchQuery != null)
            {
                searchQuery = searchQuery.ToLower();
                query = query.Where(p => p.Question.ToLower().Contains(searchQuery));
            }
            return query
                .Where(p => p.UserId == id)
                .Include(p => p.PollAnswers)
                .Skip((pageNumber-1)*numberOfItems)
                .Take(numberOfItems)
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
