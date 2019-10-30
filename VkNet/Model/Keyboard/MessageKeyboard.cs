using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using VkNet.Utils;

namespace VkNet.Model.Keyboard
{
	/// <summary>
	/// Объект клавиатуры, отправляемой ботом.
	/// </summary>
	[Serializable]
	[JsonObject(MemberSerialization.OptOut)]
	public class MessageKeyboard
	{
		/// <summary>
		/// Скрыть клавиатуру сразу же после нажатия на кнопку.
		/// </summary>
		[JsonProperty(propertyName: "one_time")]
		public bool OneTime { get; set; }

		/// <summary>
		/// Должна ли клавиатура отображаться внутри сообщения.
		/// </summary>
		[JsonProperty(propertyName: "inline")]
		public bool Inline { get; set; }

		/// <summary>
		/// Массив кнопок отправляемых ботом, размером до 4х10
		/// </summary>
		[JsonProperty(propertyName: "buttons")]
		public IEnumerable<IEnumerable<MessageKeyboardButton>> Buttons { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static MessageKeyboard FromJson(VkResponse response)
		{
			return new MessageKeyboard
			{
				OneTime = response[key: "one_time"],
				Inline = response[key: "inline"],
				Buttons = response[key: "buttons"]
					.ToReadOnlyCollectionOf(x => x.ToReadOnlyCollectionOf<MessageKeyboardButton>(y => y))
			};
		}

		/// <summary>
		/// Преобразовать из VkResponse
		/// </summary>
		/// <param name="response"> Ответ. </param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator MessageKeyboard(VkResponse response)
		{
			if (response == null)
			{
				return null;
			}

			return response.HasToken() ? FromJson(response) : null;
		}
	}
}