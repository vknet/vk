namespace VkToolkit.Exception
{
    using System;
    using System.Runtime.Serialization;


    [Serializable]
    public class AccessDeniedException : VkApiMethodInvokeException
    {
        public AccessDeniedException()
        {
        }

        public AccessDeniedException(string message, Exception ex)
            : base(message, ex)
        {
        }

        public AccessDeniedException(string message)
            : base(message)
        {
        }

        public AccessDeniedException(string message, int code)
            : base(message, code)
        {
        }

        public AccessDeniedException(string message, int code, Exception ex)
            : base(message, code, ex)
        {
        }

        protected AccessDeniedException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}