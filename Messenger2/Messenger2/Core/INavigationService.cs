using System;
using System.Threading.Tasks;
using Messenger2.ViewModels;

namespace Messenger2.Core
{
    public interface INavigationService
    {
        ViewModelBase PreviousPageViewModel { get; }
        Task InitializeAsync();
        Task NavigateToAsync<TViewModel>() where TViewModel : ViewModelBase;
        Task NavigateToAsync<TViewModel>(object parameter) where TViewModel : ViewModelBase;
        Task RemoveLastFromBackStackAsync();
        Task RemoveBackStackAsync();
    }
}
