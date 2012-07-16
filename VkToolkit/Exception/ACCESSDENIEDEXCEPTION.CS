namespace VkToolkit.Exception
{
    public class AccessDeniedException : VkApiMethodInvokeException
    {
        public AccessDeniedException()
        {
            
        }

        public AccessDeniedException(string message) : base(message)
        {
            
        }

        public AccessDeniedException(string message, int code)
            : base(message, code)
        {

        }

        public AccessDeniedException(string message, int code, System.Exception ex) : base(message, code, ex)
        {
            
        }
    }
}