using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public void Delete(Tag tag)
        {
            this.context.Tags.Remove(tag);
        }

        public Tag GetById(short id)
        {
            return this.context.Tags.Find(id);
        }

        public Tag GetByName(string tag)
        {
            return this.context.Tags
                .SingleOrDefault(t => t.Name == tag.ToLower());
        }

        public void Update(Tag tag)
        {
            this.context.Tags.Update(tag);
        }
    }
}
