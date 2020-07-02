using System;
using System.Collections.Generic;
using System.Text;
using Works.BlogProject.Dto.Interface;

namespace Works.BlogProject.Dto.DTOs.BlogDtos
{
    public class BlogListDto : IDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string ImagePath { get; set; }
        public string Description { get; set; }
        public DateTime PostedTime { get; set; } 
    }
}
