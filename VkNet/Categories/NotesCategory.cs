using System.Collections.Generic;
using VkNet.Abstractions;
using VkNet.Model;
using VkNet.Model.Attachments;
using VkNet.Model.RequestParams.Notes;
using VkNet.Utils;

namespace VkNet.Categories
{
	/// <inheritdoc />
	public partial class NotesCategory : INotesCategory
	{
		/// <summary>
		/// API.
		/// </summary>
		private readonly IVkApiInvoke _vk;

		/// <summary>
		/// api vk.com
		/// </summary>
		/// <param name="vk">
		/// Api vk.com
		/// </param>
		public NotesCategory(VkApi vk)
		{
			_vk = vk;
		}

		/// <inheritdoc />
		public long Add(NotesAddParams notesAddParams)
		{
			return _vk.Call(methodName: "notes.add",
				parameters: new VkParameters
				{
					{"title", notesAddParams.Title },
					{"text", notesAddParams.Text },
					{"privacy_view", notesAddParams.PrivacyView },
					{"privacy_comment", notesAddParams.PrivacyComment }
				});
		}

		/// <inheritdoc />
		public long CreateComment(NotesCreateCommentParams createCommentParams)
		{
			return _vk.Call(methodName: "notes.createComment ",
				parameters: new VkParameters
				{
					{"note_id", createCommentParams.NoteId },
					{"owner_id", createCommentParams.OwnerId },
					{"reply_to", createCommentParams.ReplyTo },
					{"message", createCommentParams.Message },
				});
		}

		/// <inheritdoc />
		public bool Delete(long noteId)
		{
			return _vk.Call(methodName: "notes.delete",
				parameters: new VkParameters
				{
					{"note_id",  noteId}
				});
		}

		/// <inheritdoc />
		public bool DeleteComment(NotesDeleteCommentParams deleteCommentParams)
		{
			return _vk.Call(methodName: "notes.deleteComment",
				parameters: new VkParameters
				{
					{"comment_id",  deleteCommentParams.CommentId},
					{"owner_id",  deleteCommentParams.OwnerId}
				});
		}

		/// <inheritdoc />
		public bool Edit(NotesEditParams editParams)
		{
			return _vk.Call(methodName: "notes.edit",
				parameters: new VkParameters
				{
					{"note_id",  editParams.NoteId},
					{"title",  editParams.Title},
					{"text",  editParams.Text},
					{"privacy_view",  editParams.PrivacyView},
					{"privacy_comment",  editParams.PrivacyComment}
				});
		}

		/// <inheritdoc />
		public bool EditComment(NotesEditCommentParams editCommentParams)
		{
			return _vk.Call(methodName: "notes.editComment",
				parameters: new VkParameters
				{
					{"comment_id",  editCommentParams.CommentId},
					{"owner_id",  editCommentParams.OwnerId},
					{"message",  editCommentParams.Message}
				});
		}

		/// <inheritdoc />
		public IEnumerable<Note> Get(NotesGetParams notesGetParams)
		{
			return _vk.Call(methodName: "notes.get",
				parameters: new VkParameters
				{
					{"note_ids",  notesGetParams.NoteIds},
					{"user_id",  notesGetParams.UserId},
					{"offset",  notesGetParams.Offset},
					{"count",  notesGetParams.Count},
					{"sort",  notesGetParams.Sort}
				}).ToReadOnlyCollectionOf<Note>(selector: x => x);
		}

		/// <inheritdoc />
		public Note GetById(NotesGetByIdParams getByIdParams)
		{
			return _vk.Call(methodName: "notes.getById",
				parameters: new VkParameters
				{
					{"note_id", getByIdParams.NoteId},
					{"owner_id", getByIdParams.OwnerId},
					{"need_wiki", getByIdParams.IsNeedWiki}
				});
		}

		/// <inheritdoc />
		public IEnumerable<CommentNote> GetComments(NotesGetCommentParams getCommentParams)
		{
			return _vk.Call(methodName: "notes.getComments",
				parameters: new VkParameters
				{
					{"note_id", getCommentParams.NoteId},
					{"owner_id", getCommentParams.OwnerId},
					{"sort", getCommentParams.Sort},
					{"offset", getCommentParams.Offset},
					{"count", getCommentParams.Count},
				}).ToReadOnlyCollectionOf<CommentNote>(selector: x => x);
		}

		/// <inheritdoc />
		public bool RestoreComment(NotesRestoreCommentParams restoreCommentParams)
		{
			return _vk.Call(methodName: "notes.restoreComment",
				parameters: new VkParameters
				{
					{"comment_id", restoreCommentParams.CommentId},
					{"owner_id", restoreCommentParams.OwnerId},
				});
		}

	}
}
