using System;

namespace ChatClient
{
    class BadConnectionToServerException : Exception
    {
        public string Notification { get; set; }

        public BadConnectionToServerException(string excMessage, Exception exc) : base(excMessage, exc)
        {
            Notification = excMessage;
        }

        public BadConnectionToServerException(string excMessage)
        {
            Notification = excMessage;
        }
    }

    
}
