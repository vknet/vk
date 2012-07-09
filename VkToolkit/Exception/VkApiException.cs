namespace VkToolkit.Exception
{
    public class VkApiException : System.Exception
    {
        public VkApiException() { }
        public VkApiException(string message) : base(message) { }
        public VkApiException(string message, System.Exception innerException) : base(message, innerException) { }

    }
}