﻿using System;
using System.Collections.Generic;
using System.Text;
using Works.BlogProject.Dto.Interface;
using Works.BlogProject.Entities.Concrete;

namespace Works.BlogProject.Dto.DTOs.CommentDtos
{
    public class CommentListDto : IDto
    {
        public int Id { get; set; }
        public string AuthorName { get; set; }
        public string AuthorEmail { get; set; }
        public string Description { get; set; }
        public DateTime PostedTime { get; set; } = DateTime.Now;
        public int? ParentCommentId { get; set; }
        public List<CommentListDto> SubComments { get; set; }
        public int BlogId { get; set; }


    }
}
