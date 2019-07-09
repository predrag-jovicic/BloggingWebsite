using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces.Repositories
{
    public interface ICommentsRepository
    {
        IEnumerable<Comment> GetAll();
        void Add(Comment comment);
        Comment GetById(long id);
        void ApproveComment(Comment comment);
        IEnumerable<Comment> GetCommentsByPostId(long postId);
        void Delete(Comment comment);
        void Delete(IEnumerable<Comment> comments);
    }
}
