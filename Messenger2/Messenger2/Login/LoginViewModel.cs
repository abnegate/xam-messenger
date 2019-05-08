using System.Windows.Input;
using Messenger2.Utility;
using Messenger2.Validation;
using Xamarin.Forms;

namespace Messenger2.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        public LoginViewModel() => AddValidations();

        private ValidatableObject<string> email;
        private ValidatableObject<string> password;

        public ValidatableObject<string> UserEmail
        {
            get { return email; }
            set { SetProperty(ref email, value); }
        }

        public ValidatableObject<string> UserPassword
        {
            get { return password; }
            set { SetProperty(ref password, value); }
        }

        public void AddValidations()
        {
            email.Validations.Add(new IsNotNullOrEmptyRule<string> {
                Message = "An email is required."
            });
            email.Validations.Add(new EmailRule<string> {
                Message = "Entered email address is invalid."
            });
            password.Validations.Add(new IsNotNullOrEmptyRule<string> {
                Message = "A password is required."
            });
            password.Validations.Add(new MinLengthRule<string> {
                MinLength = Constants.MIN_PASSWORD_LENGTH,
                Message = $"Password must be at least {Constants.MIN_PASSWORD_LENGTH} characters."
            });
        }

        public ICommand LoginCommand => new Command(async () => await SignInAsync());
        public ICommand NavigateCommand => new Command<string>(NavigateAsync);
    }
}
