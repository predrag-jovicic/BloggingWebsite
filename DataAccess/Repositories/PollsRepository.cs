using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class PollsRepository : IPollsRepository
    {
        private BlogDbContext dbContext;
        public PollsRepository(BlogDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void Add(Poll poll)
        {
            this.dbContext.Add(poll);
        }

        public void Delete(Poll poll)
        {
            this.dbContext.Remove(poll);
        }

        public Poll GetById(int id)
        {
            return this.dbContext.Polls.Find(id);
        }

        public IEnumerable<Poll> GetUserPolls(string userId)
        {
            return this.dbContext.Polls
                .Include(p => p.PollAnswers)
                .Where(p => p.UserId == userId);
        }
    }
}
