using System;
using System.Runtime.Serialization;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Настройки уведомлений для сообщений
	/// </summary>
	[Serializable]
	public class MessagesPushSettings
	{
		/// <summary>
		/// Отключить звук.
		/// </summary>
		public object no_sound { get; set; }

		/// <summary>
		/// Не передавать текст сообщения.
		/// </summary>
		public object no_text { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response">Ответ сервера.</param>
		/// <returns></returns>
		public static MessagesPushSettings FromJson(VkResponse response)
		{
			var result = new MessagesPushSettings
			{
				no_sound = response["no_sound"],
				no_text = response["no_text"]
			};

			return result;
		}
	}
}