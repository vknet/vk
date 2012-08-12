using System;
using System.Runtime.Serialization;

namespace VkToolkit.Exception
{
#if WINDOWS
    [Serializable]
#endif
    public class TooManyRequestsException : VkApiMethodInvokeException
    {
        public TooManyRequestsException() { }
        public TooManyRequestsException(string message) : base(message) {}
        public TooManyRequestsException(string message, int code) : base(message, code) {}
        public TooManyRequestsException(string message, System.Exception ex) : base(message, ex) { }
#if WINDOWS
        protected TooManyRequestsException(SerializationInfo info, StreamingContext context) : base(info, context) { }
#endif
    }
}