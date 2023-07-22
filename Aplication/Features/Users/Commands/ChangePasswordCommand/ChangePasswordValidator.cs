using Application.Messages.User;
using FluentValidation;

namespace Application.Features.Users.Commands.ChangePasswordCommand
{
    public class ChangePasswordValidator : AbstractValidator<ChangePasswordCommand>
    {
        public ChangePasswordValidator()
        {
            RuleFor(property => property.Email)
                                      .NotEmpty()
                                      .WithMessage(MessageUserErrors.NameRequared);
            RuleFor(property => property.CurentPassword)
                                        .NotEmpty()
                                        .WithMessage(MessageUserErrors.ImageRequared);
            RuleFor(property => property.NewPassword)
                                        .NotEmpty()
                                        .WithMessage(MessageUserErrors.ImageRequared);
            RuleFor(property => property.ComfirmNewPassword)
                                        .NotEmpty()
                                        .WithMessage(MessageUserErrors.ImageRequared);
        }
    }
}
