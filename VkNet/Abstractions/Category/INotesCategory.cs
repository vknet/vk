using System.Collections.Generic;
using VkNet.Abstractions.Async;
using VkNet.Model;
using VkNet.Model.Attachments;
using VkNet.Model.RequestParams.Notes;

namespace VkNet.Abstractions
{
	/// <inheritdoc cref="INotesCategoryAsync"/>
	public interface INotesCategory : INotesCategoryAsync
	{
		/// <inheritdoc cref="INotesCategoryAsync.AddAsync"/>
		long Add(NotesAddParams notesAddParams);

		/// <inheritdoc cref="INotesCategoryAsync.CreateCommentAsync"/>
		long CreateComment(NotesCreateCommentParams createCommentParams);

		/// <inheritdoc cref="INotesCategoryAsync.DeleteAsync"/>
		bool Delete(long noteId);

		/// <inheritdoc cref="INotesCategoryAsync.DeleteCommentAsync"/>
		bool DeleteComment(NotesDeleteCommentParams deleteCommentParams);

		/// <inheritdoc cref="INotesCategoryAsync.EditAsync"/>
		bool Edit(NotesEditParams editParams);

		/// <inheritdoc cref="INotesCategoryAsync.EditCommentAsync"/>
		bool EditComment(NotesEditCommentParams editCommentParams);

		/// <inheritdoc cref="INotesCategoryAsync.GetAsync"/>
		IEnumerable<Note> Get(NotesGetParams notesGetParams);

		/// <inheritdoc cref="INotesCategoryAsync.GetByIdAsync"/>
		Note GetById(NotesGetByIdParams getByIdParams);

		/// <inheritdoc cref="INotesCategoryAsync.GetCommentsAsync"/>
		IEnumerable<CommentNote> GetComments(NotesGetCommentParams getCommentParams);

		/// <inheritdoc cref="INotesCategoryAsync.RestoreCommentAsync"/>
		bool RestoreComment(NotesRestoreCommentParams restoreCommentParams);
	}
}