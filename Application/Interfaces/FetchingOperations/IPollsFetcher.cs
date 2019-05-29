using Application.ViewModels.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Interfaces.FetchingOperations
{
    public interface IPollsFetcher
    {
        IQueryable<PollViewModel> GetPollsByPostId(long id, string searchQuery, short numberOfItems, short pageNumber);
        IQueryable<PollViewModel> GetUserPolls(string id, string searchQuery, short numberOfItems, short pageNumber);
        PollViewModel GetPollById(int id);
        IEnumerable<PollRowVotesViewModel> GetPollResults(int id);
    }
}
