using System;
using System.Runtime.Serialization;

namespace VkToolkit.Exception
{

    [Serializable]
    public class VkApiException : System.Exception
    {
        public VkApiException() { }
        public VkApiException(string message) : base(message) { }
        public VkApiException(string message, System.Exception innerException) : base(message, innerException) { }
        protected VkApiException(SerializationInfo info, StreamingContext context) : base (info, context) {}

    }
}