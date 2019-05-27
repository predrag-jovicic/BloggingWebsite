using Application.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.ViewModels.Input
{
    public class NewPostViewModel
    {
        [Required]
        [RegularExpression(@"^[\w\s\?\.\,\!\-\&\%\#]{3,60}$")]
        public string Title { get; set; }
        [StringListValidation(@"^[\w\-]{3,20}$")]
        public IEnumerable<string> Tags { get; set; }
        [Range(1,short.MaxValue)]
        [Required]
        public short CategoryId { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        [RegularExpression(@"^[\w\s\?\.\@\n\r\,\!\-\&\%\#]+$")]
        public string Content { get; set; }
    }
}
