namespace VkNet.Infrastructure.Authorization.ImplicitFlow
{
	/// <summary>
	/// Тип страницы для авторизации Implicit Flow
	/// </summary>
	public enum ImplicitFlowPageType
	{
		/// <summary>
		/// Страница с логином и паролем
		/// </summary>
		LoginPassword,

		/// <summary>
		/// Страница с капчей
		/// </summary>
		Captcha,

		/// <summary>
		/// Страница ввода кода двухфакторной авторизации
		/// </summary>
		TwoFactor,

		/// <summary>
		/// Страница подтверждения доступа к скоупу
		/// </summary>
		Consent,

		/// <summary>
		/// Резудьтирующая страница
		/// </summary>
		Result,

		/// <summary>
		/// Страница с ошибкой при отвержении доступа к скоупу
		/// </summary>
		Error
	}
}