using System;
using System.Runtime.Serialization;

namespace VkNet.Model
{
	using Utils;

	/// <summary>
	/// Настройки уведомлений для беседы
	/// </summary>
	[DataContract]
	public class ChatPushSettings
	{
		/// <summary>
		/// Идентификатор собеседника.
		/// </summary>
		public long? PeerId { get; set; }

		/// <summary>
		/// Состояние звукового оповещения
		/// </summary>
		public bool? Sound { get; set; }

		/// <summary>
		/// Неизвестный параметр
		/// </summary>
		public int? DisabledUntil { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response">Ответ сервера.</param>
		/// <returns></returns>
		internal static ChatPushSettings FromJson(VkResponse response)
		{
			var result = new ChatPushSettings
			{
				PeerId = response["peer_id"],
				Sound = response["sound"],
				DisabledUntil = response["disabled_until"]
			};

			return result;
		}
	}
}
