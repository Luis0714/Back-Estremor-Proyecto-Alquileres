using Application.DTO_s;
using Application.Espesification;
using Application.Execteptions.Validation;
using Application.Interfaces.Repositories;
using Application.Messages.Rol;
using Application.Whappers;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Roles.Command.CreateRolCommand
{
    public class CreateRolCommand : IRequest<Response<RolDto>>
    {
        public string? Nombre { get; set; }
    }

    public class CreateRolHandler : IRequestHandler<CreateRolCommand, Response<RolDto>>
    {
       
        private readonly IMapper _mapper;
        private readonly IRepositoryAsync<Rol> _repositoryAsync;
        public CreateRolHandler(IMapper mapper, IRepositoryAsync<Rol> repositoryAsync)
        {
            _mapper = mapper;
            _repositoryAsync = repositoryAsync;
        }

    public async Task<Response<RolDto>> Handle(CreateRolCommand request, CancellationToken cancellationToken)
    {
        var record = new Rol() { Nombre = request.Nombre };
        var rolesExistentes = await _repositoryAsync.ListAsync(new RolPorNameSpecification(request.Nombre));
        if (rolesExistentes.Count > 0) throw new ApiException(MessageRolErros.RolExistente);
        var data = await _repositoryAsync.AddAsync(record, cancellationToken);
        var result = _mapper.Map<RolDto>(data);
        return new Response<RolDto>(result, MessageRolErros.RolCreated);
    }
}

}
