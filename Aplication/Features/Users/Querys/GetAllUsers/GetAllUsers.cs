using Application.Constants;
using Application.DTO_s;
using Application.Espesification;
using Application.Interfaces.Repositories;
using Application.Whappers;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Users.Querys.GetAllUsers
{
    public class GetAllUsers : IRequest<Response<List<UserDto>>>
    {

    }
    public class GetAlluserHandler : IRequestHandler<GetAllUsers, Response<List<UserDto>>>
    {
        private readonly IRepositoryAsync<User> _repositoryAsync;
        private readonly IRolRepository<Rol> _repositoryRolAsync;
        private readonly IMapper _mapper;
        public GetAlluserHandler(IRepositoryAsync<User> repositoryAsync, IMapper mapper, IRolRepository<Rol> repositoryRolAsync)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
            _repositoryRolAsync = repositoryRolAsync;
        }

        public async Task<Response<List<UserDto>>> Handle(GetAllUsers request, CancellationToken cancellationToken)
        {
            var lista = await _repositoryAsync.ListAsync(new GetAllUserSpecification(), cancellationToken);
            var result = new List<UserDto>();
            var roles = await _repositoryRolAsync.ListAsync(cancellationToken);
            lista.ForEach(user =>
            {
                var userDTO = _mapper.Map<UserDto>(user);
                var rol = roles.FirstOrDefault(rol => rol.RolId == userDTO.RolId);
                if(rol != null) 
                    userDTO.Rol = new RolDto() { RolId = rol.RolId, Nombre = rol.Nombre};
                if(user.Image != UserConst.DEFAULTIMAGE)
                {
                    userDTO.Image = UserConst.AZURESTORAGEURL + user.Image;
                }
                result.Add(userDTO);
            });
            return new Response<List<UserDto>>(result);
        }
    }
}
