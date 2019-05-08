using DataAccess.FetchingOperations;
using DataAccess.Models;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class UnitOfWork
    {
        public ICategoriesRepository CategoriesRepository { get; set; }
        public ICategoriesFetcher CategoriesFetcher { get; set; }
        public IPostsRepository PostsRepository { get; set; }
        public IPostsFetcher PostsFetcher { get; set; }
        public ITagsFetcher TagsFetcher { get; set; }
        public ICommentsFetcher CommentsFetcher { get; set; }
        public ICommentsRepository CommentsRepository { get; set; }
        public ITagsRepository TagsRepository { get; set; }
        private BlogDbContext context;
        public UnitOfWork(BlogDbContext context)
        {
            this.context = context;
            CategoriesRepository = new CategoriesRepository(context);
            CategoriesFetcher = new CategoriesFetcher(context);
            PostsRepository = new PostsRepository(context);
            PostsFetcher = new PostsFetcher(context);
            TagsFetcher = new TagsFetcher(context);
            TagsRepository = new TagsRepository(context);
            CommentsFetcher = new CommentsFetcher(context);
            CommentsRepository = new CommentsRepository(context);
        }

        public async Task Save()
        {
            await this.context.SaveChangesAsync();
        }
    }
}
