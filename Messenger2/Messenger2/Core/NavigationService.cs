using System;
using System.Threading.Tasks;
using Messenger2.Views;
using Messenger2.ViewModels;
using Xamarin.Forms;
using System.Globalization;
using System.Reflection;

namespace Messenger2.Core
{
    public class NavigationService : INavigationService
    {
        public NavigationService()
        {
        }

        public ViewModelBase PreviousPageViewModel => throw new NotImplementedException();

        public Task InitializeAsync()
        {
            if (string.IsNullOrEmpty(Settings.AuthAccessToken)) {
                return NavigateToAsync<LoginViewModel>();
            }
            return NavigateToAsync<MainViewModel>();
        }

        public Task NavigateToAsync<TViewModel>() where TViewModel : ViewModelBase
        {
            return InternalNavigateToAsync(typeof(TViewModel), null);
        }

        public Task NavigateToAsync<TViewModel>(object parameter) where TViewModel : ViewModelBase
        {
            return InternalNavigateToAsync(typeof(TViewModel), parameter);
        }

        public Task RemoveBackStackAsync() => throw new NotImplementedException();
        public Task RemoveLastFromBackStackAsync() => throw new NotImplementedException();

        private async Task InternalNavigateToAsync(Type viewModelType, object parameter)
        {
            Page page = CreatePage(viewModelType, parameter);

            if (page is LoginView) {
                Application.Current.MainPage = new CustomNavigationView(page);
            } else {
                if (Application.Current.MainPage is CustomNavigationView navigationPage) {
                    await navigationPage.PushAsync(page);
                } else {
                    Application.Current.MainPage = new CustomNavigationView(page);
                }
            }

            await (page.BindingContext as ViewModelBase).InitializeAsync(parameter);
        }

        private Type GetPageTypeForViewModel(Type viewModelType)
        {
            var viewName = viewModelType.FullName.Replace("Model", string.Empty);
            var viewModelAssemblyName = viewModelType.GetTypeInfo().Assembly.FullName;
            var viewAssemblyName = string.Format(CultureInfo.InvariantCulture, "{0}, {1}", viewName, viewModelAssemblyName);
            var viewType = Type.GetType(viewAssemblyName);
            return viewType;
        }

        private Page CreatePage(Type viewModelType, object parameter)
        {
            Type pageType = GetPageTypeForViewModel(viewModelType);
            if (pageType == null) {
                throw new Exception($"Cannot locate page type for {viewModelType}");
            }

            var page = Activator.CreateInstance(pageType) as Page;
            return page;
        }
    }
}
