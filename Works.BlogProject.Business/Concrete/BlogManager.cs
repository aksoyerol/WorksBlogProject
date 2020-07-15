using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Works.BlogProject.Business.Interfaces;
using Works.BlogProject.DataAccess.Interfaces;
using Works.BlogProject.Dto.DTOs.CategoryBlogDtos;
using Works.BlogProject.Entities.Concrete;

namespace Works.BlogProject.Business.Concrete
{
    public class BlogManager : GenericManager<Blog>, IBlogService
    {
        private readonly IGenericDal<Blog> _genericDal;
        private readonly IGenericDal<CategoryBlog> _categoryBlogDal;
        private readonly IBlogDal _blogDal;
        public BlogManager(IGenericDal<Blog> genericDal, IGenericDal<CategoryBlog> categoryBlogDal, IBlogDal blogDal) : base(genericDal)
        {
            _blogDal = blogDal;
            _categoryBlogDal = categoryBlogDal;
            _genericDal = genericDal;
        }

        public async Task AddToCategoryAsync(CategoryBlogDto categoryBlogDto)
        {
            var control = await _categoryBlogDal.GetAsync(x => x.CategoryId == categoryBlogDto.CategoryId && x.BlogId == categoryBlogDto.BlogId);
            if (control == null)
            {
                await _categoryBlogDal.InsertAsync(new CategoryBlog
                {
                    BlogId = categoryBlogDto.BlogId,
                    CategoryId = categoryBlogDto.CategoryId
                });
            }
        }
        public async Task RemoveFromCategoryAsync(CategoryBlogDto categoryBlogDto)
        {
            var deletedCategory = await _categoryBlogDal.GetAsync(x => x.CategoryId == categoryBlogDto.CategoryId && x.BlogId == categoryBlogDto.BlogId);
            if (deletedCategory != null)
            {
                await _categoryBlogDal.DeleteAsync(deletedCategory);
            }
        }
        public async Task<List<Blog>> GetAllSortedPostedTimeAsync()
        {
            return await _genericDal.GetAllAsync(x => x.PostedTime);
        }

        public async Task<List<Blog>> GetAllByCategoryIdAsync(int id)
        {
            return await _blogDal.GetAllByCategoryIdAsync(id);

        }

        public async Task<List<Category>> GetCategoriesWithBlogAsync(int blogId)
        {
            return await _blogDal.GetCategoriesWithBlogAsync(blogId);
        }

        public async Task<List<Blog>> SearchAsync(string searchString)
        {
            return await _blogDal.GetAllAsync(x => x.Title.ToLower().Contains(searchString.ToLower()) || x.Description.ToLower().Contains(searchString.ToLower()) ||
            x.ShortDescription.ToLower().Contains(searchString.ToLower()), x => x.PostedTime);
        }
    }
}
