using Application.Interfaces.Repositories;
using Ardalis.Specification.EntityFrameworkCore;
using Persistence.Contexts;

namespace Persistence.Repository.Implementation
{
    public class MyRepositoryAsync<T> : RepositoryBase<T>, IRepositoryAsync<T> where T : class
    {
        public MyRepositoryAsync(ApplicationDBContext dbcontext) : base(dbcontext)
        {

        }
    }
}
