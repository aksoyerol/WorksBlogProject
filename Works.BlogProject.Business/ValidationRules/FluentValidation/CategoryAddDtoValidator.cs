using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Works.BlogProject.Dto.DTOs.CategoryDtos;

namespace Works.BlogProject.Business.ValidationRules.FluentValidation
{
    public class CategoryAddDtoValidator : AbstractValidator<CategoryAddDto>
    {
        public CategoryAddDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Category Name area cannot be null");
        }
    }
}
