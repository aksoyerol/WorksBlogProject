﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Works.BlogProject.Entities.Interfaces;

namespace Works.BlogProject.Business.Interfaces
{
    public interface IGenericService<T> where T : class,ITable,new()
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        //Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter);
        //Task<List<T>> GetAllAsync<TKey>(Expression<Func<T, bool>> filter, Expression<Func<T, TKey>> keySelector);
        //Task<List<T>> GetAllAsync<TKey>(Expression<Func<T, TKey>> keySelector);
        //Task<T> GetAsync(Expression<Func<T, bool>> filter);
        Task InsertAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
