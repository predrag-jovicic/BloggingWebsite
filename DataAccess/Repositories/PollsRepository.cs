using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Models;

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
    }
}
