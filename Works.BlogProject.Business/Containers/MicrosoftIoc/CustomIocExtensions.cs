using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Works.BlogProject.Business.Concrete;
using Works.BlogProject.Business.Interfaces;
using Works.BlogProject.Business.Tools.JwtTool;
using Works.BlogProject.Business.ValidationRules.FluentValidation;
using Works.BlogProject.DataAccess.Concrete.EntityFrameworkCore.Repositories;
using Works.BlogProject.DataAccess.Interfaces;
using Works.BlogProject.Dto.DTOs.AppUserDtos;
using Works.BlogProject.Dto.DTOs.CategoryBlogDtos;
using Works.BlogProject.Dto.DTOs.CategoryDtos;

namespace Works.BlogProject.Business.Containers.MicrosoftIoc
{
    public static class CustomIocExtensions
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericDal<>), typeof(EfGenericRepository<>));
            services.AddScoped(typeof(IGenericService<>), typeof(GenericManager<>));

            services.AddScoped<IBlogDal, EfBlogRepository>();
            services.AddScoped<IAppUserDal, EfAppUserRepository>();
            services.AddScoped<ICategoryDal, EfCategoryRepository>();
            services.AddScoped<ICommentDal, EfCommentRepository>();

            services.AddScoped<IBlogService, BlogManager>();
            services.AddScoped<IAppUserService, AppUserManager>();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<ICommentService, CommentManager>();

            services.AddScoped<IJwtService, JwtManager>();

            services.AddTransient<IValidator<AppUserLoginDto>, AppUserLoginDtoValidator>();
            services.AddTransient<IValidator<CategoryAddDto>, CategoryAddDtoValidator>();
            services.AddTransient<IValidator<CategoryBlogDto>, CategoryBlogDtoValidator>();
            services.AddTransient<IValidator<CategoryUpdateDto>, CategoryUpdateDtoValidator>();

        }
    }
}
