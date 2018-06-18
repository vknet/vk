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
		public Task<bool> DeleteAsync(long noteId)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => _vk.Notes.Delete(noteId: noteId));
		}

		/// <inheritdoc />
		public Task<bool> EditCommentAsync(NotesEditCommentParams editCommentParams)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => _vk.Notes.EditComment(editCommentParams: editCommentParams));
		}

		/// <inheritdoc />
		public Task<bool> EditAsync(NotesEditParams editParams)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => _vk.Notes.Edit(editParams: editParams));
		}

		/// <inheritdoc />
		public Task<IEnumerable<CommentNote>> GetCommentsAsync(NotesGetCommentParams getCommentParams)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => _vk.Notes.GetComments(getCommentParams: getCommentParams));
		}

		/// <inheritdoc />
		public Task<Note> GetByIdAsync(NotesGetByIdParams getByIdParams)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => _vk.Notes.GetById(getByIdParams: getByIdParams));
		}

		/// <inheritdoc />
		public Task<IEnumerable<Note>> GetAsync(NotesGetParams notesGetParams)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => _vk.Notes.Get(notesGetParams: notesGetParams));
		}

		/// <inheritdoc />
		public Task<bool> RestoreCommentAsync(NotesRestoreCommentParams restoreCommentParams)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => _vk.Notes.RestoreComment(restoreCommentParams: restoreCommentParams));
		}
	}
}
