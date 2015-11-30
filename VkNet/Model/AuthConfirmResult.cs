using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Результат метода auth.confirm
	/// </summary>
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
		/// <param name="response">Ответ сервера.</param>
		/// <returns></returns>
		internal static AuthConfirmResult FromJson(VkResponse response)
		{
			return new AuthConfirmResult
			{
				Success = response["success"],
				UserId = response["uid"]
			};
		}

	}
}