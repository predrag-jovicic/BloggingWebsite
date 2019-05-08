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
    }
}
