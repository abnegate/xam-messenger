using Messenger2.Core;
using Messenger2.Views;
using Autofac;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Messenger2
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShellView();

            InitNavigation();
        }

        private Task InitNavigation()
        {
            var navigationService = ViewModelLocator.Container.Resolve<INavigationService>();
            return navigationService.InitializeAsync();
        }
    }
}