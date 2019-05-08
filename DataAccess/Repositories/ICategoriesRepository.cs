using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repositories
{
    public interface ICategoriesRepository
    {
        Category GetById(short id);
        Category GetByName(string name);
        void Delete(Category category);
        void Update(Category category);
        void Add(Category category);
    }
}
