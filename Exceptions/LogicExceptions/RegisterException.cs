using Model;
using System;
using System.Collections.Generic;

namespace Exceptions
{
    public class RegisterException : Exception
    {
        public Error ErrorObject { get; private set; }
        public RegisterException(string message, Error errorObject) : base(message)
        {
            ErrorObject = errorObject;
        }
    }
}
