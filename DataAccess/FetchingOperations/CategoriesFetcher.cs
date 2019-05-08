using DataAccess.Models;
using Shared_Library.ViewModels.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace DataAccess.FetchingOperations
{
    public class CategoriesFetcher : ICategoriesFetcher
    {
        private BlogDbContext context;
        public CategoriesFetcher(BlogDbContext context)
        {
            this.context = context;
        }
        public IEnumerable<CategoryViewModel> GetCategories()
        {
            return this.context.Categories.Select(c => new CategoryViewModel
            {
                CategoryId = c.CategoryId,
                Name = c.Name
            });
        }
    }
}
