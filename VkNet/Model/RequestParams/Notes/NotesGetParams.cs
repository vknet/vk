using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using VkNet.Enums;

namespace VkNet.Model.RequestParams.Notes
{
	/// <summary>
	/// Notes Get Params
	/// </summary>
	[Serializable]
	public class NotesGetParams
	{
		/// <summary>
		/// Идентификаторы заметок, информацию о которых необходимо получить. 
		/// список положительных чисел, разделенных запятыми
		/// </summary>
		[JsonProperty("note_ids")]
		public IEnumerable<long> NoteIds { get; set; }

		/// <summary>
		/// Идентификатор пользователя, информацию о заметках которого требуется получить.
		/// по умолчанию идентификатор текущего пользователя
		/// </summary>
		[JsonProperty("user_id")]
		public long? UserId { get; set; }

		/// <summary>
		/// Cмещение, необходимое для выборки определенного подмножества заметок,
		/// по умолчанию 0
		/// </summary>
		[JsonProperty("offset")]
		public int? Offset { get; set; }

		/// <summary>
		/// количество заметок, информацию о которых необходимо получить. 
		/// положительное число, по умолчанию 20, максимальное значение 100
		/// </summary>
		[JsonProperty("count")]
		public int? Count { get; set; }

		/// <summary>
		/// сортировка результатов (0 — по дате создания в порядке убывания,
		///1 - по дате создания в порядке возрастания). 
		/// </summary>
		[JsonProperty("sort")]
		public SortOrderBy Sort { get; set; }
	}
}
