using Application.ViewModels.Output;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces.FetchingOperations
{
    public interface IPostsFetcher
    {
        PostViewModel GetPostByPostId(long id);
        IEnumerable<PostPreviewViewModel> GetRecentPostsPreview(int? page);
        IEnumerable<PostPreviewViewModel> GetRecentPostsPreviewByCategory(int? page, int categoryId);
        IEnumerable<PostPreviewViewModel> GetRecentPostsPreviewByTag(int? page, int tagId);
        IEnumerable<RecommendedPostsViewModel> GetRecommendedPosts(long id);
        IEnumerable<PostPreviewViewModel> GetPostsByASearch(string example);
    }
}
