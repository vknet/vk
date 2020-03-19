using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace VkNet.Model.RequestParams
{
	/// <summary>
	/// Список параметров для метода Messages.GetImportantMessages
	/// </summary>
	[Serializable]
	public class GetImportantMessagesParams
	{
		/// <summary>
		/// Список дополнительных полей для пользователей и сообществ. список слов, разделенных через запятую
		/// </summary>
		[JsonProperty("fields")]
		public IEnumerable<string> Fields { get; set; }

		/// <summary>
		/// Максимальное число результатов, которые нужно получить. положительное число, по умолчанию 20, максимальное значение 200
		/// </summary>
		[JsonProperty("count")]
		public ulong Count { get; set; }

		/// <summary>
		/// Смещение, необходимое для выборки определенного подмножества результатов. положительное число
		/// </summary>
		[JsonProperty("offset")]
		public ulong Offset { get; set; }

		/// <summary>
		/// Идентификатор сообщения, начиная с которого нужно возвращать список. положительное число
		/// </summary>
		[JsonProperty("start_message_id")]
		public ulong StartMessageId { get; set; }

		/// <summary>
		/// Положительное число
		/// </summary>
		[JsonProperty("preview_length")]
		public ulong PreviewLength { get; set; }

		/// <summary>
		/// 1 — возвращать дополнительные поля для пользователей и сообществ. флаг, может принимать значения 1 или 0
		/// </summary>
		[JsonProperty("extended")]
		public bool Extended { get; set; }

		/// <summary>
		/// Идентификатор сообщества (для сообщений сообщества с ключом доступа пользователя). положительное число
		/// </summary>
		[JsonProperty("group_id")]
		public ulong GroupId { get; set; }
	}
}