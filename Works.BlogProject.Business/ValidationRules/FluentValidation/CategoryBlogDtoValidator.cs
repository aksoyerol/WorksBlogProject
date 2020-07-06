using FluentValidation;
using Works.BlogProject.Dto.DTOs.CategoryBlogDtos;

namespace Works.BlogProject.Business.ValidationRules.FluentValidation
{
    public class CategoryBlogDtoValidator : AbstractValidator<CategoryBlogDto>
    {
        public CategoryBlogDtoValidator()
        {
            RuleFor(x => x.BlogId).InclusiveBetween(0, int.MaxValue).WithMessage("BlogId cannot be null");
            RuleFor(x => x.CategoryId).InclusiveBetween(0, int.MaxValue).WithMessage("CategoryId cannot be null");
        }
    }
}
