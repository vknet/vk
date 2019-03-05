using Flurl;
using VkNet.Utils;

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
		/// Куки.
		/// </summary>
		public Cookies Cookies { get; set; }
	}
}