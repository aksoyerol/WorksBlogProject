﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Works.BlogProject.WebApi.Models
{
    public class BlogUpdateModel
    {
        public int Id { get; set; }
        public int AppUserId { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string ImagePath { get; set; }
        public string Description { get; set; }
        public IFormFile FormFile { get; set; }
    }
}
