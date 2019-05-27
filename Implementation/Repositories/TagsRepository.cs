using Application.Interfaces.Repositories;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementations.Repositories
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

        public void DeletePostTag(PostTag postTag)
        {
            this.context.PostTags.Remove(postTag);
        }

        public Tag GetById(short id)
        {
            return this.context.Tags.Find(id);
        }

        public PostTag GetPostTag(long postId, short tagId)
        {
            return this.context.PostTags
                .SingleOrDefault(pt => pt.PostId == postId && pt.TagId == tagId);
        }

        public IEnumerable<Tag> GetAll()
        {
            return this.context.Tags;
        }

        public IEnumerable<Tag> GetPopularTags()
        {
            return this.context.Tags
                .OrderByDescending(t => t.PostTags.Count());
        }

        public Tag GetByName(string tag)
        {
            return this.context.Tags
                .SingleOrDefault(t => t.Name == tag.ToLower());
        }

        public IEnumerable<Tag> GetTagsByPostId(long id)
        {
            return this.context.PostTags
                .Where(pt => pt.PostId == id)
                .Select(pt => pt.Tag);
        }

        public void Update(Tag tag)
        {
            this.context.Tags.Update(tag);
        }
    }
}
