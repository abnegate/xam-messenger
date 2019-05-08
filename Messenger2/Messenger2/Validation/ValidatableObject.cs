using System;
using System.Collections.Generic;

namespace Messenger2.Validation
{
    public class ValidatableObject<T>
    {
        public HashSet<IValidationRule<T>> Validations { get; set; } = new HashSet<IValidationRule<T>>();

        public ValidatableObject()
        {
        }
    }
}
