using System;
using Newtonsoft.Json;

namespace VkNet.Model
{
	[Serializable]
	public class Start
	{
		/// <summary>
		/// Сессия рекламной акции.
		/// </summary>
		[JsonProperty("vk_sid")]
		public string VkSid { get; set; }

		/// <summary>
		/// Режим транзакции (1 — тестовый, 0 — реальный);
		/// </summary>
		[JsonProperty("test_mode")]
		public int? TestMode { get; set; }
	}
}