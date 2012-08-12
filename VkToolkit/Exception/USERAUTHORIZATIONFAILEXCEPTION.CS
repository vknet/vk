using System;
using System.Runtime.Serialization;

namespace VkToolkit.Exception
{
#if WINDOWS
    [Serializable]
#endif
    class UserAuthorizationFailException : VkApiMethodInvokeException
    {
        public UserAuthorizationFailException(string message) : base(message)
        {
            
        }

        public UserAuthorizationFailException(string message, int code)
            : base(message, code)
        {

        }
#if WINDOWS
        protected UserAuthorizationFailException(SerializationInfo info, StreamingContext context) : base(info, context) { }
#endif
    }
}
