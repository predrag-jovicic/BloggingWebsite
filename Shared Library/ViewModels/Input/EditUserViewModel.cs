using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Shared_Library.ViewModels.Input
{
    public class EditUserViewModel
    {
        [DataType(DataType.MultilineText)]
        public string Biography { get; set; }
        [DataType(DataType.Url)]
        public string UrlFacebook { get; set; }
        [DataType(DataType.Url)]
        public string UrlTwitter { get; set; }
        [DataType(DataType.Url)]
        public string UrlLinkedIn { get; set; }
    }
}
