using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.ViewModels
{
    public class CommentViewModel
    {
        public long CommentId { get; set; }
        public string Text { get; set; }
        public DateTime PostedOn { get; set; }
        public string AuthorName { get; set; }
        public string AuthorPhoto { get; set; }

        public IEnumerable<CommentViewModel> Replies { get; set; }
    }
}
