using System;

namespace StatueApp.CustomException
{
    class ServerErrorException : Exception
    {
        public ServerErrorException()
        { }

        public ServerErrorException(string message) : base(message) { }
    }
}
