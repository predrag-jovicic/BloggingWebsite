using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application.ViewModels.Output;
using Application.Interfaces.FetchingOperations;
using DataAccess;
using Domain;

namespace Implementations.Fetchers
{
    public class CommentsFetcher : ICommentsFetcher
    {
        BlogDbContext context;
        public CommentsFetcher(BlogDbContext context)
        {
            this.context = context;
        }

        public IQueryable<CommentViewModel> GetCommentsByPostId(long id, string searchQuery, short numberOfItems, short pageNumber)
        {
            var query = this.context.Comments.AsQueryable();
            if (searchQuery != null)
            {
                searchQuery = searchQuery.ToLower();
                query = query.Where(c => c.Text.ToLower().Contains(searchQuery));
            }
            return query
                .Where(c => c.PostId == id && c.Approved == true && c.ReplyOnId == null)
                .Select(c => new CommentViewModel
                {
                    CommentId = c.CommentId,
                    Text = c.Text,
                    PostedOn = c.PostedOn,
                    AuthorName = c.UserName ?? c.User.FirstName + " " + c.User.LastName,
                    AuthorPhoto = c.User.Photo.Source,
                    Replies = this.GetReplyComments(c.CommentId)
                })
                .Skip((pageNumber - 1) * numberOfItems)
                .Take(numberOfItems);
        }

        public IEnumerable<CommentViewModel> GetUnApproved(string searchQuery, short numberOfItems, short pageNumber)
        {
            var query = this.context.Comments.AsQueryable();
            if(searchQuery != null)
            {
                searchQuery = searchQuery.ToLower();
                query = query.Where(c => c.Text.ToLower().Contains(searchQuery));
            }
            return query
                .Where(c => c.Approved == false)
                .Skip((pageNumber-1)*numberOfItems)
                .Take(numberOfItems)
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

        public IQueryable<CommentViewModel> GetReplyComments(long id)
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
                    Replies = this.GetReplyComments(c.CommentId)
                });
        }
    }
}
