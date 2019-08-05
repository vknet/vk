using System;
using Newtonsoft.Json;
using VkNet.Enums.SafetyEnums;
using VkNet.Utils.JsonConverter;

namespace VkNet.Model
{
	/// <summary>
	/// Онлайн статус
	/// </summary>
	[Serializable]
	public class OnlineStatus
	{
		/// <summary>
		/// Статус
		/// </summary>
		[JsonProperty("status")]
		[JsonConverter(typeof(SafetyEnumJsonConverter))]
		public OnlineStatusType Status { get; set; }

		/// <summary>
		/// Оценка времени ответа в минутах
		/// </summary>
		[JsonProperty("minutes")]
		public uint? Minutes { get; set; }
	}
}