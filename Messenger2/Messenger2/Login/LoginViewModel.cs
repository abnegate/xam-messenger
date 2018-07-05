using System;
using System.Collections.Generic;
using System.Text;

namespace Messenger2.ViewModels
{
    class LoginViewModel : BaseViewModel
    {
        private string email;
        private string password;

        public string Email
        {
            get { return email; }
            set { SetProperty(ref email, value); }
        }

        public string Password
        {
            get { return password; }
            set { SetProperty(ref password, value); }
        }
    }
}
