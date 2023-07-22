using Application.DTO_s;
using Application.Interfaces.Repositories;
using Application.Whappers;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Roles.Querys.GetAllRoles
{
    public class GetAllRoles : IRequest<Response<List<RolDto>>>
    {


    }

    public class GetAllRolesHandler : IRequestHandler<GetAllRoles, Response<List<RolDto>>>
    {
        private readonly IRolRepository<Rol> _repositoryAsync;
        private readonly IMapper _mapper;
        public GetAllRolesHandler(IRolRepository<Rol> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<List<RolDto>>> Handle(GetAllRoles request, CancellationToken cancellationToken)
        {
            var lista = await _repositoryAsync.ListAsync(cancellationToken);
            var result = _mapper.Map<List<RolDto>>(lista.ToList());
            return new Response<List<RolDto>>(result);
        }

    }
}
