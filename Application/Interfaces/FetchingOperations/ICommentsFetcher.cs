using Application.ViewModels.Output;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Interfaces.FetchingOperations
{
    public interface ICommentsFetcher
    {
        IQueryable<CommentViewModel> GetCommentsByPostId(long id, string searchQuery, short numberOfItems, short pageNumber);
        IEnumerable<CommentViewModel> GetUnApproved(string searchQuery, short numberOfItems, short pageNumber);
        IQueryable<CommentViewModel> GetReplyComments(long id);
    }
}
