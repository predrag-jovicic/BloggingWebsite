using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shared_Library.ViewModels.Output
{
    public class PollViewModel
    {
        public int PollId { get; set; }
        public string Question { get; set; }
        public DateTime? ActiveUntil { get; set; }
        public bool Active { get; set; }
        public bool MultipleAnswers { get; set; }
        public IQueryable<PollAnswerViewModel> Answers { get; set; }
    }
}
