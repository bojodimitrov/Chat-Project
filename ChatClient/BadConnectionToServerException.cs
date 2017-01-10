using System;

namespace ChatClient
{
    class BadConnectionToServerException : Exception
    {
        public string Мessage { get; set; }

        public BadConnectionToServerException(string excMessage, Exception exc) : base(excMessage, exc)
        {
            Мessage = excMessage;
        }
    }
}
