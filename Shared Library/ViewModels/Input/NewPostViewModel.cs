using Shared_Library.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Shared_Library.ViewModels.Input
{
    public class NewPostViewModel
    {
        [Required]
        [RegularExpression("^[\\w\\s\\?\\.\\,\\!\\-\\&\\%\\#]{3,60}$")]
        public string Title { get; set; }
        [TagsValidation]
        public IEnumerable<string> Tags { get; set; }
        [Range(1,short.MaxValue)]
        [Required]
        public short CategoryId { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }
    }
}
