using Application.Whappers;

namespace Application.Interfaces.Services
{
    public interface IMessageSender
    {
        Task<Response<SendGrid.Response?>> SendEmail(string email, string userName, string subject, string templete);
    }
}
