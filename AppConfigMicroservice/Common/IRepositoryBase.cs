﻿using AppConfigMicroservice.Domain;
using System.Linq.Expressions;

namespace AppConfigMicroservice.Common
{
    public interface IRepositoryBase<T> where T : class, IEntity, new()
    {
        Task<T> GetByIdAsync(long id);
        Task<List<T>> GetAll(Expression<Func<T, bool>> filter = null);
        Task<T> AddAsync(T entity);
        Task Delete(long id);
        Task<T> Update(T entity);
        Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> filter);
        Task<List<T>> GetListAsync(Expression<Func<T, bool>> filter);
    }
}