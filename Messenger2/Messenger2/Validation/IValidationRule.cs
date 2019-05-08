using System;
namespace Messenger2.Validation
{
    public interface IValidationRule<T>
    {
        string Message { get; set; }
        bool Check(T value);
    }
}
