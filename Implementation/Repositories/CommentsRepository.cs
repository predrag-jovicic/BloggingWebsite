using Application.Interfaces.Repositories;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementations.Repositories
{
    public class CommentsRepository : ICommentsRepository
    {
        private BlogDbContext context;
        public CommentsRepository(BlogDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Comment> GetAll()
        {
            return this.context.Comments;
        }

        public void Add(Comment comment)
        {
            this.context.Comments.Add(comment);
        }

        public Comment GetById(long id)
        {
            return this.context.Comments.Find(id);
        }

        public void ApproveComment(Comment comment)
        {
            comment.Approved = true;
            this.context.Comments.Update(comment);
        }

        public void Delete(Comment comment)
        {
            this.context.Comments.Remove(comment);
        }
    }
}
