using Application.Interfaces.FetchingOperations;
using Application.ViewModels.Output;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementations.Fetchers
{
    public class PostsFetcher : IPostsFetcher
    {
        private BlogDbContext context;
        private const int numberOfItemsPerPage = 10;
        public PostsFetcher(BlogDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<PostPreviewViewModel> GetRecentPostsPreview(string searchQuery, int? category, int? tag, short numberOfItems, short pageNumber)
        {
            var query = this.context.Posts.AsQueryable();
            if (searchQuery != null)
            {
                searchQuery = searchQuery.ToLower();
                query = query.Where(p => p.Title.ToLower().Contains(searchQuery) || p.Text.ToLower().Contains(searchQuery));
            }
            if(tag != null)
                query = query.Where(p => p.PostTags.Any(t => t.TagId == tag));
            if(category != null)
                query = query.Where(p => p.CategoryId == category);
            return query
                .OrderByDescending(p => p.PostedOn)
                .Skip((pageNumber - 1)*numberOfItems)
                .Take(numberOfItems)
                .Select(p => new PostPreviewViewModel
                {
                    PostId = p.PostId,
                    Title = p.Title,
                    PartialText = p.Text.Substring(0, 150) + "...",
                    PostedOn = p.PostedOn,
                    AuthorFirstName = p.User.FirstName,
                    AuthorLastName = p.User.LastName,
                    UserId = p.User.Id,
                    ReadTime = p.ReadTime
                });
        }

        public IEnumerable<RecommendedPostsViewModel> GetRecommendedPosts(long id)
        {
            return this.context.Posts.FromSql("SELECT DISTINCT TOP(4) p.PostId, Title, NumberOfViews FROM Posts p INNER JOIN PostTags pt ON p.PostId = pt.PostId WHERE pt.TagId IN(SELECT TagId FROM PostTags WHERE PostId = {0}) AND p.PostId <> {0} ORDER BY p.NumberOfViews", id).Select(p => new RecommendedPostsViewModel
                {
                    PostId = p.PostId,
                    Title = p.Title
                }).ToList();
        }

        public PostViewModel GetPostByPostId(long id)
        {
               var p = this.context.Posts
               .Include(post => post.User)
               .SingleOrDefault(post => post.PostId == id);
            if (p != null)
                return new PostViewModel
                {
                    PostId = p.PostId,
                    Title = p.Title,
                    UserId = p.UserId,
                    ReadTime = p.ReadTime,
                    Text = p.Text,
                    PostedOn = p.PostedOn,
                    NumberOfViews = p.NumberOfViews,
                    AuthorLastName = p.User.LastName,
                    AuthorFirstName = p.User.FirstName,
                    AuthorBiography = p.User.Biography
                };
            else return null;
        }
    }
}
