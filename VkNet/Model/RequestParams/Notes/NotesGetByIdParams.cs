using System;
using Newtonsoft.Json;

namespace VkNet.Model.RequestParams.Notes
{
	/// <summary>
	/// Notes Get By Id Params
	/// </summary>
	[Serializable]
	public class NotesGetByIdParams
	{
		/// <summary>
		/// идентификатор заметки (обязательный параметр).
		/// </summary>
		[JsonProperty("note_id")]
		public long? NoteId { get; set; }

		/// <summary>
		/// идентификатор владельца заметки (по умолчанию идентификатор текущего пользователя).
		/// </summary>
		[JsonProperty("owner_id")]
		public long? OwnerId { get; set; }

		/// <summary>
		/// определяет, требуется ли в ответе wiki-представление заметки
		///(работает, только если запрашиваются заметки текущего пользователя). 
		/// </summary>
		[JsonProperty("need_wiki")]
		public bool? IsNeedWiki { get; set; }
	}
}
