using System;
namespace Messenger2.Validation
{
    public class MinLengthRule<T> : IValidationRule<T>
    {
        public string Message { get; set; }
        public int MinLength { get; set; }
        public bool Check(T value)
        {
            if (value == null) {
                return false;
            }
            var str = value as string;
            return str.Length >= MinLength;
        }
    }
}
