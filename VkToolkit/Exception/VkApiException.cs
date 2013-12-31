namespace VkToolkit.Exception
{
    using System;
    using System.Runtime.Serialization;

#if WINDOWS
    [Serializable]
#endif
    public class VkApiException : Exception
    {
        public VkApiException()
        {
        }

        public VkApiException(string message)
            : base(message)
        {
        }

        public VkApiException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

#if WINDOWS
        protected VkApiException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
#endif
    }
}