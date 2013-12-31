namespace VkToolkit.Exception
{
    using System;
    using System.Runtime.Serialization;

#if WINDOWS
    [Serializable]
#endif
    public class InvalidParamException : VkApiMethodInvokeException
    {
        public InvalidParamException()
        {
        }

        public InvalidParamException(string message)
            : base(message)
        {
        }

        public InvalidParamException(string message, Exception ex)
            : base(message, ex)
        {
        }

        public InvalidParamException(string message, int code)
            : base(message, code)
        {
        }

        public InvalidParamException(string message, int code, Exception ex)
            : base(message, code, ex)
        {
        }

#if WINDOWS
        protected InvalidParamException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
#endif
    }
}