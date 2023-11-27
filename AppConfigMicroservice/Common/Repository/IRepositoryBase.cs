﻿using AppConfigMicroservice.Common.Models;
using AppConfigMicroservice.Common.Models.Entities;
using AppConfigMicroservice.Common.Specifications.Abstract;
using System.Linq.Expressions;

namespace AppConfigMicroservice.Common.Repository
{
    public interface IRepositoryBase<T> where T : class, IEntity, new()
    {
        Task<ApiResponse<T>> GetByIdAsync(long id);
        Task<ApiResponse<T>> AddAsync(T entity);
        //Task<ApiResponse<T>> Delete(long id);
        Task<ApiResponse<T>> Update(T entity);
        Task<ApiResponse<T>> GetFirstOrDefaultAsync(Expression<Func<T, bool>> filter);
        Task<List<T>> GetAll(ISpecification<T> specification);
    }
}
