using Application.Interfaces.Repositories;
using Ardalis.Specification.EntityFrameworkCore;
using Persistence.Contexts;

namespace Persistence.Repository.Implementation
{
    public class RolRepository<T> : RepositoryBase<T>,IRolRepository<T> where T : class
    {
        public RolRepository(RolDbContext dbcontext) : base(dbcontext)
        {

        }
    }
}
