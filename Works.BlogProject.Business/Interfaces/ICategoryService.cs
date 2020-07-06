using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Works.BlogProject.Entities.Concrete;

namespace Works.BlogProject.Business.Interfaces
{
    public interface ICategoryService : IGenericService<Category>
    {
        Task<List<Category>> GetAllSortedByIdAsync();
        Task<List<Category>> GetAllWithCategoryBlogsAsync();
    }
}
