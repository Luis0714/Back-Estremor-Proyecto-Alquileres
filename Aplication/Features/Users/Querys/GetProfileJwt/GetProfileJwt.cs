using Application.Constants;
using Application.DTO_s;
using Application.Interfaces.Repositories;
using Application.Services.Abstraction.SecurityServices;
using Application.Whappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Features.Users.Querys.GetProfileJwt
{
    public class GetProfileJwt : IRequest<Response<UserDto>>
    {
        public HttpContext HttpContext { get; set; }

        public GetProfileJwt(HttpContext httpContext)
        {
            HttpContext = httpContext;
        }
    }

    public class GetProfileJwtHandler : IRequestHandler<GetProfileJwt, Response<UserDto>>
    {
        private readonly IRepositoryAsync<User> _repositoryAsync;
        private readonly IMapper _mapper;
        private readonly IJwtService _jwtService;
        private readonly IRepositoryAsync<Rol> _repositoryRolAsync;
        public GetProfileJwtHandler(IRepositoryAsync<User> repositoryAsync, IMapper mapper, IJwtService jwtService, IRepositoryAsync<Rol> repositoryRolAsync)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
            _jwtService = jwtService;
            _repositoryRolAsync = repositoryRolAsync;
        }

        public async Task<Response<UserDto>> Handle(GetProfileJwt request, CancellationToken cancellationToken)
        {
            var userId = _jwtService.GetIdUserInToken(request.HttpContext);
            var user = await _repositoryAsync.GetByIdAsync(userId,cancellationToken);
            
            var rol = await _repositoryRolAsync.GetByIdAsync(user.RolId);
            var result = _mapper.Map<UserDto>(user);
            if (rol != default)
                result.Rol = new RolDto() { RolId = rol.RolId, Nombre = rol.Nombre };
            if (user.Image != UserConst.DEFAULTIMAGE)
            {
                result.Image = UserConst.AZURESTORAGEURL + user.Image;
            }
            return new Response<UserDto>(result);
        }
    }
}
