using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.ViewModels.Input
{
    public class NewUserViewModel
    {
        [Required]
        [RegularExpression(@"^[A-Za-z\s]{2,20}$")]
        public string FirstName { get; set; }
        [Required]
        [RegularExpression(@"^[A-Za-z\s]{2,30}$")]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        [RegularExpression(@"^[\w\-\,\.\!\?\(\)\n\r\s]{3,150}$")]
        public string Biography { get; set; }
        [DataType(DataType.Url)]
        public string UrlFacebook { get; set; }
        [DataType(DataType.Url)]
        public string UrlTwitter { get; set; }
        [DataType(DataType.Url)]
        public string UrlLinkedIn { get; set; }
        [RegularExpression(@"^[\w\-\.]{2,20}$")]
        [Required]
        public string Username { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
