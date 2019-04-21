using DataAccess.Models;
using DataAccess.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.FetchingOperations
{
    public class PostsFetcher
    {
        private BlogDbContext context;
        private const int numberOfItemsPerPage = 10;
        public PostsFetcher(BlogDbContext context)
        {
            this.context = context;
        }

        private int NumberOfPostsToSkip(int? page)
        {
            if (page == null)
                return 0;
            else
            {
                return ((int)page - 1) * numberOfItemsPerPage;
            }
        }

        public IEnumerable<PostPreviewViewModel> GetRecentPostsPreview(int? page)
        {
            return this.context.Posts
                .OrderByDescending(p => p.PostedOn)
                .Skip(this.NumberOfPostsToSkip(page))
                .Take(numberOfItemsPerPage)
                .Select(p => new PostPreviewViewModel
                {
                    PostId = p.PostId,
                    Title = p.Title,
                    PartialText = p.Text.Substring(0, 100),
                    PostedOn = p.PostedOn,
                    AuthorFirstName = p.User.FirstName,
                    AuthorLastName = p.User.LastName,
                    UserId = p.User.Id,
                    ReadTime = p.ReadTime
                });
        }

        public IEnumerable<PostPreviewViewModel> GetRecentPostsPreviewByCategory(int? page, int categoryId)
        {
            return this.context.Posts
                .Where(p => p.CategoryId == categoryId)
                .OrderByDescending(p => p.PostedOn)
                .Skip(this.NumberOfPostsToSkip(page))
                .Take(numberOfItemsPerPage)
                .Select(p => new PostPreviewViewModel
                {
                    PostId = p.PostId,
                    Title = p.Title,
                    PartialText = p.Text.Substring(0, 100),
                    PostedOn = p.PostedOn,
                    AuthorFirstName = p.User.FirstName,
                    AuthorLastName = p.User.LastName,
                    UserId = p.User.Id,
                    ReadTime = p.ReadTime
                });
        }

        public IEnumerable<PostPreviewViewModel> GetRecentPostsPreviewByTag(int? page, int tagId)
        {
            return this.context.Posts
                .Where(p => p.PostTags.Any(pt => pt.TagId == tagId))
                .OrderByDescending(p => p.PostedOn)
                .Skip(this.NumberOfPostsToSkip(page))
                .Take(numberOfItemsPerPage)
                .Select(p => new PostPreviewViewModel
                {
                    PostId = p.PostId,
                    Title = p.Title,
                    PartialText = p.Text.Substring(0, 100),
                    PostedOn = p.PostedOn,
                    AuthorFirstName = p.User.FirstName,
                    AuthorLastName = p.User.LastName,
                    UserId = p.User.Id,
                    ReadTime = p.ReadTime
                });
        }

        public IEnumerable<RecommendedPostsViewModel> GetRecommendedPosts(long id)
        {
            //
        }

        public IEnumerable<PostPreviewViewModel> GetPostsByASearch(string example)
        {
            return this.context.Posts
                .Where(p => p.Text.Contains(example) || p.Title.Contains(example))
                .Select(p => new PostPreviewViewModel
                {
                    PostId = p.PostId,
                    Title = p.Title,
                    PartialText = p.Text.Substring(0, 100),
                    PostedOn = p.PostedOn,
                    AuthorFirstName = p.User.FirstName,
                    AuthorLastName = p.User.LastName,
                    UserId = p.User.Id,
                    ReadTime = p.ReadTime
                });
        }
    }
}
