using System;
using System.Net;

namespace VkNet.Infrastructure.Authorization
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

		/// <summary>
		/// Куки.
		/// </summary>
		public CookieContainer Cookies { get; set; }
	}
}