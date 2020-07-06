using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Works.BlogProject.Business.Interfaces;
using Works.BlogProject.Dto.DTOs.BlogDtos;
using Works.BlogProject.Dto.DTOs.CategoryBlogDtos;
using Works.BlogProject.Entities.Concrete;
using Works.BlogProject.WebApi.CustomFilters;
using Works.BlogProject.WebApi.Enums;
using Works.BlogProject.WebApi.Models;

namespace Works.BlogProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : BaseController
    {

        private readonly IBlogService _blogService;
        private readonly IMapper _mapper;
        public BlogsController(IBlogService blogService, IMapper mapper)
        {
            _mapper = mapper;
            _blogService = blogService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(_mapper.Map<List<BlogListDto>>(await _blogService.GetAllSortedPostedTimeAsync()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(_mapper.Map<BlogListDto>(await _blogService.GetByIdAsync(id)));
        }

        [HttpPost]
        [Authorize]
        [ValidModel]
        public async Task<IActionResult> Create([FromForm] BlogAddModel blogAddModel)
        {

            var uploadModel = await UploadFormFileAsync(blogAddModel.FormFile, "image/jpeg", "blog");

            if (uploadModel.UploadState == UploadState.Success)
            {
                blogAddModel.ImagePath = uploadModel.ImageName;
                await _blogService.InsertAsync(_mapper.Map<Blog>(blogAddModel));
                return Created("", blogAddModel);
            }
            else if (uploadModel.UploadState == UploadState.NotExists)
            {
                await _blogService.InsertAsync(_mapper.Map<Blog>(blogAddModel));
                return Created("", blogAddModel);
            }
            else return BadRequest(uploadModel.ErrorMessage);

        }

        [HttpPut("{id}")]
        [Authorize]
        [ValidModel]
        public async Task<IActionResult> Update(int id, [FromForm] BlogUpdateModel blogUpdateModel)
        {
            if (id != blogUpdateModel.Id)
                return BadRequest();

            var uploadModel = await UploadFormFileAsync(blogUpdateModel.FormFile, "image/jpeg", "blog");

            if (uploadModel.UploadState == UploadState.Success)
            {
                blogUpdateModel.ImagePath = uploadModel.ImageName;
                await _blogService.UpdateAsync(_mapper.Map<Blog>(blogUpdateModel));
                return NoContent();
            }
            else if (uploadModel.UploadState == UploadState.NotExists)
            {
                var updatedBlog = await _blogService.GetByIdAsync(blogUpdateModel.Id);
                blogUpdateModel.ImagePath = updatedBlog.ImagePath;
                await _blogService.UpdateAsync(_mapper.Map<Blog>(blogUpdateModel));
                return NoContent();
            }
            else return BadRequest(uploadModel.ErrorMessage);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            await _blogService.DeleteAsync(new Blog { Id = id });
            return NoContent();
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddToCategory(CategoryBlogDto categoryBlogDto)
        {
            await _blogService.AddToCategoryAsync(categoryBlogDto);
            return Created("", categoryBlogDto);
        }

        [HttpDelete("[action]")]
        [ValidModel]
        public async Task<IActionResult> RemoveFromCategory(CategoryBlogDto categoryBlogDto)
        {
            await _blogService.RemoveFromCategoryAsync(categoryBlogDto);
            return NoContent();
        }
    }
}
