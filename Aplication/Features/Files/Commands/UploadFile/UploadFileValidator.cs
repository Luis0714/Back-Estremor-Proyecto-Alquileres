using Application.Features.Files.UploadFile;
using Application.Messages.File;
using FluentValidation;

namespace Application.Features.Files.Commands.UploadFile
{
    public class UploadFileValidator : AbstractValidator<UploadFileCommand>
    {
        public UploadFileValidator()
        {
            RuleFor(property => property.File)
                                   .NotEmpty()
                                   .WithMessage(MessageFileErrors.ImagenRequired);

        }
    }
}
