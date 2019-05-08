using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repositories
{
    public interface ICommentsRepository
    {
        IEnumerable<Comment> GetAll();
        void Add(Comment comment);
        Comment GetById(long id);
        void ApproveComment(Comment comment);
        void Delete(Comment comment);
    }
}
