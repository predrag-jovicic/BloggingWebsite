using DataAccess.FetchingOperations;
using DataAccess.Models;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class UnitOfWork
    {
        public CategoriesRepository CategoriesRepository { get; set; }
        public CategoriesFetcher CategoriesFetcher { get; set; }
        public PostsRepository PostsRepository { get; set; }
        public PostsFetcher PostsFetcher { get; set; }
        public TagsFetcher TagsFetcher { get; set; }
        public UnitOfWork(BlogDbContext context)
        {
            CategoriesRepository = new CategoriesRepository(context);
            CategoriesFetcher = new CategoriesFetcher(context);
            PostsRepository = new PostsRepository(context);
            PostsFetcher = new PostsFetcher(context);
            TagsFetcher = new TagsFetcher(context);
        }
    }
}
