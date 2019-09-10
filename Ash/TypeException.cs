using System;

namespace Ash
{
    internal class TypeException : Exception
    {
        public TypeException()
        {
        }

        public TypeException(string message) : base(message)
        {
        }

        public TypeException(string message, Exception innerException) : 
            base(message, innerException)
        {
        }
    }
}