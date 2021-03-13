using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Service.Exceptions
{
    [Serializable]
    public class WrongPasswordException : Exception
    {
        public int TryCount { get; set; }

        public WrongPasswordException(int tryCount, int maxTries)
        {
            TryCount = maxTries - tryCount;
        }

        public WrongPasswordException(string message) : 
            base(message) { }

        public WrongPasswordException(string message, Exception innerException) : 
            base(message, innerException) { }

        protected WrongPasswordException(SerializationInfo info, StreamingContext context) : 
            base(info, context) { }
    }
}
