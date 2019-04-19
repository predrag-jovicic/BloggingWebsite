using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccess.Models
{
    public class PostTag
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long PtId { get; set; }
        public short TagId { get; set; }
        public long PostId { get; set; }

        public Post Post { get; set; }
        public Tag Tag { get; set; }
    }
}
