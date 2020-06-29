using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Works.BlogProject.DataAccess.Concrete.EntityFrameworkCore.Context;
using Works.BlogProject.DataAccess.Interfaces;
using Works.BlogProject.Entities.Interfaces;

namespace Works.BlogProject.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfGenericRepository<T> : IGenericDal<T> where T : class, ITable, new()
    {
        public async Task<List<T>> GetAllAsync()
        {
            using var context = new BlogProjectContext();
            return await context.Set<T>().ToListAsync();
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter)
        {
            using var context = new BlogProjectContext();
            return await context.Set<T>().Where(filter).ToListAsync();
        }

        public async Task<List<T>> GetAllAsync<TKey>(Expression<Func<T, bool>> filter,Expression<Func<T,TKey>> keySelector)
        {
            using var context = new BlogProjectContext();
            return await context.Set<T>().Where(filter).OrderByDescending(keySelector).ToListAsync();
        }

        public async Task<List<T>> GetAllAsync<TKey>(Expression<Func<T, TKey>> keySelector)
        {
            using var context = new BlogProjectContext();
            return await context.Set<T>().OrderByDescending(keySelector).ToListAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> filter)
        {
            using var context = new BlogProjectContext();
            return await context.Set<T>().FirstOrDefaultAsync(filter);
        }

        public async Task InsertAsync(T entity)
        {
            using var context = new BlogProjectContext();
            await context.Set<T>().AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            using var context = new BlogProjectContext();
            context.Set<T>().Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            using var context = new BlogProjectContext();
            context.Set<T>().Remove(entity);
            await context.SaveChangesAsync();
        }

    }
}
