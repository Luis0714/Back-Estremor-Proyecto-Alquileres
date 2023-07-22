using Application.Espesification;
using Application.Execteptions.Validation;
using Application.Interfaces.Repositories;
using Application.Messages.User;
using Application.Services.Abstraction.SecurityServices;
using Application.Whappers;
using Domain.Entities;
using MediatR;

namespace Application.Features.Users.Querys.GetUserAdmin
{
    public class GetUserAccessCredentials : IRequest<Response<string>>
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
        public class GetUserAccessCredentialsHandler : IRequestHandler<GetUserAccessCredentials, Response<string>>
        {
            private readonly IRepositoryAsync<User> _repositoryAsync;
            private readonly IJwtService _jwtService;
            private readonly IEncrypPasswordService _encrypPasswordService;
        public GetUserAccessCredentialsHandler(IRepositoryAsync<User> repositoryAsync, IJwtService jwtService, IEncrypPasswordService encrypPasswordService)
        {
            _repositoryAsync = repositoryAsync;
            _jwtService = jwtService;
            _encrypPasswordService = encrypPasswordService;
        }

        public async Task<Response<string>> Handle(GetUserAccessCredentials request, CancellationToken cancellationToken)
        {
            var users = await _repositoryAsync.ListAsync(new GetCurrentUserSpecification(request.Email, _encrypPasswordService.Encrypt(request.Password)), cancellationToken);
            var user = users.FirstOrDefault();
            if (user == default)
                throw new ApiException(MessageUserErrors.InvalidCredentials);
            return new Response<string>(_jwtService.GenerateToken(user),MessageUserErrors.TokenAuthorization) ;
        }
    
    }
}
