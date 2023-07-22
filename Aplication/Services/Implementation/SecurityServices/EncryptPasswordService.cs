using System.Text;
using System.Security.Cryptography;
using Application.Services.Abstraction.SecurityServices;
using Application.Constants;

namespace Application.Services.Implementation.SecurityServices
{
    public class EncryptPasswordService : IEncrypPasswordService
    {
        public string Encrypt(string? password)
        {
            using (var sha256 = SHA256.Create())
            {
                StringBuilder builder = new StringBuilder();
                if (!string.IsNullOrEmpty(password))
                {
                    byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                    for (int i = 0; i < hashedBytes.Length; i++)
                    {
                        builder.Append(hashedBytes[i].ToString(SecurityConst.X2));
                    }
                }
               return builder.ToString();
            }
        }
    }
}
