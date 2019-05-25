using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repositories
{
    public interface IVotesRepository
    {
        bool AlreadyVoted(string userId, int pollId);
        void AddVote(Vote vote);
        void AddVoteGroup(VotingGroup votingGroup);
    }
}
