using Application.Messages.User;
using FluentValidation;

namespace Application.Features.Users.Commands.ResetPassword
{
    public class ResetPasswordValidator : AbstractValidator<ResetPasswordCommand> 
    {
        public ResetPasswordValidator()
        {
            RuleFor(property => property.Email)
                                      .NotEmpty()
                                      .WithMessage(MessageUserErrors.NameRequared);
            }
    }
}
