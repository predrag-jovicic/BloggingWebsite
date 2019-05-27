using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces.Repositories
{
    public interface IVotesRepository
    {
        bool AlreadyVoted(string userId, int pollId);
        void AddVote(Vote vote);
        void AddVoteGroup(VotingGroup votingGroup);
    }
}
