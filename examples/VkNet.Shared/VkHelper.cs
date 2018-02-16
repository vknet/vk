using System;
using VkNet.Enums.Filters;

namespace VkNet.Shared
{
    public static class VkHelper
    {
        public static void Auth(this VkApi api)
        {
            api.Authorize(new ApiAuthParams
            {
                ApplicationId = 123456,
                Login = "Login",
                Password = "Password",
                Settings = Settings.All,
                TwoFactorAuthorization = () =>
                {
                    Console.WriteLine("Enter Code:");
                    return Console.ReadLine();
                }
            });
        }
    }
}