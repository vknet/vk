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
		/// Идентификатор приложения для авторизации
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
		/// Права доступа приложения
		/// </summary>
		public Settings Settings { get; set; }
		/// <summary>
		/// Делегат получения кода для двухфакторной авторизации
		/// </summary>
		public Func<string> TwoFactorAuthorization { get; set; }
		/// <summary>
		/// Идентификатор капчи (если необходимо)
		/// </summary>
		public long? CaptchaSid { get; set; }
		/// <summary>
		/// Текст капчи (если необходимо)
		/// </summary>
		public string CaptchaKey { get; set; }

	}
}