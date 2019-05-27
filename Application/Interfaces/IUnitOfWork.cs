using Application.Interfaces.FetchingOperations;
using Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
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
