using System;
using System.Linq.Expressions;
using System.Reflection;
using Xamarin.Forms;

namespace Messenger2.Core
{
    public abstract class ExtendedBindableObject : BindableObject
    {
        public void RaisePropertyChanged<T>(Expression<Func<T>> property)
        {
            var name = GetMemberInfo(property).Name;
            OnPropertyChanged(name);
        }

        private MemberInfo GetMemberInfo(Expression expression)
        {
            return (expression as MemberExpression).Member;
        }
    }
}
