using System;
using System.Globalization;
using System.Reflection;
using Autofac;
using Messenger2.ViewModels;
using Xamarin.Forms;

namespace Messenger2.Core
{
    public static class ViewModelLocator
    {
        public static readonly BindableProperty AutoWireViewModel = BindableProperty.Create("AutoWireViewModel", typeof(bool), typeof(ViewModelLocator), false, propertyChanged: OnAutoWireViewModelChanged);

        private static readonly Lazy<IContainer> container = new Lazy<IContainer>(() => {
            var builder = new ContainerBuilder();
            builder.RegisterType<AppShellViewModel>();
            builder.RegisterType<LoginViewModel>();
            builder.RegisterType<NavigationService>()
                .As<INavigationService>()
                .SingleInstance();

            return builder.Build();
        });
        public static IContainer Container { get { return container.Value; } }

        private static void OnAutoWireViewModelChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (!(bindable is Element view)) {
                return;
            }

            var viewType = view.GetType();
            var viewName = viewType.FullName.Replace(".Views.", ".ViewModels.");
            var viewAssemblyName = viewType.GetTypeInfo().Assembly.FullName;
            var viewModelName = string.Format(CultureInfo.InvariantCulture, "{0}Model, {1}", viewName, viewAssemblyName);

            var viewModelType = Type.GetType(viewModelName);
            if (viewModelType == null) {
                return;
            }
            var viewModel = Container.Resolve(viewModelType);
            view.BindingContext = viewModel;
        }
    }
}
