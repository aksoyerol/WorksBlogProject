using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Works.BlogProject.Entities.Concrete;

namespace Works.BlogProject.DataAccess.Interfaces
{
    public interface ICategoryDal : IGenericDal<Category>
    {
        Task<List<Category>> GetAllWithCategoryBlogsAsync();
    }
}
