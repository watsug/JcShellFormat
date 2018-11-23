namespace Watsug.JcShellFormat
{
    using System;

    public class JcShellFormatException : Exception
    {
        public JcShellFormatException(string message)
            : base (message)
        {
        }
        public JcShellFormatException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}