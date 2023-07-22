using Application.Filters.Users;
using Ardalis.Specification;
using Domain.Entities;

namespace Application.Espesification
{
    public class GetAllUserPagesSpecification : Specification<User>
    {
        public GetAllUserPagesSpecification(UsersFilters filters) 
        {
            Query.Skip((filters.PageNumber - 1) * filters.PageZise).Take(filters.PageZise);
            if (!string.IsNullOrEmpty(filters.Name))
            {
                Query.Search(user => user.Name, $"%{filters.Name}%");
            }
            if (!string.IsNullOrEmpty(filters.Name))
            {
                Query.Search(user => user.LastName, $"%{filters.LastName}%");
            }
        }
    }
}
