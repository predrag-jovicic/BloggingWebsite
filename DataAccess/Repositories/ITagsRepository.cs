using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repositories
{
    public interface ITagsRepository
    {
        void Add(Tag tag);
        IEnumerable<Tag> GetAll();
        IEnumerable<Tag> GetPopularTags();
        IEnumerable<Tag> GetTagsByPostId(long id);
        Tag GetById(short id);
        PostTag GetPostTag(long postId, short tagId);
        Tag GetByName(string tag);
        void Update(Tag tag);
        void Delete(Tag tag);
        void DeletePostTag(PostTag postTag);
    }
}
