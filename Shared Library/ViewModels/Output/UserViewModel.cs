using System;
using System.Collections.Generic;
using System.Text;

namespace Shared_Library.ViewModels.Output
{
    public class UserViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Username { get; set; }
        public string Biography { get; set; }

        public string UrlFacebook { get; set; }
        public string UrlTwitter { get; set; }
        public string UrlLinkedIn { get; set; }
    }
}
