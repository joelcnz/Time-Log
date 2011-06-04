using System;

namespace TimeLog
{
    public class InvalidCommandlineException : Exception
    {
        public InvalidCommandlineException(string message)
            : base(message)
        {
        }
    }
}