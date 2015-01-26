namespace SpaUserControl.Domain.Contracts.Services
{
    public interface INotificationService
    {
        void Send(string to, string body);
    }
}
