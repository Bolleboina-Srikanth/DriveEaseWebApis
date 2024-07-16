using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.Models
{
    public class UploadPhotoModel
    {
        public int userid { get; set; }
        public IFormFile image { get; set; }


    }
}
