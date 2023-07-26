using Application.Whappers;
using MediatR;

namespace Application.Features.Files.Commands.UpdateFile
{
    public class UpdateFileCommand : IRequest<Response<string>>
    {
    }
}
