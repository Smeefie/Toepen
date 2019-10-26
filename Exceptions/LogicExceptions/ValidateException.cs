using Model;
using System;
using System.Collections.Generic;

namespace Exceptions
{
    public class ValidateException : Exception
    {
        public ValidateException(string message) : base(message)
        {
        }
    }
}
