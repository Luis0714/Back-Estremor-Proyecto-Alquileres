using Ardalis.Specification;
using Domain.Entities;

namespace Application.Espesification
{
    public class GetAllUserSpecification: Specification<User>
    {
        public GetAllUserSpecification()
        {
            Query.Where(user => user.UserId != default);
        }
    }
}
