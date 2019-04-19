using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccess.Models
{
    public class Comment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long CommentId { get; set; }
        [Required]
        public string Text { get; set; }
        public bool Approved { get; set; }
        public DateTime PostedOn { get; set; }
        public long? ReplyOnId { get; set; }
        public long PostId { get; set; }
        [Required]
        public string UserId { get; set; }

        public Post Post { get; set; }
        public User User { get; set; }
        public Comment ReplyOn { get; set; }
    }
}
