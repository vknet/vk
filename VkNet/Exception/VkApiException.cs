namespace VkNet.Exception
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
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

        protected VkApiException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}