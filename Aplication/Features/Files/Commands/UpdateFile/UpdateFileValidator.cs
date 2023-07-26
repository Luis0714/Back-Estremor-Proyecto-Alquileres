using FluentValidation;

namespace Application.Features.Files.Commands.UpdateFile
{
    public class UpdateFileValidator : AbstractValidator<UpdateFileCommand>
    {
        public UpdateFileValidator()
        {
            //RuleFor(property => property.File)
            //                     .NotEmpty()
            //                     .WithMessage(MessageFileErrors.ImagenRequired);
        }
    }
}
