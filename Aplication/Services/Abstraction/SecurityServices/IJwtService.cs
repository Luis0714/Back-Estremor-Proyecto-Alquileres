using Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace Application.Services.Abstraction.SecurityServices
{
    public interface IJwtService
    {
        string GenerateToken(User user);
        int GetIdUserInToken(HttpContext context);
    }
}
