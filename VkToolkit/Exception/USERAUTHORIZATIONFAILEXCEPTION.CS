using System;
using System.Runtime.Serialization;

namespace VkToolkit.Exception
{
    [Serializable]
    class UserAuthorizationFailException : VkApiMethodInvokeException
    {
        public UserAuthorizationFailException(string message) : base(message)
        {
            
        }

        public UserAuthorizationFailException(string message, int code)
            : base(message, code)
        {

        }

        protected UserAuthorizationFailException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
