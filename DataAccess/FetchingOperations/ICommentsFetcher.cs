using Shared_Library.ViewModels.Output;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.FetchingOperations
{
    public interface ICommentsFetcher
    {
        IEnumerable<CommentViewModel> GetCommentsByPostId(long id);
        IEnumerable<CommentViewModel> GetUnApproved();
        IEnumerable<CommentViewModel> GetReplyComments(long id);
    }
}
