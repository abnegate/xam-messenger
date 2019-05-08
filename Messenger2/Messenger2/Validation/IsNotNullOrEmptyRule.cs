using System;

namespace Messenger2.Validation
{
    public class IsNotNullOrEmptyRule<T> : IValidationRule<T>
    {
        public string Message { get; set; }

        public bool Check(T value)
        {
            if (value == null) {
                return false;
            }
            var str = value as string;
            return !string.IsNullOrWhiteSpace(str);
        }
    }
}
