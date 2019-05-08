using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repositories
{
    public interface ITagsRepository
    {
        void Add(Tag tag);
        Tag GetById(short id);
        Tag GetByName(string tag);
        void Update(Tag tag);
        void Delete(Tag tag);
    }
}
