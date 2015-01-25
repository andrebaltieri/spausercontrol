using SpaUserControl.Domain.Contracts.Services;
using SpaUserControl.Domain.Resources;
using System;
using System.Text.RegularExpressions;

namespace SpaUserControl.Domain.Models
{
    public class User
    {
        #region Private
        private IEmailService _emailService;
        private IPasswordService _passwordService;
        #endregion

        #region Ctor
        public User(string name, string email, IEmailService emailService, IPasswordService passwordService)
        {
            this.Id = Guid.NewGuid();
            this.Name = name;
            this.Email = email;
            this._emailService = emailService;
            this._passwordService = passwordService;
        }
        #endregion

        #region Properties
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        #endregion

        #region Methods
        public void SetPassword(string password, string confirmPassword)
        {
            this.Password = _passwordService.Encrypt(password);
        }
        public string ResetPassword()
        {
            string password = Guid.NewGuid().ToString().Substring(0, 8);
            this.Password = password;

            _emailService.Send(this.Email, String.Format(Messages.ResetPasswordEmailBody, password));
            return password;
        }
        public void ChangeName(string name)
        {
            this.Name = name;
        }
        public void Validate()
        {
            if (this.Name.Length < 3)
                throw new Exception(Errors.InvalidUserName);

            if (!_emailService.IsValid(this.Email))
                throw new Exception(Errors.InvalidUserEmail);

            if (!_passwordService.IsValid(this.Password))
                throw new Exception(Errors.InvalidUserPassword);
        }
        #endregion
    }
}
