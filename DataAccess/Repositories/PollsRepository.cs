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

        public void AddPollToPost(PostPoll postPoll)
        {
            this.dbContext.PostPolls.Add(postPoll);
        }

        public void Delete(Poll poll)
        {
            this.dbContext.Remove(poll);
        }

        public Poll GetById(int id)
        {
            return this.dbContext.Polls.Find(id);
        }

        public PostPoll GetPostPollById(int id)
        {
            return this.dbContext.PostPolls.Find(id);
        }
        public void RemoveFromPost(PostPoll postPoll)
        {
            this.dbContext.PostPolls.Remove(postPoll);
        }

        public void Update(Poll poll)
        {
            this.dbContext.Polls.Update(poll);
        }
    }
}
