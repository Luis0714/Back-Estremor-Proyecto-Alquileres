using Application.Espesification;
using Application.Execteptions.Validation;
using Application.Interfaces.Repositories;
using Application.Messages.Emails;
using Application.Messages.User;
using Application.Services.Abstraction.SecurityServices;
using Application.Whappers;
using Domain.Entities;
using MediatR;
using SendGrid;
using Shared.Services;

namespace Application.Features.Users.Commands.ResetPassword
{
    public class ResetPasswordCommand : IRequest<Response<bool>>
    {
        public string? Email { get; set; }

    }

    public class ResetPasswordHandler : IRequestHandler<ResetPasswordCommand, Response<bool>>
    {
        private readonly IRepositoryAsync<User> _repositoryAsync;
        private readonly IMessageEmailSender _messageSender;
        private readonly IPasswordService _passwordService;
        private readonly IEncrypPasswordService _encrypPasswordService;
        public ResetPasswordHandler(IRepositoryAsync<User> repositoryAsync, IMessageEmailSender messageSender, IPasswordService passwordService, IEncrypPasswordService encrypPasswordService)
        {
            _repositoryAsync = repositoryAsync;
            _messageSender = messageSender;
            _passwordService = passwordService;
            _encrypPasswordService = encrypPasswordService;
        }

        public async Task<Response<bool>> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
            var lista = await _repositoryAsync.ListAsync(new GetUserByEmail(request.Email));
            var user = lista.FirstOrDefault();
            if (user == null) throw new ApiException(MessageUserErrors.UserExist);
            var response = await sendPassword(user);
            if(response) await _repositoryAsync.UpdateAsync(user);
            return new Response<bool>(response);
        }

        private async Task<bool> sendPassword(User user)
        {
            var to = user.Email;
            var newPassword = _passwordService.GeneretePassword(10);
            var templete = Properties.Resources.ResetPasswordTemplete.ToString();
            templete = replaceValues(templete, user, newPassword);
            user.Password = _encrypPasswordService.Encrypt(newPassword);

            if (string.IsNullOrEmpty(user.Email))
                throw new ApiException(MessageUserErrors.EmailRequared);

           return await _messageSender.SendEmail(to, ConstEmail.NameFromEmail, ConstEmail.SubjetResetPassword, templete);
        }

        private string replaceValues(string templete, User user, string newPassword)
        {
            templete = templete.Replace("@Asunto", ConstEmail.SubjetResetPassword);
            templete = templete.Replace("@nombre", user.Name);
            templete = templete.Replace("@contrasena", newPassword);
            return templete;
        }
    }
}
