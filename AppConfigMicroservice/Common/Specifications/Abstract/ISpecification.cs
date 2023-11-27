namespace AppConfigMicroservice.Common.Specifications.Abstract
{
    public interface ISpecification<T>
    {
        bool IsSatisfiedBy(T entity);
    }
}
