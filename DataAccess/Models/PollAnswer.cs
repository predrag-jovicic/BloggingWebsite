using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccess.Models
{
    public class PollAnswer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PollAnswerId { get; set; }
        [Required]
        public string Name { get; set; }
        public int PollId { get; set; }

        public Poll Poll { get; set; }
        public ICollection<Vote> Votes { get; set; }
    }
}
