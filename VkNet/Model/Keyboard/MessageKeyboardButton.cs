using System;
using JetBrains.Annotations;
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
		[JsonProperty("action")]
		public MessageKeyboardButtonAction Action { get; set; }

		/// <summary>
		/// Цвет кнопки
		/// </summary>
		[JsonProperty("color", NullValueHandling = NullValueHandling.Ignore)]
		[JsonConverter(typeof(SafetyEnumJsonConverter))]
		public KeyboardButtonColor? Color { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static MessageKeyboardButton FromJson([NotNull] VkResponse response)
		{
			return new MessageKeyboardButton
			{
				Action = response["action"],
				Color = response["color"]
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
			if (response == null)
			{
				return null;
			}

			return response.HasToken() ? FromJson(response) : null;
		}
	}
}