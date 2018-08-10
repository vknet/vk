using System;
using Newtonsoft.Json;
using VkNet.Enums.SafetyEnums;
using VkNet.Utils;
using VkNet.Utils.JsonConverter;

namespace VkNet.Model.Keyboard
{
	/// <summary>
	/// Кнопка клавиатуры, отправляемая ботом.
	/// </summary>
	[Serializable]
	[JsonObject(MemberSerialization.OptOut)]
	public class MessageKeyboardButton
	{
		/// <summary>
		/// Информация содержащаяся в кнопке
		/// </summary>
		[JsonProperty(propertyName: "action")]
		public MessageKeyboardButtonAction Action { get; set; }

		/// <summary>
		/// Цвет кнопки
		/// </summary>
		[JsonProperty(propertyName: "color")]
		[JsonConverter(typeof(SafetyEnumJsonConverter))]
		public KeyboardButtonColor Color { get; set; } = KeyboardButtonColor.Default;

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static MessageKeyboardButton FromJson(VkResponse response)
		{
			return new MessageKeyboardButton
			{
				Action = response[key: "action"],
				Color = response[key: "color"]
			};
		}

		/// <summary>
		/// Преобразовать из VkResponse
		/// </summary>
		/// <param name="response"> Ответ. </param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator MessageKeyboardButton(VkResponse response)
		{
			return response.HasToken() ? FromJson(response) : null;
		}
	}
}