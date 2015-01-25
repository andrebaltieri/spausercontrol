namespace SpaUserControl.Domain.Contracts.Services
{
    public interface IPasswordService
    {
        string Encrypt(string password);
        bool IsValid(string password);
    }
}
