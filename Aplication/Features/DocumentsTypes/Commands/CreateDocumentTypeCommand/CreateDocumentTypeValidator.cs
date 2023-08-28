using Application.Messages.DocumentType;
using Application.Messages.Rol;
using FluentValidation;

namespace Application.Features.DocumentsTypes.Commands.CreateDocumentTypeCommand
{
    public class CreateDocumentTypeValidator : AbstractValidator<CreateDocumentTypeCommand>
    {
        public CreateDocumentTypeValidator() 
        {
            RuleFor(property => property.Name)
                                       .NotEmpty()
                                       .WithMessage(DocumentTypeMessage.DocumentTypeNameReqired);
        }
    }
}
