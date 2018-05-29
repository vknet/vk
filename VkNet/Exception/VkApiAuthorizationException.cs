using System;

namespace VkNet.Exception
{
	/// <summary>
	/// Исключение, которое выбрасывается при попытке неудачной авторизации, когда
	/// указан неправильный логин или пароль
	/// при вызове метода VkApi.Authorize
	/// </summary>
	[Serializable]
	public class VkApiAuthorizationException : VkApiException
	{
		/// <summary>
		/// Инициализирует новый экземпляр класса VkApiAuthorizationException
		/// </summary>
		/// <param name="message"> Описание исключения. </param>
		/// <param name="email"> Логин, который был указан при попытке авторизации. </param>
		/// <param name="password"> Пароль, который был указан при попытке авторизации. </param>
		public VkApiAuthorizationException(string message, string email, string password) : base(message: message)
		{
			Email = email;
			Password = password;
		}

		/// <summary>
		/// Логин, который был указан при попытке авторизации.
		/// </summary>
		public string Email { get; }

		/// <summary>
		/// Пароль, который был указан при попытке авторизации.
		/// </summary>
		public string Password { get; }
	}
}