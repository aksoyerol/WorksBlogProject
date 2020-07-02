using System;
using System.Collections.Generic;
using System.Text;
using Works.BlogProject.Dto.Interface;

namespace Works.BlogProject.Dto.DTOs.CategoryDtos
{
    public class CategoryUpdateDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
