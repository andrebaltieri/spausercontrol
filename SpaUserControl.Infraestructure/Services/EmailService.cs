using SpaUserControl.Domain.Contracts.Services;

namespace SpaUserControl.Infraestructure.Services
{
    public class EmailService : IEmailService
    {
        public bool IsValid(string email)
        {
            return email.Length >= 5;
        }

        public void Send(string to, string body)
        {
            // TODO
        }
    }
}
