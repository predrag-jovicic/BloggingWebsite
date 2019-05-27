using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain
{
    public class UserPhoto
    {
        [Key]
        public int PhotoId { get; set; }
        [Required]
        public string Source { get; set; }
        [Required]
        public string Alt { get; set; }
        [Required]
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
