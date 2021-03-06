﻿using System;

namespace StatueApp.CustomException
{
    class HttpErrorException : Exception
    {
        /// <summary>
        /// Gør så man kan lave en custom Exception, med http exceptions
        /// </summary>
        public HttpErrorException()
        {}

        public HttpErrorException(string message) : base(message){}
    }
}
