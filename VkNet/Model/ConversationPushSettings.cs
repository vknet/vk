using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace VkNet.Model
{
	/// <summary>
	/// Беседа настройки Push-уведомлений.
	/// </summary>
	[Serializable]
	public class ConversationPushSettings
	{
		/// <summary>
		/// timestamp, до которого оповещения отключены;
		/// </summary>
		[JsonProperty("disable_until")]
		[JsonConverter(typeof(UnixDateTimeConverter))]
		public DateTime DisableUntil { get; set; }

		/// <summary>
		/// Передается в случае, если оповещения отключены навсегда, содержит true;
		/// </summary>
		[JsonProperty("disabled_forever")]
		public bool? DisabledForever { get; set; }

		/// <summary>
		/// Передается в случае, если отключен звук оповещений, содержит true.
		/// </summary>
		[JsonProperty("no_sound")]
		public bool? NoSound { get; set; }
	}
}