using SIS.MvcFramework.Attributes.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SULS.App.ViewModels.Users
{
    public class UserLoginInputModel
    {
        private const string UsernameErrorMessage = "Username lenght should be between 5 and 20 symbols!";
        private const string PasswordErrorMessage = "Password lenght should be between 6 and 20 symbols!";

        [RequiredSis]
        [StringLengthSis(5, 20, UsernameErrorMessage)]
        public string Username { get; set; }

        [RequiredSis]
        [StringLengthSis(6, 20, PasswordErrorMessage)]
        public string Password { get; set; }
    }
}
