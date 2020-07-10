using System;

namespace VkNet.Infrastructure.Authorization.ImplicitFlow
{
	/// <summary>
	/// Результат формы авторизации
	/// </summary>
	public class AuthorizationFormResult
	{
		/// <summary>
		/// URL запроса
		/// </summary>
		public Uri RequestUrl { get; set; }

		/// <summary>
		/// URL ответа
		/// </summary>
		public Uri ResponseUrl { get; set; }
	}
}