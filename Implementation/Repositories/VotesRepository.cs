using Application.Interfaces.Repositories;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementations.Repositories
{
    public class VotesRepository : IVotesRepository
    {
        BlogDbContext dbContext;
        public VotesRepository(BlogDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void AddVote(Vote vote)
        {
            this.dbContext.Votes.Add(vote);
        }

        public void AddVoteGroup(VotingGroup votingGroup)
        {
            this.dbContext.VotingGroups.Add(votingGroup);
        }

        public bool AlreadyVoted(string ipAddress, int pollId)
        {
            return this.dbContext.VotingGroups.Any(v => v.IpAddress == ipAddress && v.PollId == pollId);
        }
    }
}
