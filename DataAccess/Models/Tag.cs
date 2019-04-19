using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccess.Models
{
    public class Tag
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public short TagId { get; set; }
        [Required]
        public string Name { get; set; }

        public ICollection<PostTag> PostTags { get; set; }
    }
}
