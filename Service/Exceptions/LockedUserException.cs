using System;
using System.Runtime.Serialization;

namespace Service.Exceptions
{
    [Serializable]
    public class LockedUserException : Exception
    {
        public string Time { get; set; }

        public LockedUserException(DateTimeOffset lockedTimeLeft)
        {
            TimeSpan timeSpan = lockedTimeLeft.DateTime.TimeOfDay;

            Time = PutZeros(timeSpan.Hours) + ":" + PutZeros(timeSpan.Minutes) + ":" + PutZeros(timeSpan.Seconds);
        }

        public LockedUserException(string message) : 
            base(message) { }

        public LockedUserException(string message, Exception innerException) : 
            base(message, innerException) { }

        protected LockedUserException(SerializationInfo info, StreamingContext context) : 
            base(info, context) { }

        private static string PutZeros(int number)
        {
            string str = number.ToString();

            if (str.Length == 1)
                return "0" + str;

            return str;
        }
    }
}