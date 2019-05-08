using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repositories
{
    public class TagsRepository : ITagsRepository
    {
        BlogDbContext context;
        public TagsRepository(BlogDbContext context)
        {
            this.context = context;
        }

        public void Add(Tag tag)
        {
            tag.Name = tag.Name.ToLower();
            this.context.Tags.Add(tag);
        }
    }
}
