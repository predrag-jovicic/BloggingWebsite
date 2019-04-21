using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccess.Models
{
    public class Post
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long PostId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Text { get; set; }
        public DateTime PostedOn { get; set; }
        public byte ReadTime { get; set; }
        public long NumberOfViews { get; set; }

        public short CategoryId { get; set; }
        [Required]
        public string UserId { get; set; }

        public Category Category { get; set; }
        public User User { get; set; }
        public ICollection<PostTag> PostTags { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<PostPhoto> Photos { get; set; }
        public ICollection<PostPoll> PostPolls { get; set; }
        public ICollection<View> Views { get; set; }
    }
}
