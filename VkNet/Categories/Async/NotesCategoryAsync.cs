using System.Collections.Generic;
using System.Threading.Tasks;
using VkNet.Model;
using VkNet.Model.Attachments;
using VkNet.Model.RequestParams.Notes;
using VkNet.Utils;

namespace VkNet.Categories
{
	/// <inheritdoc />
	public partial class NotesCategory
	{
		/// <inheritdoc />
		public Task<long> AddAsync(NotesAddParams notesAddParams)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => _vk.Notes.Add(notesAddParams: notesAddParams));
		}

		/// <inheritdoc />
		public Task<long> CreateCommentAsync(NotesCreateCommentParams createCommentParams)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => _vk.Notes.CreateComment(createCommentParams: createCommentParams));
		}

		/// <inheritdoc />
		public Task<bool> DeleteCommentAsync(NotesDeleteCommentParams deleteCommentParams)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => _vk.Notes.DeleteComment(deleteCommentParams: deleteCommentParams));
		}

		/// <inheritdoc />
		public Task<bool> DeleteNoteAsync(long noteId)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => _vk.Notes.DeleteNote(noteId: noteId));
		}

		/// <inheritdoc />
		public Task<bool> EditCommentAsync(NotesEditCommentParams editCommentParams)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => _vk.Notes.EditComment(editCommentParams: editCommentParams));
		}

		/// <inheritdoc />
		public Task<bool> EditNoteAsync(NotesEditParams editParams)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => _vk.Notes.EditNote(editParams: editParams));
		}

		/// <inheritdoc />
		public Task<IEnumerable<CommentNote>> GetCommentsAsync(NotesGetCommentParams getCommentParams)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => _vk.Notes.GetComments(getCommentParams: getCommentParams));
		}

		/// <inheritdoc />
		public Task<Note> GetNoteByIdAsync(NotesGetByIdParams getByIdParams)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => _vk.Notes.GetNoteById(getByIdParams: getByIdParams));
		}

		/// <inheritdoc />
		public Task<IEnumerable<Note>> GetNotesAsync(NotesGetParams notesGetParams)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => _vk.Notes.GetNotes(notesGetParams: notesGetParams));
		}

		/// <inheritdoc />
		public Task<bool> RestoreCommentAsync(NotesRestoreCommentParams restoreCommentParams)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => _vk.Notes.RestoreComment(restoreCommentParams: restoreCommentParams));
		}
	}
}
