using SendGrid.Helpers.Mail;
using SendGrid;
using Microsoft.Extensions.Configuration;
using Shared.Messages.Emails;
using Shared.Contants;

namespace Shared.Services.Implementation
{
    public class MessageSenderService : IMessageEmailSender
    {
        private readonly IConfiguration _configuration;
        public MessageSenderService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<bool> SendEmail(string email, string userName, string subject, string templete)
        {
            var _apiKey = _configuration.GetSection(GeneralConstants.APIKEY).Get<string>();
            var client = new SendGridClient(_apiKey);
            var from = new EmailAddress(ConstEmail.FormEmail, userName);
            var to = new EmailAddress(email, userName);
            var plainTextContent = "";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, templete);
            var response = await client.SendEmailAsync(msg);
            return response.IsSuccessStatusCode;
        }
    }
}
