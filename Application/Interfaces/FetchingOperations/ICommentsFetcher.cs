using Application.ViewModels.Output;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces.FetchingOperations
{
    public interface ICommentsFetcher
    {
        IEnumerable<CommentViewModel> GetCommentsByPostId(long id);
        IEnumerable<CommentViewModel> GetUnApproved();
        IEnumerable<CommentViewModel> GetReplyComments(long id);
    }
}
