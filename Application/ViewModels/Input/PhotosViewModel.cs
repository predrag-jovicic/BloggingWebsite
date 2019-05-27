using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.ViewModels.Input
{
    public class PhotosViewModel
    {
        public long PostId { get; set; }
        public List<IFormFile> Files { get; set; }
    }
}
