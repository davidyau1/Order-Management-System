using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class InvalidOrderStateException : Exception
    {
        public InvalidOrderStateException(string msg):base(msg)
        {

        }   
    }
}
