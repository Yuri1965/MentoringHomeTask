using System;

namespace PowerManagerLib
{
    internal class PowerManagerException : Exception
    {
        public PowerManagerException(string message) : base(message)
        {
        }
    }
}