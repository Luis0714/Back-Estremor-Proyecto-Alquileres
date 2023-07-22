namespace Application.Services.Abstraction.SecurityServices
{
    public interface IEncrypPasswordService
    {
        string Encrypt(string? password);
    }
}
