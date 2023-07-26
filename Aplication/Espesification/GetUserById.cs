using Ardalis.Specification;
using Domain.Entities;

namespace Application.Espesification
{
    public class GetUserById : Specification<User>
    {
        public GetUserById(int userId)
        {
            if (userId != default)
            {
                Query.Where(user => user.Id == userId);
            }
        }
    }
}
