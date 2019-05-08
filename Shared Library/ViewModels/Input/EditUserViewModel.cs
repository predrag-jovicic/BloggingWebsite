using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Shared_Library.ViewModels.Input
{
    public class EditUserViewModel
    {
        [RegularExpression(@"^[A-Za-z\s]{2,20}$")]
        public string FirstName { get; set; }
        [RegularExpression(@"^[A-Za-z\s]{2,30}$")]
        public string LastName { get; set; }
        [DataType(DataType.MultilineText)]
        [RegularExpression(@"^[\w\-\,\.\!\?\(\)\n\r\s]{3,150}$")]
        public string Biography { get; set; }
        [DataType(DataType.Url)]
        public string UrlFacebook { get; set; }
        [DataType(DataType.Url)]
        public string UrlTwitter { get; set; }
        [DataType(DataType.Url)]
        public string UrlLinkedIn { get; set; }
    }
}
