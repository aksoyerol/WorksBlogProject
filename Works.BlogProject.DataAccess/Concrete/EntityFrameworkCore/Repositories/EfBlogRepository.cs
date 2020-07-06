using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Works.BlogProject.DataAccess.Concrete.EntityFrameworkCore.Context;
using Works.BlogProject.DataAccess.Interfaces;
using Works.BlogProject.Entities.Concrete;

namespace Works.BlogProject.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfBlogRepository : EfGenericRepository<Blog>, IBlogDal
    {
        public async Task<List<Blog>> GetAllByCategoryIdAsync(int id)
        {
            using var context = new BlogProjectContext();

            return await context.Blogs.Join(context.CategoryBlogs, b => b.Id, cb => cb.BlogId, (blog, categoryBlog) =>
            new
            {
                blog = blog,
                categoryBlog = categoryBlog
            }).Where(x => x.categoryBlog.CategoryId == id).Select(x => new Blog
            {
                Title = x.blog.Title,
                AppUser = x.blog.AppUser,
                AppUserId = x.blog.AppUserId,
                CategoryBlogs = x.blog.CategoryBlogs,
                Comments = x.blog.Comments,
                Description = x.blog.Description,
                Id = x.blog.Id,
                ImagePath = x.blog.ImagePath,
                PostedTime = x.blog.PostedTime,
                ShortDescription = x.blog.ShortDescription
            }).ToListAsync();
        }
    }
}
