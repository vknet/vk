namespace VkToolkit.Exception
{
    using System;
    using System.Runtime.Serialization;

#if WINDOWS
    [Serializable]
#endif
    public class VkApiMethodInvokeException : VkApiException
    {
        public int ErrorCode { get; private set; }

        public VkApiMethodInvokeException()
        {
        }

        public VkApiMethodInvokeException(string message)
            : base(message)
        {
        }

#if WINDOWS
        protected VkApiMethodInvokeException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
#endif

        public VkApiMethodInvokeException(string message, Exception ex)
            : base(message, ex)
        {
        }

        public VkApiMethodInvokeException(string message, int code)
            : base(message)
        {
            ErrorCode = code;
        }

        public VkApiMethodInvokeException(string message, int code, Exception ex)
            : base(message, ex)
        {
            ErrorCode = code;
        }
    }
}