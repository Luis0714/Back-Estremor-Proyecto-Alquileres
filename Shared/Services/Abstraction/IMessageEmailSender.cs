namespace Shared.Services
{
    public interface  IMessageEmailSender
    {
        Task<bool> SendEmail(string email, string userName, string subject, string templete);
    }
}
