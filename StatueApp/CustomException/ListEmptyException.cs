using System;

namespace StatueApp.CustomException
{
    class ListEmptyException : Exception
    {
        /// <summary>
        /// Gør så man kan lave en custom Exception, med ListEmpty exceptions
        /// </summary>
        public ListEmptyException()
        { }

        public ListEmptyException(string message) : base(message) { }
    }
}
