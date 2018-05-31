using System;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Результат метода auth.confirm
	/// </summary>
	[Serializable]
	public class AuthConfirmResult
	{
		/// <summary>
		/// Успешно.
		/// </summary>
		public bool Success { get; set; }

		/// <summary>
		/// Идентификатор пользователя.
		/// </summary>
		public long UserId { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static AuthConfirmResult FromJson(VkResponse response)
		{
			return new AuthConfirmResult
			{
					Success = response[key: "success"]
					, UserId = response[key: "uid"]
			};
		}
	}
}