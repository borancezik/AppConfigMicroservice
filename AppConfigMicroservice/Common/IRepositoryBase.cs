using AppConfigMicroservice.Domain;
using System.Linq.Expressions;

namespace AppConfigMicroservice.Common
{
    public interface IRepositoryBase<T> where T : class, IEntity, new()
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        T GetById(int id);
        T Add(T entity);
        T Update(T entity);
        T Delete(T entity);
    }
}
