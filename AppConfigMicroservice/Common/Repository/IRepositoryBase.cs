using AppConfigMicroservice.Common.Models;
using AppConfigMicroservice.Common.Models.Entities;
using AppConfigMicroservice.Common.Specifications;
using System.Linq.Expressions;

namespace AppConfigMicroservice.Common.Repository;

public interface IRepositoryBase<T> where T : class, IEntity, new()
{
    Task<T> GetByIdAsync(long id);
    Task<T> AddAsync(T entity);
    Task<T> Update(T entity);
    Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> filter);
    Task<List<T>> GetAll(int queryPage, int querySize);
    Task<T> GetByFilter(Specification<T> specification);
}
