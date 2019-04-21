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
        public CategoriesRepository CategoriesRepository { get; set; }
        public CategoriesFetcher CategoriesFetcher { get; set; }
        public PostsRepository PostsRepository { get; set; }
        public PostsFetcher PostsFetcher { get; set; }
        public TagsFetcher TagsFetcher { get; set; }
        public CommentsFetcher CommentsFetcher { get; set; }
        public CommentsRepository CommentsRepository { get; set; }
        public TagsRepository TagsRepository { get; set; }
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
