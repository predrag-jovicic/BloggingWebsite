using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccess.ViewModels.Input
{
    public class NewCommentViewModel
    {
        [Required]
        [RegularExpression("[A-Za-z\\s]{2,30}")]
        public string Name { get; set; }
        public string UserId { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.MultilineText)]
        [Required]
        public string Content { get; set; }
        public long PostId { get; set; }
        public long? ReplyOnId { get; set; }
    }
}
