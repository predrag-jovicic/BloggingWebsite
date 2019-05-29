using Application.ViewModels.Output;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces.FetchingOperations
{
    public interface IPostsFetcher
    {
        PostViewModel GetPostByPostId(long id);
        IEnumerable<PostPreviewViewModel> GetRecentPostsPreview(string searchQuery, int? category, int? tag, short numberOfItems, short pageNumber);
        IEnumerable<RecommendedPostsViewModel> GetRecommendedPosts(long id);
    }
}
