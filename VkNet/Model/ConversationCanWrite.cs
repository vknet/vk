using System;
using Newtonsoft.Json;
using VkNet.Enums;

namespace VkNet.Model
{
	/// <summary>
	/// Информация о том, может ли пользователь писать в диалог.
	/// </summary>
	[Serializable]
	public class ConversationCanWrite
	{
		/// <summary>
		/// true, если пользователь может писать в диалог;
		/// </summary>
		[JsonProperty("allowed")]
		public bool Allowed { get; set; }

		/// <summary>
		/// Код ошибки для allowed = false.
		/// </summary>
		[JsonProperty("reason")]
		public CanWriteReason Reason { get; set; }
	}
}