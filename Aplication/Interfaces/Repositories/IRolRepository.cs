using Ardalis.Specification;

namespace Application.Interfaces.Repositories
{
    public interface IRolRepository<T> : IRepositoryBase<T> where T : class
    {
    }
 }
