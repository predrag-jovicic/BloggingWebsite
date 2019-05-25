using Shared_Library.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Shared_Library.ViewModels.Input
{
    public class UpdatePollViewModel
    {
        [RegularExpression(@"^[A-Za-z0-9\s\,\.\?\!\-\@\#]{8,250}$")]
        public string Question { get; set; }
        [FutureDateValidation]
        public DateTime? ActiveUntil { get; set; }
        public bool Active { get; set; }
    }
}
