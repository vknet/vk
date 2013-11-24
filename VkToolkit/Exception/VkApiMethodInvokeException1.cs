using System.Runtime.Serialization;
using System;

namespace VkToolkit.Exception
{
#if WINDOWS
    [Serializable]
#endif
    public class VkApiMethodInvokeException : VkApiException
    {
        public int ErrorCode { get; private set; }

        public VkApiMethodInvokeException() { }
        public VkApiMethodInvokeException(string message) : base(message) { }
#if WINDOWS
        protected VkApiMethodInvokeException(SerializationInfo info, StreamingContext context) : base(info, context) { }
#endif
        public VkApiMethodInvokeException(string message, System.Exception ex) : base(message, ex) {}

        public VkApiMethodInvokeException(string message, int code) : base(message)
        {
            ErrorCode = code;
        }

        public VkApiMethodInvokeException(string message, int code, System.Exception ex)
            : base(message, ex)
        {
            ErrorCode = code;
        }
    }
}