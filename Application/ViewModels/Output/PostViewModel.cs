using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.ViewModels.Output
{
    public class PostViewModel
    {
        public long PostId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        [Display(Name = "Posted on")]
        public DateTime PostedOn { get; set; }
        [Display(Name ="Read time")]
        public byte ReadTime { get; set; }
        [Display(Name = "Number of views")]
        public long NumberOfViews { get; set; }

        [Display(Name = "Username")]
        public string UserId { get; set; }
        [Display(Name = "Author's first name")]
        public string AuthorFirstName { get; set; }
        [Display(Name = "Author's first name")]
        public string AuthorLastName { get; set; }
        [Display(Name = "Biography")]
        public string AuthorBiography { get; set; }
    }
}
