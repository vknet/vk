using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// </summary>
	[Serializable]
	public class AccountPushSettings
	{
		/// <summary>
		/// Отключены ли уведомления.
		/// </summary>
		public bool Disabled { get; set; }

		/// <summary>
		/// Unixtime-значение времени, до которого временно отключены уведомления.
		/// </summary>
		[JsonConverter(converterType: typeof(UnixDateTimeConverter))]
		public DateTime? DisabledUntil { get; set; }

		/// <summary>
		/// Список, содержащий настройки конкретных диалогов, и их количество первым
		/// элементом.
		/// </summary>
		public IEnumerable<ChatPushSettings> Conversations { get; set; }

		/// <summary>
		/// Объект с настройками Push-уведомлений в специальном формате.
		/// </summary>
		public PushSettings Settings { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static AccountPushSettings FromJson(VkResponse response)
		{
			return new AccountPushSettings
			{
					Disabled = response[key: "disabled"]
					, DisabledUntil = response[key: "disabled_until"]
					, Conversations = response[key: "conversations"].ToReadOnlyCollectionOf<ChatPushSettings>(selector: o => o)
					, Settings = response[key: "settings"]
			};
		}
	}
}