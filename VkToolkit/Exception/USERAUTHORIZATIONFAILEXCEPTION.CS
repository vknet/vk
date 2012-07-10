using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VkToolkit.Exception
{
    class UserAuthorizationFailException : VkApiException
    {
        public UserAuthorizationFailException(string message) : base(message)
        {
            
        }
    }
}
