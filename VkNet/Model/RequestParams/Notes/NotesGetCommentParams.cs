using System;
using Newtonsoft.Json;
using VkNet.Enums;

namespace VkNet.Model.RequestParams.Notes
{
	/// <summary>
	/// Notes Get Comments Params
	/// </summary>
	[Serializable]
	public class NotesGetCommentParams
	{
		/// <summary>
		/// идентификатор заметки (обязательный параметр). 
		/// </summary>
		[JsonProperty("note_id")]
		public long? NoteId { get; set; }

		/// <summary>
		/// идентификатор владельца заметки. 
		/// по умолчанию идентификатор текущего пользователя
		/// </summary>
		[JsonProperty("owner_id")]
		public long? OwnerId { get; set; }

		/// <summary>
		/// сортировка результатов (0 — по дате создания в порядке убывания,
		///1 - по дате создания в порядке возрастания). 
		/// </summary>
		[JsonProperty("sort")]
		public SortOrderBy Sort { get; set; }

		/// <summary>
		/// Cмещение, необходимое для выборки определенного подмножества комментариев,
		/// по умолчанию 0
		/// </summary>
		[JsonProperty("offset")]
		public int? Offset { get; set; }

		/// <summary>
		/// количество комментариев, которое необходимо получить. 
		/// положительное число, по умолчанию 20, максимальное значение 100
		/// </summary>
		[JsonProperty("count")]
		public int? Count { get; set; }
	}
}
