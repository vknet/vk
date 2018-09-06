using System;
using Newtonsoft.Json;


namespace VkNet.Model.RequestParams.Notes
{
	/// <summary>
	/// Notes Edit Comment Params
	/// </summary>
	[Serializable]
	public class NotesEditCommentParams
	{
		/// <summary>
		/// Идентификатор комментария. 
		///положительное число, (обязательный параметр)
		/// </summary>
		[JsonProperty("comment_id")]
		public long? CommentId { get; set; }

		/// <summary>
		///Идентификатор владельца заметки.
		///положительное число, по умолчанию идентификатор текущего пользователя
		/// </summary>
		[JsonProperty("owner_id")]
		public long? OwnerId { get; set; }

		/// <summary>
		/// Новый текст комментария. 
		/// </summary>
		[JsonProperty("message")]
		public string Message { get; set; }

	}
}
