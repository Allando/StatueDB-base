using System;

namespace StatueApp.CustomException
{
    class ListEmptyException : Exception
    {
        public ListEmptyException()
        { }

        public ListEmptyException(string message) : base(message) { }
    }
}
