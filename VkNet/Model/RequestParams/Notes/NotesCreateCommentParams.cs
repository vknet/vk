using System;
using Newtonsoft.Json;

namespace VkNet.Model.RequestParams.Notes
{
	/// <summary>
	/// Notes Create Comment Params
	/// </summary>
	[Serializable]
	public class NotesCreateCommentParams
	{
		/// <summary>
		/// Идентификатор заметки. 
		/// </summary>
		[JsonProperty("note_id")]
		public long? NoteId { get; set; }

		/// <summary>
		/// Идентификатор владельца заметки.
		/// </summary>
		[JsonProperty("owner_id")]
		public long? OwnerId { get; set; }

		/// <summary>
		/// Идентификатор пользователя, ответом на комментарий которого является
		///добавляемый комментарий (не передаётся, если
		///комментарий не является ответом). 
		/// </summary>
		[JsonProperty("reply_to")]
		public long? ReplyTo { get; set; }

		/// <summary>
		/// Текст комментария. 
		/// </summary>
		[JsonProperty("message")]
		public string Message { get; set; }

	}
}
