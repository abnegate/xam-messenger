using System;
using Xamarin.Forms;

namespace Messenger2.Behaviour
{
    public abstract class BindableBehavior<T> : Behavior<T> where T : BindableObject
    {
        public T AssociatedObject { get; private set; }

        public virtual void OnAttachTo(T bindable)
        {
            base.OnAttachedTo(bindable);
            AssociatedObject = bindable;

            if (bindable.BindingContext != null) {
                BindingContext = bindable.BindingContext;
            }
            bindable.BindingContextChanged += OnBindingContextChanged;
        }

        protected virtual void OnDetatchingFrom(T bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.BindingContextChanged -= OnBindingContextChanged;
            AssociatedObject = null;
        }

        void OnBindingContextChanged(object sender, EventArgs e)
        {
            base.OnBindingContextChanged();
            BindingContext = AssociatedObject.BindingContext;
        }
    }
}
