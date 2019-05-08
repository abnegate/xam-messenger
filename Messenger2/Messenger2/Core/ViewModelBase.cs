using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Messenger2.Core;

namespace Messenger2.ViewModels
{
    public abstract class ViewModelBase : ExtendedBindableObject
    {
        private bool isBusy;
        public bool IsBusy
        {
            get { return isBusy; }
            set {
                if (isBusy != value) {
                    isBusy = value;
                    RaisePropertyChanged(() => IsBusy);
                }
            }
        }
    }
}
