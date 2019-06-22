using Application.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.ViewModels.Input
{
    public class NewPollAnswerViewModel
    {
        [RegularExpression(@"^[\w\-\s\,\.\!]{3,20}$")]
        public string Name { get; set; }
        public int PollId { get; set; }
    }
}
