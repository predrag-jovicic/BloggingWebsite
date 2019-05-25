using System;
using System.Collections.Generic;
using System.Text;

namespace Shared_Library.ViewModels.Input
{
    public class NewVoteViewModel
    {
        public int PollId { get; set; }
        public List<int> VotedFor { get; set; }
    }
}
