using SIS.MvcFramework.Attributes.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SULS.App.ViewModels.Users
{
    public class UserRegisterInputModel
    {
        private const string UsernameErrorMessage = "Username lenght should be between 5 and 20 symbols!";
        private const string PasswordErrorMessage = "Password lenght should be between 6 and 20 symbols!";
        private const string EmailErrorMessage = "Email should be valid email!";

        [RequiredSis]
        [StringLengthSis(5, 20, UsernameErrorMessage)]
        public string Username { get; set; }

        [RequiredSis]
        [StringLengthSis(6, 20, PasswordErrorMessage)]
        public string Password { get; set; }

        [RequiredSis]
        public string ConfirmPassword { get; set; }

        [RequiredSis]
        [EmailSis(EmailErrorMessage)]
        public string Email { get; set; }
    }
}
