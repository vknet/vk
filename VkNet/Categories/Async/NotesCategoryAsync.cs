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
			return TypeHelper.TryInvokeMethodAsync(func: () =>Add(notesAddParams: notesAddParams));
		}

		/// <inheritdoc />
		public Task<long> CreateCommentAsync(NotesCreateCommentParams createCommentParams)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>CreateComment(createCommentParams: createCommentParams));
		}

		/// <inheritdoc />
		public Task<bool> DeleteCommentAsync(NotesDeleteCommentParams deleteCommentParams)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>DeleteComment(deleteCommentParams: deleteCommentParams));
		}

		/// <inheritdoc />
		public Task<bool> DeleteAsync(long noteId)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>Delete(noteId: noteId));
		}

		/// <inheritdoc />
		public Task<bool> EditCommentAsync(NotesEditCommentParams editCommentParams)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>EditComment(editCommentParams: editCommentParams));
		}

		/// <inheritdoc />
		public Task<bool> EditAsync(NotesEditParams editParams)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>Edit(editParams: editParams));
		}

		/// <inheritdoc />
		public Task<IEnumerable<CommentNote>> GetCommentsAsync(NotesGetCommentParams getCommentParams)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>GetComments(getCommentParams: getCommentParams));
		}

		/// <inheritdoc />
		public Task<Note> GetByIdAsync(NotesGetByIdParams getByIdParams)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>GetById(getByIdParams: getByIdParams));
		}

		/// <inheritdoc />
		public Task<IEnumerable<Note>> GetAsync(NotesGetParams notesGetParams)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>Get(notesGetParams: notesGetParams));
		}

		/// <inheritdoc />
		public Task<bool> RestoreCommentAsync(NotesRestoreCommentParams restoreCommentParams)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>RestoreComment(restoreCommentParams: restoreCommentParams));
		}
	}
}
