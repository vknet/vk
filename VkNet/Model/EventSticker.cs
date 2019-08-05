using System;
using Newtonsoft.Json;

namespace VkNet.Model
{
	/// <summary>
	/// Событие стикера
	/// </summary>
	[Serializable]
	public class EventSticker
	{
		/// <summary>
		/// Идентификатор пользователя
		/// </summary>
		[JsonProperty("user_id")]
		public ulong UserId { get; set; }

		/// <summary>
		/// Статус
		/// </summary>
		[JsonProperty("status")]
		public string Status { get; set; }
	}
}