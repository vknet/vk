using System;
using Newtonsoft.Json;

namespace VkNet.Model.RequestParams.Notes
{
	/// <summary>
	/// Notes Delete Comment Params
	/// </summary>
	[Serializable]
	public class NotesDeleteCommentParams
	{
		/// <summary>
		/// Идентификатор комментария. 
		/// </summary>
		[JsonProperty("comment_id")]
		public long? CommentId { get; set; }

		/// <summary>
		/// Идентификатор владельца заметки.  
		/// </summary>
		[JsonProperty("owner_id")]
		public long? OwnerId { get; set; }
	}
}
