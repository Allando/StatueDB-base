using System;

namespace StatueApp.CustomException
{
    class HttpErrorException : Exception
    {
        public HttpErrorException()
        {}

        public HttpErrorException(string message) : base(message){}
    }
}
