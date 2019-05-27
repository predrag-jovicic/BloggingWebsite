using System;
using System.Collections.Generic;
using System.Text;
using Application.Interfaces.Repositories;
using DataAccess;
using Domain;

namespace Implementations.Repositories
{
    public class PollAnswersRepository : IPollAnswersRepository
    {
        private BlogDbContext dbContext;
        public PollAnswersRepository(BlogDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void Add(PollAnswer pollAnswer)
        {
            this.dbContext.PollAnswers.Add(pollAnswer);
        }

        public void Delete(PollAnswer pollAnswer)
        {
            this.dbContext.PollAnswers.Remove(pollAnswer);
        }

        public PollAnswer GetById(int id)
        {
            return this.dbContext.PollAnswers.Find(id);
        }

        public void Update(PollAnswer pollAnswer)
        {
            this.dbContext.PollAnswers.Update(pollAnswer);
        }
    }
}
