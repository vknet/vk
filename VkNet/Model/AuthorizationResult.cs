using System;

namespace VkNet.Model
{
	/// <summary>
	/// Результат авторизаци
	/// </summary>
	[Serializable]
	public class AuthorizationResult
	{
		/// <summary>
		/// Access Token
		/// </summary>
		public string AccessToken { get; set; }

		/// <summary>
		/// Время истечения токена
		/// </summary>
		public int ExpiresIn { get; set; }

		/// <summary>
		/// Идентификатор пользователя
		/// </summary>
		public long UserId { get; set; }

		/// <summary>
		/// Произвольная строка, которая будет возвращена вместе с результатом авторизации.
		/// </summary>
		public string State { get; set; }
	}
}