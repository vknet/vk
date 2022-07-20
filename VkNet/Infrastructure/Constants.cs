namespace VkNet.Infrastructure
{
	/// <summary>
	/// Константы проекта
	/// </summary>
	public static class Constants
	{
		/// <summary>
		/// Параметр запроса. Язык
		/// </summary>
		public const string Language = "lang";

		/// <summary>
		/// Токен
		/// </summary>
		public const string AccessToken = "access_token";

		/// <summary>
		/// redirect_uri по умолчанию.
		/// </summary>
		public const string DefaultRedirectUri = "https://oauth.vk.com/blank.html";

		/// <summary>
		/// Параметр запроса. Версия API
		/// </summary>
		public const string Version = "v";

		/// <summary>
		/// Параметр запроса. Идентификатор капчи
		/// </summary>
		public const string CaptchaSid = "captcha_sid";
		/// <summary>
		/// Параметр запроса. Ключ капчи
		/// </summary>
		public const string CaptchaKey = "captcha_key";
	}
}