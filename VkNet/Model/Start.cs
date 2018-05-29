using System;
using Newtonsoft.Json;

namespace VkNet.Model
{
	/// <summary>
	/// При успешном старте рекламной акции
	/// </summary>
	[Serializable]
	public class Start
	{
		/// <summary>
		/// Сессия рекламной акции.
		/// </summary>
		[JsonProperty(propertyName: "vk_sid")]
		public string VkSid { get; set; }

		/// <summary>
		/// Режим транзакции (1 — тестовый, 0 — реальный);
		/// </summary>
		[JsonProperty(propertyName: "test_mode")]
		public int? TestMode { get; set; }
	}
}