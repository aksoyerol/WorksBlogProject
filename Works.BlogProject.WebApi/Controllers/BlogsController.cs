using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Works.BlogProject.Business.Interfaces;
using Works.BlogProject.Dto.DTOs.BlogDtos;
using Works.BlogProject.Entities.Concrete;
using Works.BlogProject.WebApi.Models;

namespace Works.BlogProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        
        private readonly IBlogService _blogService;
        private readonly IMapper _mapper;
        public BlogsController(IBlogService blogService,IMapper mapper)
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
        public async Task<IActionResult> Create(BlogAddModel blogAddModel)
        {
            await _blogService.InsertAsync(_mapper.Map<Blog>(blogAddModel));
            return Created("", blogAddModel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id,BlogUpdateModel blogUpdateModel)
        {
            if (id != blogUpdateModel.Id)
                return BadRequest();

            await _blogService.UpdateAsync(_mapper.Map<Blog>(blogUpdateModel));
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _blogService.DeleteAsync(new Blog { Id = id });
            return NoContent();
        }
    }
}
