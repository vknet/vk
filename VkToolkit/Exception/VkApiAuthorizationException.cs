using System;
using System.Runtime.Serialization;

namespace VkToolkit.Exception
{
#if WINDOWS
    [Serializable]
#endif
    class VkApiAuthorizationException : VkApiException
    {
        public string Email { get; private set; }
        public string Password { get; private set; }

#if WINDOWS
        protected VkApiAuthorizationException(SerializationInfo info, StreamingContext context) : base (info, context) { }
#endif
        public VkApiAuthorizationException(string message) : base(message) { }
        public VkApiAuthorizationException(string message, string email, string password) : this(message)
        {
            Email = email;
            Password = password;
        }
    }
}
