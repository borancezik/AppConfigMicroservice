using AppConfigMicroservice.Common.Models;
using AppConfigMicroservice.Common.Models.Entities;
using AppConfigMicroservice.Common.Specifications.Abstract;
using AppConfigMicroservice.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace AppConfigMicroservice.Common.Repository
{
    public class RepositoryBase<TEntity, TContext> : IRepositoryBase<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : ApplicationContext
    {
        private readonly TContext _context;
        private readonly DbSet<TEntity> _dbSet;
        public RepositoryBase(TContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public virtual async Task<ApiResponse<TEntity>> AddAsync(TEntity entity)
        {
            try
            {
                await _dbSet.AddAsync(entity);
                await _context.SaveChangesAsync();
                return ApiResponse<TEntity>.SuccessResult(entity);
            }
            catch (Exception ex)
            {
                return ApiResponse<TEntity>.FailureResult(ex.Message);
            }

        }

        //public virtual async Task<ApiResponse<TEntity>> Delete(long id)
        //{
        //    var entity = await _dbSet.FindAsync(id);
        //    if (entity != null)
        //    {
        //        entity.
        //        _dbSet.Update(entity);
        //        await _context.SaveChangesAsync();
        //        return entity;
        //    }
        //}

        public virtual async Task<ApiResponse<TEntity>> GetByIdAsync(long id)
        {
            try
            {
                var entity = await _dbSet.FindAsync(id);
                if (entity is not null)
                {
                    return ApiResponse<TEntity>.SuccessResult(entity);
                }
                else
                {
                    return ApiResponse<TEntity>.FailureResult("Değer bulunamadı");
                }
            }
            catch (Exception ex)
            {
                return ApiResponse<TEntity>.FailureResult(ex.Message);
            }
        }

        public virtual async Task<ApiResponse<TEntity>> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>> filter)
        {
            try
            {
                var entity = await _dbSet.FirstOrDefaultAsync(filter);
                if (entity is not null)
                {
                    return ApiResponse<TEntity>.SuccessResult(entity);
                }
                else
                {
                    return ApiResponse<TEntity>.FailureResult("Değer bulunamadı");
                }
            }
            catch (Exception ex)
            {
                return ApiResponse<TEntity>.FailureResult(ex.Message);
            }
        }

        public virtual async Task<List<TEntity>> GetAll(ISpecification<TEntity> specification)
        {
            List<TEntity> entities = _dbSet.Where(specification.IsSatisfiedBy).ToList();
            return await Task.FromResult(entities);
        }

        public virtual async Task<ApiResponse<TEntity>> Update(TEntity entity)
        {
            try
            {
                _dbSet.Update(entity);
                await _context.SaveChangesAsync();
                return ApiResponse<TEntity>.SuccessResult(entity);
            }
            catch (Exception ex)
            {
                return ApiResponse<TEntity>.FailureResult(ex.Message);
            }
        }
    }
}
