using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccess.Models
{
    public class View
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ViewId { get; set; }
        [Required]
        public string IpAddress { get; set; }
        public long PostId { get; set; }

        public Post Post { get; set; }
    }
}
