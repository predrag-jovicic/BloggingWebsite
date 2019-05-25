using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repositories
{
    public interface IPollsRepository
    {
        Poll GetById(int id);
        PostPoll GetPostPollById(int id);
        void Add(Poll poll);
        void AddPollToPost(PostPoll postPoll);
        void Delete(Poll poll);
        void Update(Poll poll);
        void RemoveFromPost(PostPoll postPoll);
    }
}
