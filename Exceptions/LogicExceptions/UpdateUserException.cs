using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exceptions
{
    public class UpdateUserException : Exception
    {
        public Error ErrorObject { get; private set; }
        public UpdateUserException(string message, Error errorObject) : base(message)
        {
            ErrorObject = errorObject;
        }
    }
}
