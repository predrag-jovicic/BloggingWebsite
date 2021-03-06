﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public short CategoryId { get; set; }
        [Required]
        public string Name { get; set; }

        public ICollection<Post> Posts { get; set; }
    }
}
