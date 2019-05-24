using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repositories
{
    public interface IPollsRepository
    {
        Poll GetById(int id);
        void Add(Poll poll);
        void Delete(Poll poll);
        IEnumerable<Poll> GetUserPolls(string userId);
    }
}
