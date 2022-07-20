using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using VkNet.Enums;
using VkNet.Enums.SafetyEnums;
using VkNet.Model.GroupUpdate;
using VkNet.Utils;
using VkNet.Utils.JsonConverter;

namespace VkNet.Model
{
	/// <summary>
	/// Информация о доступных пользователю функциях.
	/// </summary>
	[Serializable]
	public class ClientInfo
	{
		/// <summary>
		/// Массив кнопок, которые поддерживает клиент.
		/// </summary>
		[JsonProperty("button_actions", ItemConverterType = typeof(SafetyEnumJsonConverter))]
		public IEnumerable<KeyboardButtonActionType> ButtonActions { get; set; }

		/// <summary>
		/// Поддерживается ли клавиатура ботов клиентом.
		/// </summary>
		[JsonProperty("keyboard")]
		public bool Keyboard { get; set; }

		/// <summary>
		/// Поддерживается ли inline-клавиатура ботов клиентом.
		/// </summary>
		[JsonProperty("inline_keyboard")]
		public bool InlineKeyboard { get; set; }

		/// <summary>
		/// Id используемого языка.
		/// </summary>
		[JsonProperty("lang_id")]
		public Language LangId { get; set; }

	#region Методы

		/// <summary>
		/// </summary>
		/// <param name="response"> </param>
		/// <returns> </returns>
		public static ClientInfo FromJson(VkResponse response)
		{
			return new ClientInfo
			{
				ButtonActions = response["button_actions"].ToReadOnlyCollectionOf<KeyboardButtonActionType>(x => x),
				Keyboard = response["keyboard"],
				InlineKeyboard = response["inline_keyboard"],
				LangId = response["lang_id"].ToEnum<Language>()
			};
		}

		/// <summary>
		/// Преобразование класса <see cref="ClientInfo" /> в <see cref="VkParameters" />
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns>Результат преобразования в <see cref="MessageNew" /></returns>
		public static implicit operator ClientInfo(VkResponse response)
		{
			if (response == null)
			{
				return null;
			}

			return response.HasToken()
				? FromJson(response)
				: null;
		}

	#endregion
	}
}