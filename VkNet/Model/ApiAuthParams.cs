using System;
using VkNet.Enums.Filters;

namespace VkNet
{
	/// <summary>
	/// Параметры авторизации
	/// </summary>
	public struct ApiAuthParams
	{
		/// <summary>
		/// Идентификатор приложения с помощью которого будет авторизован пользователь
		/// </summary>
		public ulong ApplicationId { get; set; }
		/// <summary>
		/// Логин пользователя
		/// </summary>
		public string Login { get; set; }
		/// <summary>
		/// Пароль пользователя
		/// </summary>
		public string Password { get; set; }
		/// <summary>
		/// Права доступа приложений.
		/// См. описание <see href="http://vk.com/pages?oid=-1&amp;p=Права_доступа_приложений"/>.
		/// </summary>
		public Settings Settings { get; set; }
		/// <summary>
		/// Функция двухфакторной авторизации
		/// </summary>
		public Func<string> TwoFactorAuthorization { get; set; }
		/// <summary>
		/// Идентификатор капчи (если установлена)
		/// </summary>
		public long? CaptchaSid { get; set; }
		/// <summary>
		/// Ключ капчи (если необходимо)
		/// </summary>
		public string CaptchaKey { get; set; }

	}
}