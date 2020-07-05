using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Works.BlogProject.Business.Interfaces;

namespace Works.BlogProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IBlogService _blogService;
        public ImagesController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetBlogByImageId(int id)
        {
            var blog = await _blogService.GetByIdAsync(id);
                if (string.IsNullOrWhiteSpace(blog.ImagePath)) return NotFound("No image");


            return File($"/img/{blog.ImagePath}", "image/jpeg");
        }

    }
}
