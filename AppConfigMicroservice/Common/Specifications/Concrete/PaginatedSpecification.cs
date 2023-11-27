using AppConfigMicroservice.Common.Specifications.Abstract;

namespace AppConfigMicroservice.Common.Specifications.Concrete
{
    public class PaginatedSpecification<T> : ISpecification<T>
    {
        private readonly int _pageNumber;
        private readonly int _pageSize;

        public PaginatedSpecification(int pageNumber, int pageSize)
        {
            _pageNumber = pageNumber;
            _pageSize = pageSize;
        }
        public bool IsSatisfiedBy(T entity)
        {
            int startIndex = (_pageNumber - 1) * _pageSize;
            int endIndex = startIndex + _pageSize - 1;

            if (entity is IList<T> list)
            {
                return startIndex >= 0 && endIndex < list.Count;
            }

            return false;
        }
    }
}
