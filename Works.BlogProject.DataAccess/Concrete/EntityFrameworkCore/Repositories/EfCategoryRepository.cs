using Microsoft.EntityFrameworkCore;
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
    public class EfCategoryRepository : EfGenericRepository<Category>, ICategoryDal
    {
        public async Task<List<Category>> GetAllWithCategoryBlogsAsync()
        {
            using var context = new BlogProjectContext();
            return await context.Categories.OrderByDescending(x=>x.Id).Include(x => x.CategoryBlogs).ToListAsync();
        }
    }
}
