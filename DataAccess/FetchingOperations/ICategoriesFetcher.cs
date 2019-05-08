using Shared_Library.ViewModels.Output;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.FetchingOperations
{
    public interface ICategoriesFetcher
    {
        IEnumerable<CategoryViewModel> GetCategories();
    }
}
