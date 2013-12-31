namespace VkToolkit.Exception
{
    using System;
    using System.Runtime.Serialization;

#if WINDOWS
    [Serializable]
#endif
    internal class UserAuthorizationFailException : VkApiMethodInvokeException
    {
        public UserAuthorizationFailException(string message)
            : base(message)
        {
        }

        public UserAuthorizationFailException(string message, int code)
            : base(message, code)
        {
        }

#if WINDOWS
        protected UserAuthorizationFailException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
#endif
    }
}