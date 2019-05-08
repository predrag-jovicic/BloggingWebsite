using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repositories
{
    public interface IPostsRepository
    {
        Post GetById(long id);
        void Add(Post post);
        void AddPostTag(PostTag postTag);
        void Update(Post post);
        void Delete(Post post);
    }
}
