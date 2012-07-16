namespace VkToolkit.Exception
{
    public class VkApiMethodInvokeException : VkApiException
    {
        public int ErrorCode { get; private set; }

        public VkApiMethodInvokeException()
        {
            
        }

        public VkApiMethodInvokeException(string message) : base(message)
        {
            
        }

        public VkApiMethodInvokeException(string message, int code) : base(message)
        {
            ErrorCode = code;
        }

        public VkApiMethodInvokeException(string message, int code, System.Exception ex)
            : base(message, ex)
        {
            ErrorCode = code;
        }
    }
}