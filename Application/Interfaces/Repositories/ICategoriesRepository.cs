﻿using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces.Repositories
{
    public interface ICategoriesRepository
    {
        IEnumerable<Category> Get(string searchQuery, short pageNumber, short numberOfItems);
        Category GetById(short id);
        Category GetByName(string name);
        void Delete(Category category);
        void Update(Category category);
        void Add(Category category);
    }
}
