using System;
using System.Runtime.Serialization;

namespace VkToolkit.Exception
{
    [Serializable]
    public class AccessTokenInvalidException : VkApiException
    {
        public AccessTokenInvalidException() {}
        public AccessTokenInvalidException(string message) : base(message) {}
        public AccessTokenInvalidException(string message, System.Exception ex) : base(message, ex) {}
        protected AccessTokenInvalidException(SerializationInfo info, StreamingContext context) : base(info, context) {}
    }
}