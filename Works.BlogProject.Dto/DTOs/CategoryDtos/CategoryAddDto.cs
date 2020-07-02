using System;
using System.Collections.Generic;
using System.Text;
using Works.BlogProject.Dto.Interface;

namespace Works.BlogProject.Dto.DTOs.CategoryDtos
{
    public class CategoryAddDto : IDto
    {
        public string Name { get; set; }
    }
}
