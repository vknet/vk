using System;
using Newtonsoft.Json;
using VkNet.Enums.SafetyEnums;
using VkNet.Utils;
using VkNet.Utils.JsonConverter;

namespace VkNet.Model
{
	/// <summary>
	/// действие, которое должно произойти после нажатия на кнопку
	/// </summary>
	[Serializable]
	public class EventData
	{
		/// <summary>
		/// Тип действия, которые должно произойти после нажатия на кнопку
		/// </summary>
		[JsonProperty("type")]
		[JsonConverter(typeof(SafetyEnumJsonConverter))]
		public MessageEventType Type { get; set; }

		/// <summary>
		/// текст, который нужно вывести (максимум 90 символов).
		/// </summary>
		[JsonProperty("text", NullValueHandling = NullValueHandling.Ignore)]
		public string Text { get; set; }

		/// <summary>
		/// Ссылка, которую необходимо открыть по нажатию на кнопку.
		/// </summary>
		[JsonProperty("link", NullValueHandling = NullValueHandling.Ignore)]
		public Uri Link { get; set; }

		/// <summary>
		/// хэш для навигации в приложении, будет передан в строке параметров запуска после символа #
		/// </summary>
		[JsonProperty("hash", NullValueHandling = NullValueHandling.Ignore)]
		public string Hash { get; set; }

		/// <summary>
		/// Идентификатор вызываемого приложения с типом <see cref="MessageEventType.OpenApp"/>.
		/// </summary>
		[JsonProperty("app_id", NullValueHandling = NullValueHandling.Ignore)]
		public ulong? AppId { get; set; }

		/// <summary>
		/// Идентификатор сообщества, в котором установлено приложение, если требуется открыть в контексте сообщества.
		/// </summary>
		/// <remarks>
		/// Для <see cref="Type"/> со значением <see cref="MessageEventType.OpenApp"/>.
		/// </remarks>
		[JsonProperty("owner_id", NullValueHandling = NullValueHandling.Ignore)]
		public long? OwnerId { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static EventData FromJson(VkResponse response)
		{
			return new EventData
			{
				Type = response["type"],
				Link = response["link"],
				AppId = response["app_id"],
				OwnerId = response["owner_id"],
				Hash = response["hash"]
			};
		}
	}
}