using Application.Interfaces;
using Application.Interfaces.FetchingOperations;
using Application.Interfaces.Repositories;
using DataAccess;
using Implementations.Fetchers;
using Implementations.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Implementations.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public ICategoriesRepository CategoriesRepository { get; }
        public IPostsRepository PostsRepository { get; }
        public IPostsFetcher PostsFetcher { get; }
        public ICommentsFetcher CommentsFetcher { get; }
        public ICommentsRepository CommentsRepository { get; }
        public ITagsRepository TagsRepository { get; }
        public IPollsRepository PollsRepository { get; }
        public IPollAnswersRepository PollAnswersRepository { get; }
        public IPostPhotosRepository PostPhotosRepository { get; }
        public IPollsFetcher PollsFetcher { get; }
        public IVotesRepository VotesRepository { get; }

        private BlogDbContext context;

        public UnitOfWork(BlogDbContext context)
        {
            this.context = context;
            CategoriesRepository = new CategoriesRepository(context);
            PostsRepository = new PostsRepository(context);
            PostsFetcher = new PostsFetcher(context);
            TagsRepository = new TagsRepository(context);
            CommentsFetcher = new CommentsFetcher(context);
            CommentsRepository = new CommentsRepository(context);
            PollsRepository = new PollsRepository(context);
            PollAnswersRepository = new PollAnswersRepository(context);
            PostPhotosRepository = new PostPhotosRepository(context);
            PollsFetcher = new PollsFetcher(context);
            VotesRepository = new VotesRepository(context);
        }

        public async Task Save()
        {
            await this.context.SaveChangesAsync();
        }
    }
}
