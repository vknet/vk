using System;
using Newtonsoft.Json;

namespace VkNet.Model
{
	/// <summary>
	/// При успешном завершении оффера
	/// </summary>
	[Serializable]
	public class LeadsComplete
	{
		/// <summary>
		/// Ограничение, установленное у текущего оффера;
		/// </summary>
		[JsonProperty(propertyName: "limit")]
		public long Limit { get; set; }

		/// <summary>
		/// Ограничение, установленное у текущего оффера;
		/// </summary>
		[JsonProperty(propertyName: "day_limit")]
		public long DayLimit { get; set; }

		/// <summary>
		/// Количество потраченных на акцию голосов;
		/// </summary>
		[JsonProperty(propertyName: "spent")]
		public long Spent { get; set; }

		/// <summary>
		/// Стоимость одной выполненной акции;
		/// </summary>
		[JsonProperty(propertyName: "cost")]
		public string Cost { get; set; }

		/// <summary>
		/// Режим транзакции (1 — тестовый, 0 — реальный);
		/// </summary>
		[JsonProperty(propertyName: "test_mode")]
		public long TestMode { get; set; }

		/// <summary>
		/// Результат выполнения транзакции (всегда равно 1).
		/// </summary>
		[JsonProperty(propertyName: "success")]
		public long Success { get; set; }
	}
}