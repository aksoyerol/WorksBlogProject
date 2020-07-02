using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Works.BlogProject.Business.Interfaces;
using Works.BlogProject.DataAccess.Interfaces;
using Works.BlogProject.Entities.Concrete;

namespace Works.BlogProject.Business.Concrete
{
    public class BlogManager : GenericManager<Blog>,IBlogService
    {
        private readonly IGenericDal<Blog> _genericDal;
        public BlogManager(IGenericDal<Blog> genericDal) : base(genericDal)
        {
            _genericDal = genericDal;
        }
        public async Task<List<Blog>> GetAllSortedPostedTimeAsync()
        {
            return await _genericDal.GetAllAsync(x => x.PostedTime);
        }
    }
}
