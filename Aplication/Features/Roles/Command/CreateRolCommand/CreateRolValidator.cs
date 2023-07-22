using Application.Messages.Rol;
using Application.Messages.User;
using FluentValidation;

namespace Application.Features.Roles.Command.CreateRolCommand
{
    public class CreateRolValidator : AbstractValidator<CreateRolCommand>
    {
        public CreateRolValidator() 
        {
            RuleFor(property => property.Nombre)
                                        .NotEmpty()
                                        .WithMessage(MessageRolErros.NombreVacio);
            RuleFor(property => property.Nombre)
                                        .NotNull()
                                        .WithMessage(MessageRolErros.NombreRequired);
        }
    }
}
