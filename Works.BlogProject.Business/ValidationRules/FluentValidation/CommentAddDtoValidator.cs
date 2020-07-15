using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Works.BlogProject.Dto.DTOs.CommentDtos;

namespace Works.BlogProject.Business.ValidationRules.FluentValidation
{
    public class CommentAddDtoValidator : AbstractValidator<CommentAddDto>
    {
        public CommentAddDtoValidator()
        {
            RuleFor(x => x.AuthorName).NotEmpty().WithMessage("Name is required").MaximumLength(50).WithMessage("Max length must be 50 char");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required").MaximumLength(280).WithMessage("Max length must be 280 char");
            RuleFor(x => x.AuthorEmail).NotEmpty().WithMessage("Email is required").MaximumLength(50).WithMessage("Max length must be 50 char");
        }
    }
}
