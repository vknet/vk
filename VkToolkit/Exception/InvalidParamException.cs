namespace VkToolkit.Exception
{
    public class InvalidParamException : VkApiMethodInvokeException
    {
        public InvalidParamException() { }

        public InvalidParamException(string message) : base(message) { }

        public InvalidParamException(string message, int code) : base(message, code) { }

        public InvalidParamException(string message, int code, System.Exception ex) : base (message, code, ex) { }
    }
}