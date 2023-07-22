using Application.Interfaces;
using Application.Messages.User;
using Application.Services.Abstraction.FileServices;
using Application.Whappers;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Features.Files.UploadFile
{
    public class UploadFileCommand : IRequest<Response<string>>
    {
        public IFormFile? File { get; set; }

        public class UploadFileCommandHandler : IRequestHandler<UploadFileCommand, Response<string>>
        {
            private readonly IFileService _fileService;

            public UploadFileCommandHandler(IFileService fileService)
            {
                _fileService = fileService;
            }

            public Task<Response<string>> Handle(UploadFileCommand request, CancellationToken cancellationToken)
            {
                if (request.File == null) 
                    throw new ArgumentException(MessageUserErrors.ImageRequared);
                string ruta = _fileService.UploadFile(request.File);
                var result = new Response<string>(ruta, ruta);
                return Task.FromResult(result);
            }
        }
    }
}
