using System;

namespace Typhoon.Infrastructure
{
    public class ElementNotFoundException : Exception
    {
        public ElementNotFoundException(string exception) : base(exception)
        {
            
        }

        public ElementNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
