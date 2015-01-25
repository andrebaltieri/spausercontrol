using SpaUserControl.Business.Resources;
using SpaUserControl.Domain.Contracts.Repositories;
using SpaUserControl.Domain.Contracts.Services;
using SpaUserControl.Domain.Models;
using System;

namespace SpaUserControl.Business.Services
{
    public class UserService : IUserService
    {
        private IEmailService _emailService;
        private IPasswordService _passwordService;
        private IUserRepository _repository;

        public UserService(IUserRepository repository, IEmailService emailService, IPasswordService passwordService)
        {
            this._repository = repository;
            this._emailService = emailService;
            this._passwordService = passwordService;
        }

        public User Authenticate(string email, string password)
        {
            var user = GetByEmail(email);

            if (user.Password != password)
                throw new Exception(Errors.InvalidCredentials);

            return user;
        }

        public void ChangeInformation(string email, string name)
        {
            var user = GetByEmail(email);

            user.ChangeName(name);
            user.Validate();

            _repository.Update(user);
        }

        public void ChangePassword(string email, string password, string newPassword, string confirmNewPassword)
        {
            var user = Authenticate(email, password);

            user.SetPassword(newPassword, confirmNewPassword);
            user.Validate();

            _repository.Update(user);
        }

        public void Delete(string email)
        {
            var user = GetByEmail(email);
            _repository.Delete(user);
        }

        public void Register(string name, string email, string password, string confirmPassword)
        {
            var user = new User(name, email,_emailService, _passwordService);
            user.SetPassword(password, confirmPassword);
            user.Validate();

            _repository.Create(user);
        }

        public User GetByEmail(string email)
        {
            var user = _repository.Get(email);
            if (user == null)
                throw new Exception(Errors.UserNotFound);

            return user;
        }

        public void ResetPassword(string email)
        {
            var user = GetByEmail(email);
            user.ResetPassword();
            user.Validate();

            _repository.Update(user);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
