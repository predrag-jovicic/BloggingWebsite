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
            this.context.Posts.Add(post);
        }

        public void Update(Post post)
        {
            this.context.Posts.Update(post);
        }

        public void AddPostTag(PostTag postTag)
        {
            this.context.PostTags.Add(postTag);
        }

        public void Delete(Post post)
        {
            this.context.Posts.Remove(post);
        }
    }
}
