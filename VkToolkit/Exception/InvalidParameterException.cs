namespace VkToolkit.Exception
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class InvalidParameterException : VkApiMethodInvokeException
    {
        public InvalidParameterException()
        {
        }

        public InvalidParameterException(string message)
            : base(message)
        {
        }

        public InvalidParameterException(string message, Exception ex)
            : base(message, ex)
        {
        }

        public InvalidParameterException(string message, int code)
            : base(message, code)
        {
        }

        public InvalidParameterException(string message, int code, Exception ex)
            : base(message, code, ex)
        {
        }

        protected InvalidParameterException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}