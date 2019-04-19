using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccess.Models
{
    public class Vote
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long VoteId { get; set; }
        public int VotingGroupId { get; set; }
        public int PollAnswerId { get; set; }

        public VotingGroup VotingGroup { get; set; }
        public PollAnswer PollAnswer { get; set; }
    }
}
