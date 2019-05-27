using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces.Repositories
{
    public interface IPostsRepository
    {
        Post GetById(long id);
        void Add(Post post);
        void Update(Post post);
        void Delete(Post post);
        void AddPostTag(PostTag postTag);
        void DeletePostTag(PostTag postTag);
        bool HasTag(long postId, short tagId);
    }
}
