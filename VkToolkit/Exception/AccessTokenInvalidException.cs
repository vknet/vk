namespace VkToolkit.Exception
{
    using System;
    using System.Runtime.Serialization;

#if WINDOWS
    [Serializable]
#endif
    public class AccessTokenInvalidException : VkApiException
    {
        public AccessTokenInvalidException()
        {
        }

        public AccessTokenInvalidException(string message)
            : base(message)
        {
        }

        public AccessTokenInvalidException(string message, Exception ex)
            : base(message, ex)
        {
        }

#if WINDOWS
        protected AccessTokenInvalidException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
#endif
    }
}