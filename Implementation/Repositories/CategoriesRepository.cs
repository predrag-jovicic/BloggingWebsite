using Application.Interfaces.Repositories;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementations.Repositories
{
    public class CategoriesRepository : ICategoriesRepository
    {
        private BlogDbContext context;
        public CategoriesRepository(BlogDbContext context)
        {
            this.context = context;
        }

        public void Add(Category category)
        {
            this.context.Add(category);
        }

        public void Delete(Category category)
        {
            this.context.Remove(category);
        }

        public IEnumerable<Category> GetAll()
        {
            return this.context.Categories;
        }

        public Category GetById(short id)
        {
            return this.context.Categories.Find(id);
        }

        public Category GetByName(string name)
        {
            return this.context.Categories
                .SingleOrDefault(c => c.Name == name);
        }

        public void Update(Category category)
        {
            this.context.Categories.Update(category);
        }
    }
}
