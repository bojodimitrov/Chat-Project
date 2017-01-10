using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatClient
{
    class SocketNotInitializedException : Exception
    {
        public string Message { get; set; }

        public SocketNotInitializedException(string excMessage, Exception exc) : base(excMessage, exc)
        {
            Message = excMessage;
        }
    }
}
