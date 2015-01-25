using SpaUserControl.Domain.Models;
using System;

namespace SpaUserControl.Domain.Contracts.Repositories
{
    public interface IUserRepository : IDisposable
    {
        User Get(string email);
        User Get(Guid id);
        void Create(User user);
        void Update(User user);
        void Delete(User user);
    }
}
