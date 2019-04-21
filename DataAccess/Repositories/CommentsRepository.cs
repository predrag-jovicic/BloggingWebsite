using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repositories
{
    public class CommentsRepository
    {
        private BlogDbContext context;
        public CommentsRepository(BlogDbContext context)
        {
            this.context = context;
        }

        public void Add(Comment comment)
        {
            this.context.Comments.Add(comment);
        }
    }
}
