using System.Net.Http;
using Flurl;

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
		public Url RequestUrl { get; set; }

		/// <summary>
		/// URL ответа
		/// </summary>
		public Url ResponseUrl { get; set; }

		/// <summary>
		/// Содержимое ответа
		/// </summary>
		public HttpContent Content { get; set; }
	}
}