using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Shared_Library.ViewModels.Input
{
    public class NewUserViewModel
    {
        [RegularExpression("^[A-Za-z\\s]{2,20}$")]
        public string FirstName { get; set; }
        [RegularExpression("^[A-Za-z\\s]{2,30}$")]
        public string LastName { get; set; }
        [DataType(DataType.MultilineText)]
        public string Biography { get; set; }
        [DataType(DataType.Url)]
        public string UrlFacebook { get; set; }
        [DataType(DataType.Url)]
        public string UrlTwitter { get; set; }
        [DataType(DataType.Url)]
        public string UrlLinkedIn { get; set; }
        [RegularExpression("^[\\w\\.]{2,20}$")]
        public string Username { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
