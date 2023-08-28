using Application.DTO_s;
using Application.Features.Roles.Querys.GetAllRoles;
using Application.Interfaces.Repositories;
using Application.Whappers;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.DocumentsTypes.Querys.GetAllDocumenstsTypesQuery
{
    public class GetAllDocumentTypeQuery : IRequest<Response<List<DocumentTypeDto>>>
    {

    }
    public class GetAllDocumentTypeQueryHandler : IRequestHandler<GetAllDocumentTypeQuery, Response<List<DocumentTypeDto>>>
    {
        private readonly IRepositoryAsync<DocumentType> _repositoryAsync;
        private readonly IMapper _mapper;
        public GetAllDocumentTypeQueryHandler(IRepositoryAsync<DocumentType> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<List<DocumentTypeDto>>> Handle(GetAllDocumentTypeQuery request, CancellationToken cancellationToken)
        {
            var lista = await _repositoryAsync.ListAsync(cancellationToken);
            var result = _mapper.Map<List<DocumentTypeDto>>(lista.ToList());
            result.OrderBy(documetType => documetType.Name);
            return new Response<List<DocumentTypeDto>>(result);
        }
    }
}
