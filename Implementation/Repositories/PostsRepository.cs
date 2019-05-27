using Application.Interfaces.Repositories;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementations.Repositories
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

        public void Delete(Post post)
        {
            this.context.Posts.Remove(post);
        }

        public bool HasTag(long postId, short tagId)
        {
            return this.context.PostTags
                .Any(pt => pt.TagId == tagId && pt.PostId == postId);
        }

        public void AddPostTag(PostTag postTag)
        {
            this.context.PostTags.Add(postTag);
        }

        public void DeletePostTag(PostTag postTag)
        {
            this.context.PostTags.Remove(postTag);
        }
    }
}
