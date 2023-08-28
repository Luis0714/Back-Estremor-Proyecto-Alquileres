using Application.DTO_s;
using Application.Espesification;
using Application.Execteptions.Validation;
using Application.Interfaces.Repositories;
using Application.Messages.DocumentType;
using Application.Whappers;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.DocumentsTypes.Commands.CreateDocumentTypeCommand
{
    public class CreateDocumentTypeCommand : IRequest<Response<DocumentTypeDto>>
    {
        public string? Name { get; set; }

        public class CreateDocumentTypeCommandHandler : IRequestHandler<CreateDocumentTypeCommand, Response<DocumentTypeDto>>
        {
            private readonly IMapper _mapper;
            private readonly IRepositoryAsync<DocumentType> _repositoryAsync;
            public CreateDocumentTypeCommandHandler(IMapper mapper, IRepositoryAsync<DocumentType> repositoryAsync)
            {
                _mapper = mapper;
                _repositoryAsync = repositoryAsync;
            }
            public async Task<Response<DocumentTypeDto>> Handle(CreateDocumentTypeCommand request, CancellationToken cancellationToken)
            {
                var documentTypeExitente = await _repositoryAsync.GetBySpecAsync(new DocumentTypeForNameSpecification(request.Name),cancellationToken);
                if(documentTypeExitente != null) throw new ApiException(DocumentTypeMessage.DocumentTypeExist); 
                var documentTypeRecord = _mapper.Map<DocumentType>(request);
                var documentTypeSave = await _repositoryAsync.AddAsync(documentTypeRecord,cancellationToken);
                var result = _mapper.Map<DocumentTypeDto>(documentTypeSave);
                return new Response<DocumentTypeDto>(result,DocumentTypeMessage.DocumentTypeCreate);

            }
        }
    }
}
