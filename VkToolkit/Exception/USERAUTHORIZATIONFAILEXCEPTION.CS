using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VkToolkit.Exception
{
    class UserAuthorizationFailException : VkApiMethodInvokeException
    {
        public UserAuthorizationFailException(string message) : base(message)
        {
            
        }

        public UserAuthorizationFailException(string message, int code)
            : base(message, code)
        {

        }
    }
}
