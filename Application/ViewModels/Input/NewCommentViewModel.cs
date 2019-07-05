using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.ViewModels.Input
{
    public class NewCommentViewModel
    {
        [RegularExpression("[A-z][\\w\\s]{2,30}")]
        public string Name { get; set; }
        [DataType(DataType.MultilineText)]
        [Required]
        public string Content { get; set; }
        [Required]
        [Range(1, long.MaxValue)]
        public long PostId { get; set; }
        [Range(1,long.MaxValue)]
        public long? ReplyOnId { get; set; }
    }
}
