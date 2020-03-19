using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Newtonsoft.Json;
using VkNet.Utils.JsonConverter;

namespace VkNet.Model.RequestParams
{
	/// <summary>
	/// Параметры запроса messages.search
	/// </summary>
	[Serializable]
	public class MessagesSearchParams
	{
		/// <summary>
		/// Подстрока, по которой будет производиться поиск.
		/// </summary>
		[JsonProperty("q")]
		public string Query { get; set; }

		/// <summary>
		/// Список дополнительных полей для пользователей и сообществ. список слов, разделенных через запятую
		/// </summary>
		[JsonProperty("fields")]
		[CanBeNull]
		public IEnumerable<string> Fields { get; set; }

		/// <summary>
		/// Фильтр по идентификатору назначения для поиска по отдельному диалогу
		/// </summary>
		[JsonProperty("peer_id")]
		public long? PeerId { get; set; }

		/// <summary>
		/// Дата в формате DDMMYYYY — если параметр задан, в ответе будут только сообщения,
		/// отправленные до указанной даты.
		/// </summary>
		[JsonProperty("date")]
		[JsonConverter(typeof(DateTimeToStringFormatConverter), "ddMMyyyy")]
		public DateTime? Date { get; set; }

		/// <summary>
		/// Количество символов, по которому нужно обрезать сообщение.
		/// Укажите 0, если Вы не хотите обрезать сообщение. (по умолчанию сообщения не
		/// обрезаются).
		/// </summary>
		[JsonProperty("preview_length")]
		public uint? PreviewLength { get; set; }

		/// <summary>
		/// Смещение, необходимое для выборки определенного подмножества сообщений из
		/// списка найденных.
		/// </summary>
		[JsonProperty("offset")]
		public uint? Offset { get; set; }

		/// <summary>
		/// Количество сообщений, которое необходимо получить.
		/// </summary>
		/// <remarks>
		/// По умолчанию 20.
		/// </remarks>
		[JsonProperty("count")]
		public uint? Count { get; set; }

		/// <summary>
		/// 1 — возвращать дополнительные поля для пользователей и сообществ. В ответе будет содержаться массив объектов бесед. флаг, может принимать значения 1 или 0
		/// </summary>
		[JsonProperty("extended")]
		public bool? Extended { get; set; }

		/// <summary>
		/// Идентификатор сообщества (для сообщений сообщества с ключом доступа пользователя). положительное число
		/// </summary>
		[JsonProperty("group_id")]
		public ulong? GroupId { get; set; }
	}
}