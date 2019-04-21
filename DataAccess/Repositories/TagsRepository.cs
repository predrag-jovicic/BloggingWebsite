using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repositories
{
    public class TagsRepository
    {
        BlogDbContext context;
        public TagsRepository(BlogDbContext context)
        {
            this.context = context;
        }
    }
}
