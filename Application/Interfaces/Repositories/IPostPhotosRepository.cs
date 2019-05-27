using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces.Repositories
{
    public interface IPostPhotosRepository
    {
        void Add(PostPhoto postPhoto);
        IEnumerable<PostPhoto> GetByPostId(long id);
        PostPhoto GetById(int id);
        void Delete(PostPhoto postPhoto);
    }
}
