using Application.Whappers;
using MediatR;

namespace Application.Features.Files.Commands.DeleteFile
{
    public class DeleteFileCommand : IRequest<Response<bool>>
    {
    }
}
