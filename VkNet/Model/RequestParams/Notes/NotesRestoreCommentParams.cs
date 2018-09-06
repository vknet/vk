using System;
using Newtonsoft.Json;

namespace VkNet.Model.RequestParams.Notes
{
	/// <summary>
	/// Notes Restore Comment Params
	/// </summary>
	[Serializable]
	public class NotesRestoreCommentParams
	{
		/// <summary>
		/// идентификатор удаленного комментария
		/// </summary>
		[JsonProperty("comment_id")]
		public long? CommentId { get; set; }

		/// <summary>
		/// идентификатор владельца заметки. 
		/// </summary>
		[JsonProperty("comment_id")]
		public long? OwnerId { get; set; }
	}
}
