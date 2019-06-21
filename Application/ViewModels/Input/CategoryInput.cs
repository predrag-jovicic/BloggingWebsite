using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.ViewModels.Input
{
    public class CategoryInput
    {
        [RegularExpression(@"[\w\s]{2,30}")]
        public string Name { get; set; }
    }
}
