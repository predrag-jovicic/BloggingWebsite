using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccess.Models
{
    public class PostPhoto
    {
        [Key]
        public int PhotoId { get; set; }
        [Required]
        public string Source { get; set; }
        [Required]
        public string Alt { get; set; }
        public long PostId { get; set; }
        public Post Post { get; set; }
    }
}
