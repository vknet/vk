using System;
using System.Runtime.Serialization;

namespace VkToolkit.Exception
{
#if WINDOWS
    [Serializable]
#endif
    public class AccessDeniedException : VkApiMethodInvokeException
    {
        public AccessDeniedException() { }

        public AccessDeniedException(string message, System.Exception ex) : base(message, ex) {}

        public AccessDeniedException(string message) : base(message) { }

        public AccessDeniedException(string message, int code) : base(message, code) { }

        public AccessDeniedException(string message, int code, System.Exception ex) : base(message, code, ex) { }

#if WINDOWS
        protected AccessDeniedException(SerializationInfo info, StreamingContext context) : base(info, context) { }
#endif
    }
}