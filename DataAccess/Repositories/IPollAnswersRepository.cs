using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repositories
{
    public interface IPollAnswersRepository
    {
        void Add(PollAnswer pollAnswer);
    }
}
