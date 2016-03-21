using System;

namespace VkNet.Model
{
	using Utils;

	/// <summary>
	/// Настройки уведомлений для беседы
	/// </summary>
	[Serializable]
	public class ChatPushSettings
	{
		/// <summary>
		/// Состояние звукового оповещения
		/// </summary>
		public bool Sound { get; set; }

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
			var settings = new ChatPushSettings
			{
				Sound = response.ContainsKey("sound") && response["sound"],
				DisabledUntil = response.ContainsKey("disabled_until") ? response["disabled_until"] : null
			};
			return settings;
		}
	}
}
