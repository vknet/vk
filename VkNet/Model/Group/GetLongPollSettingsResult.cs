using System;
using Newtonsoft.Json;

namespace VkNet.Model
{
	/// <summary>
	///
	/// </summary>
	[Serializable]
	public class GetLongPollSettingsResult
	{
		/// <summary>
		/// 1 — включить Bots Long Poll, 0 — отключить. флаг, может принимать значения 1 или 0
		/// </summary>
		[JsonProperty("is_enabled")]
		public bool? IsEnabled { get; set; }

		/// <summary>
		/// Настройки Bots Longpoll.
		/// </summary>
		[JsonProperty("events")]
		public BotsLongPollEvents Events { get; set; }

		/// <summary>
		/// Версия API строка
		/// </summary>
		[JsonProperty("api_version")]
		public string ApiVersion { get; set; }
	}
}