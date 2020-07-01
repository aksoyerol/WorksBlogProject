using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Works.BlogProject.Business.Interfaces;
using Works.BlogProject.DataAccess.Interfaces;
using Works.BlogProject.Entities.Interfaces;

namespace Works.BlogProject.Business.Concrete
{
    public class GenericManager<T> : IGenericService<T> where T : class, ITable, new()
    {
        private readonly IGenericDal<T> _genericDal;
        public GenericManager(IGenericDal<T> genericDal)
        {
            _genericDal = genericDal;
        }
        public async Task<List<T>> GetAllAsync()
        {
            return await _genericDal.GetAllAsync();
        }

        //public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter)
        //{
        //    return await _genericDal.GetAllAsync(filter);
        //}

        //public async Task<List<T>> GetAllAsync<TKey>(Expression<Func<T, bool>> filter, Expression<Func<T, TKey>> keySelector)
        //{
        //    return await _genericDal.GetAllAsync(filter, keySelector);
        //}

        //public async Task<List<T>> GetAllAsync<TKey>(Expression<Func<T, TKey>> keySelector)
        //{
        //    return await _genericDal.GetAllAsync(keySelector);
        //}

        //public async Task<T> GetAsync(Expression<Func<T, bool>> filter)
        //{
        //    return await _genericDal.GetAsync(filter);
        //}

        public async Task InsertAsync(T entity)
        {
            await _genericDal.InsertAsync(entity);
        }

        public async Task UpdateAsync(T entity)
        {
            await _genericDal.UpdateAsync(entity);
        }
        public async Task DeleteAsync(T entity)
        {
            await _genericDal.DeleteAsync(entity);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _genericDal.GetByIdAsync(id);
        }
    }
}
