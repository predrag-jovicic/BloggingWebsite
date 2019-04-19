using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccess.Models
{
    public class Poll
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PollId { get; set; }
        [Required]
        public string Question { get; set; }
        public DateTime? ActiveUntil { get; set; }
        public bool Active { get; set; }
        public bool MultipleAnswers { get; set; }
        [Required]
        public string UserId { get; set; }
        
        public User User { get; set; }
        public ICollection<PollAnswer> PollAnswers { get; set; }
        public ICollection<PostPoll> PostPolls { get; set; }
        public ICollection<VotingGroup> VotingGroups { get; set; }
    }
}
