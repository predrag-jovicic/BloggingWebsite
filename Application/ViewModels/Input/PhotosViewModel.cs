using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.ViewModels.Input
{
    public class PhotosViewModel
    {
        public long PostId { get; set; }
        [Required]
        public List<IFormFile> Files { get; set; }
    }
}
