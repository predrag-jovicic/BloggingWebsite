using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Shared_Library.ViewModels.Input
{
    public class CategoryInput
    {
        [RegularExpression(@"[\w]{2,30}")]
        public string Name { get; set; }
    }
}
