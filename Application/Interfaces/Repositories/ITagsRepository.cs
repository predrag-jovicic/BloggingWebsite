using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces.Repositories
{
    public interface ITagsRepository
    {
        void Add(Tag tag);
        IEnumerable<Tag> Get(string searchQuery, short numberOfItems, short pageNumber);
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
