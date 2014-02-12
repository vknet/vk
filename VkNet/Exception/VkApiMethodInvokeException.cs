namespace VkNet.Exception
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
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


        protected VkApiMethodInvokeException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

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