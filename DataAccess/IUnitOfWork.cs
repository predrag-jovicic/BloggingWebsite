using DataAccess.FetchingOperations;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IUnitOfWork
    {
        ICategoriesRepository CategoriesRepository { get; }
        IPostsRepository PostsRepository { get; }
        IPostsFetcher PostsFetcher { get; }
        ICommentsFetcher CommentsFetcher { get; }
        ICommentsRepository CommentsRepository { get; }
        ITagsRepository TagsRepository { get; }
        IPollsRepository PollsRepository { get; }
        IPollAnswersRepository PollAnswersRepository { get; }
        IPostPhotosRepository PostPhotosRepository { get; }
        IPollsFetcher PollsFetcher { get; }
        IVotesRepository VotesRepository { get; }
        Task Save();
    }
}
