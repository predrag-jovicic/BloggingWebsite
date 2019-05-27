using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.ViewModels.Input
{
    public class LogInViewModel
    {
        [Required]
        [RegularExpression("^[\\w\\.\\!\\@\\#]{2,20}$")]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
