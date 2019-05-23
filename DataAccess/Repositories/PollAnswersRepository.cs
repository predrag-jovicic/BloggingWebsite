using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Models;

namespace DataAccess.Repositories
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
    }
}
