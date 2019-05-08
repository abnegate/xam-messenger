using System;
using System.Text.RegularExpressions;

namespace Messenger2.Validation
{
    public class EmailRule<T> : IValidationRule<T>
    {
        public string Message { get; set; }

        public bool Check(T value)
        {
            if (value == null) {
                return false;
            }

            var str = value as string;
            var regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

            Match match = regex.Match(str);

            return match.Success;
        }
    }
}
