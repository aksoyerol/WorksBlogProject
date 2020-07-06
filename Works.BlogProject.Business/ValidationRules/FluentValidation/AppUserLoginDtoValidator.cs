using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Works.BlogProject.Dto.DTOs.AppUserDtos;

namespace Works.BlogProject.Business.ValidationRules.FluentValidation
{
    public class AppUserLoginDtoValidator : AbstractValidator<AppUserLoginDto>
    {
        public AppUserLoginDtoValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Username area cannot be null !");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password area cannot be null !");
        }
    }
}
