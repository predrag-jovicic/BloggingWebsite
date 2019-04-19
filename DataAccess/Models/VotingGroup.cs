using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccess.Models
{
    public class VotingGroup
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VotingGroupId { get; set; }
        public DateTime DateTime { get; set; }
        [Required]
        public string IpAddress { get; set; }
        public int PollId { get; set; }

        public Poll Poll { get; set; }
        public ICollection<Vote> Votes { get; set; }
    }
}
