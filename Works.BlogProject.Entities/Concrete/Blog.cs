﻿using System;
using System.Collections.Generic;
using System.Text;
using Works.BlogProject.Entities.Interfaces;

namespace Works.BlogProject.Entities.Concrete
{
    public class Blog : ITable
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string ImagePath { get; set; }
        public string Description { get; set; }
        public DateTime PostedTime { get; set; } = DateTime.Now;
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public List<Comment> Comments { get; set; }
        public List<CategoryBlog> CategoryBlogs { get; set; }
    }
}
