using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repositories
{
    public interface ITagsRepository
    {
        void Add(Tag tag);
    }
}
