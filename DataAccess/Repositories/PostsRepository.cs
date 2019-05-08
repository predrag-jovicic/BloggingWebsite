using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repositories
{
    public class PostsRepository : IPostsRepository
    {
        BlogDbContext context;
        public PostsRepository(BlogDbContext context)
        {
            this.context = context;
        } 

        public Post GetById(long id)
        {
            return this.context.Posts.Find(id);
        }

        public void Add(Post post)
        {
            this.context.Add(post);
        }
    }
}
