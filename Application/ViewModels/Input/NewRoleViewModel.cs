using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.ViewModels.Input
{
    public class NewRoleViewModel
    {
        [Required]
        public string Name { get; set; }
    }
}
