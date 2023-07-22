namespace Application.Services.Abstraction.SecurityServices
{
    public interface IPasswordService
    {
        string GeneretePassword(int length);
    }
}
