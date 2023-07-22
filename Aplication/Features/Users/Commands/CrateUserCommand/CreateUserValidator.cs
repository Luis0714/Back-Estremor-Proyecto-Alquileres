using Application.Messages.User;
using FluentValidation;

namespace Application.Features.Users.Commands.CrateUserCommand
{
    public class CreateUserValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserValidator()
        {
            RuleFor(property => property.Name)
                                        .NotEmpty()
                                        .WithMessage(MessageUserErrors.NameRequared);
            RuleFor(property => property.Image)
                                        .NotEmpty()
                                        .WithMessage(MessageUserErrors.ImageRequared);
            RuleFor(property => property.LastName)
                                        .NotEmpty()
                                        .WithMessage(MessageUserErrors.LastNameRequared);
            RuleFor(property => property.DocumentTypeId)
                                        .NotEmpty()
                                        .WithMessage(MessageUserErrors.DocumentTypeIdRequared);
            RuleFor(property => property.Document)
                                        .NotEmpty()
                                        .WithMessage(MessageUserErrors.DocumentRequared);
            RuleFor(property => property.numberPhone)
                                        .NotEmpty()
                                        .WithMessage(MessageUserErrors.NumberPhoneRequared);
            RuleFor(property => property.Email)
                                        .NotEmpty()
                                        .WithMessage(MessageUserErrors.EmailRequared);
            RuleFor(property => property.Password)
                                        .NotEmpty()
                                        .WithMessage(MessageUserErrors.PasswordRequared);
            RuleFor(property => property.RolId)
                                        .NotEmpty()
                                        .GreaterThan(0).WithMessage(MessageUserErrors.RolIdCero)
                                        .WithMessage(MessageUserErrors.RolIdRequared);
        }
    }
}
