using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Works.BlogProject.Dto.DTOs.CategoryDtos;

namespace Works.BlogProject.Business.ValidationRules.FluentValidation
{
    public class CategoryUpdateDtoValidator : AbstractValidator<CategoryUpdateDto>
    {
        public CategoryUpdateDtoValidator()
        {
            RuleFor(x => x.Id).InclusiveBetween(0, int.MaxValue).WithMessage("Invalid id value !");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Category name is required !");
        }
    }
}
