using SpaUserControl.Domain.Contracts.Services;
using System.Text.RegularExpressions;

namespace SpaUserControl.Infraestructure.Services
{
    public class PasswordService : IPasswordService
    {
        public string Encrypt(string password)
        {
            password += "|2d331cca-f6c0-40c0-bb43-6e32989c2881";
            System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] data = md5.ComputeHash(System.Text.Encoding.Default.GetBytes(password));
            System.Text.StringBuilder sbString = new System.Text.StringBuilder();
            for (int i = 0; i < data.Length; i++)
                sbString.Append(data[i].ToString("x2"));
            return sbString.ToString();
        }

        public bool IsValid(string password)
        {
            return password.Length >= 6;
        }
    }
}
