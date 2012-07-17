using System;
using System.Runtime.Serialization;

namespace VkToolkit.Exception
{
    [Serializable]
    class VkApiAuthorizationException : VkApiException
    {
        public string Email { get; private set; }
        public string Password { get; private set; }

        protected VkApiAuthorizationException(SerializationInfo info, StreamingContext context) : base (info, context) { }
        public VkApiAuthorizationException(string message) : base(message) { }
        public VkApiAuthorizationException(string message, string email, string password) : this(message)
        {
            Email = email;
            Password = password;
        }
    }
}
