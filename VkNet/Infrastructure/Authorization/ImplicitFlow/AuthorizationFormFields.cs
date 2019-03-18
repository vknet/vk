namespace VkNet.Infrastructure.Authorization.ImplicitFlow
{
	/// <summary>
	/// Поля формы авторизации
	/// </summary>
	public static class AuthorizationFormFields
	{
		/// <summary>
		/// E-mail
		/// </summary>
		public const string Email = "email";

		/// <summary>
		/// Password
		/// </summary>
		public const string Password = "pass";

		/// <summary>
		/// Captcha sid
		/// </summary>
		public const string CaptchaSid = "captcha_sid";

		/// <summary>
		/// Captcha key
		/// </summary>
		public const string CaptchaKey = "captcha_key";

		/// <summary>
		/// Captcha key
		/// </summary>
		public const string Code = "code";
	}
}