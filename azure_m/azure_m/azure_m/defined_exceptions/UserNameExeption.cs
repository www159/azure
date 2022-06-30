using System;
using System.Runtime.Serialization;

namespace azure_m.defined_exceptions
{
    [Serializable]
    internal class UserNameExeption : Exception
    {
        public UserNameExeption()
        {
        }

        public UserNameExeption(string message) : base(message)
        {
        }

        public UserNameExeption(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected UserNameExeption(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}