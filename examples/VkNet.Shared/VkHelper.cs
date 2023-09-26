using System;
using VkNet.Enums.Filters;
using VkNet.Model;

namespace VkNet.Shared;

/// <summary>
/// Методы расширения
/// </summary>
public static class VkHelper
{
	/// <summary>
	/// Авторизация
	/// </summary>
	/// <param name="api">Экземпляр API</param>
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