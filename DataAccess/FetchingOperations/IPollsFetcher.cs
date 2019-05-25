using DataAccess.Models;
using Shared_Library.ViewModels.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.FetchingOperations
{
    public interface IPollsFetcher
    {
        IQueryable<PollViewModel> GetPollsByPostId(long id);
        IQueryable<PollViewModel> GetUserPolls(string id);
        PollViewModel GetPollById(int id);
        IEnumerable<PollRowVotesViewModel> GetPollResults(int id);
    }
}
