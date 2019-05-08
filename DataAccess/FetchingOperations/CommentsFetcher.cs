using DataAccess.Models;
using Shared_Library.ViewModels.Output;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.FetchingOperations
{
    public class CommentsFetcher : ICommentsFetcher
    {
        BlogDbContext context;
        public CommentsFetcher(BlogDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<CommentViewModel> GetCommentsByPostId(long id)
        {
            return this.context.Comments
                .Where(c => c.PostId == id && c.Approved == true)
                .Select(c => new CommentViewModel
                {
                    CommentId = c.CommentId,
                    Text = c.Text,
                    PostedOn = c.PostedOn,
                    AuthorName = c.UserName ?? c.User.FirstName + " " + c.User.LastName,
                    AuthorPhoto = c.User.Photo.Source,
                    Replies = GetReplyComments(c.CommentId)
                });
        }

        public IEnumerable<CommentViewModel> GetUnApproved()
        {
            return this.context.Comments
                .Where(c => c.Approved == false)
                .Select(c => new CommentViewModel
                {
                    CommentId = c.CommentId,
                    Text = c.Text,
                    PostedOn = c.PostedOn,
                    AuthorName = c.UserName ?? c.User.FirstName + " " + c.User.LastName,
                    AuthorPhoto = c.User.Photo.Source,
                    Replies = null
                });
        }

        public IEnumerable<CommentViewModel> GetReplyComments(long id)
        {
            return this.context.Comments
                .Where(c => c.ReplyOnId == id && c.Approved == true)
                .Select(c => new CommentViewModel
                {
                    CommentId = c.CommentId,
                    Text = c.Text,
                    PostedOn = c.PostedOn,
                    AuthorName = c.UserName ?? c.User.FirstName + " " + c.User.LastName,
                    AuthorPhoto = c.User.Photo.Source,
                    Replies = this.GetReplyComments(id)
                });
        }
    }
}
