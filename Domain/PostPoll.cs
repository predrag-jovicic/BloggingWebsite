using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain
{
    public class PostPoll
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PostPollId { get; set; }
        public int PollId { get; set; }
        public long PostId { get; set; }

        public Poll Poll { get; set; }
        public Post Post { get; set; }
    }
}
