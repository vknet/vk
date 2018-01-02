using System;
using VkNet.Utils;
namespace VkNet.Model
{
	/// <summary>
	/// Информация о последней активности пользователя.
	/// См. описание http://vk.com/dev/messages.getLastActivity
	/// </summary>
	public class LastActivity
	{
		/// <summary>
		/// Идентификатор пользователя.
		/// </summary>
		public long UserId { get; set; }

		/// <summary>
		/// Текущий статус пользователя (true - в сети, false - не в сети).
		/// </summary>
		public bool? IsOnline { get; set; }

		/// <summary>
		/// Дата последней активности пользователя.
		/// </summary>
		public DateTime? Time { get; set; }

		#region Методы
		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response">Ответ сервера.</param>
		/// <returns></returns>
		public static LastActivity FromJson(VkResponse response)
		{
			var lastActivity = new LastActivity
			{

				IsOnline = response["online"],
				Time = response["time"]
			};

			return lastActivity;
		}

		#endregion
	}
}