using Ardalis.Specification;
using Domain.Entities;
namespace Application.Espesification
{
    public class GetCurrentUserSpecification: Specification<User>
    {
        public GetCurrentUserSpecification(string? Email, string? Password)
        {
            if (!string.IsNullOrEmpty(Email) && !string.IsNullOrEmpty(Password))
                Query.Where(user => user.Email == Email && user.Password == Password);
        }
    }
}
