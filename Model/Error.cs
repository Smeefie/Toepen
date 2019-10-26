using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Error
    {
        //0 - No Errors
        //1 - Errors
        public int errorState { get; private set; }
        public List<string> errorKey { get; private set; }
        public List<string> errorMessage { get; private set; }

        public Error()
        {
            errorKey = new List<string>();
            errorMessage = new List<string>();
        }

        public void AddErrorMessage(string key, string message)
        {
            errorState = 1;
            errorKey.Add(key);
            errorMessage.Add(message);
        }

        public int GetErrorState()
        {
            return errorState;
        }
    }
}
