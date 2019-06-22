using System;
using System.Collections.Generic;
using System.Text;

namespace Application.ViewModels.Input
{
    public class RemovePollFromPostsViewModel
    {
        public int PostPollId { get; set; }
        public long PostId { get; set; }
    }
}
