using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Works.BlogProject.Dto.DTOs.BlogDtos;
using Works.BlogProject.Dto.DTOs.CategoryDtos;
using Works.BlogProject.Entities.Concrete;
using Works.BlogProject.WebApi.Models;

namespace Works.BlogProject.WebApi.Mapping.AutoMapperProfile
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Blog, BlogListDto>();
            CreateMap<BlogListDto, Blog>();
            CreateMap<Blog, BlogAddModel>();
            CreateMap<BlogAddModel, Blog>();
            CreateMap<Blog, BlogUpdateModel>();
            CreateMap<BlogUpdateModel, Blog>();

            CreateMap<Category, CategoryAddDto>();
            CreateMap<CategoryAddDto, Category>();
            CreateMap<Category, CategoryListDto>();
            CreateMap<CategoryListDto, Category>();
            CreateMap<Category, CategoryUpdateDto>();
            CreateMap<CategoryUpdateDto, Category>();
        }
    }
}
