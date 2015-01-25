namespace SpaUserControl.Domain.Contracts.Services
{
    public interface IEmailService
    {
        bool IsValid(string email);
        void Send(string to, string body);
    }
}
