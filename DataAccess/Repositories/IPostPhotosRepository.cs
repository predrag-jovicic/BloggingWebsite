using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repositories
{
    public interface IPostPhotosRepository
    {
        void Add(PostPhoto postPhoto);
        IEnumerable<PostPhoto> GetByPostId(long id);
        PostPhoto GetById(int id);
        void Delete(PostPhoto postPhoto);
    }
}
