using System;
using System.Runtime.Serialization;

namespace VkToolkit.Exception
{
#if WINDOWS
    [Serializable]
#endif
    public class InvalidParamException : VkApiMethodInvokeException
    {
        public InvalidParamException() { }
        public InvalidParamException(string message) : base(message) { }
        public InvalidParamException(string message, System.Exception ex) : base (message, ex) { }
        public InvalidParamException(string message, int code) : base(message, code) { }
        public InvalidParamException(string message, int code, System.Exception ex) : base (message, code, ex) { }
#if WINDOWS
        protected InvalidParamException(SerializationInfo info, StreamingContext context) : base (info, context) { }
#endif
    }
}