using VkNet.Abstractions.Async;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Abstractions;

/// <summary>
/// Методы для работы с заметками.
/// </summary>
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
	VkCollection<Note> Get(NotesGetParams notesGetParams);

	/// <inheritdoc cref="INotesCategoryAsync.GetByIdAsync"/>
	Note GetById(NotesGetByIdParams getByIdParams);

	/// <inheritdoc cref="INotesCategoryAsync.GetCommentsAsync"/>
	VkCollection<CommentNote> GetComments(NotesGetCommentParams getCommentParams);

	/// <inheritdoc cref="INotesCategoryAsync.RestoreCommentAsync"/>
	bool RestoreComment(NotesRestoreCommentParams restoreCommentParams);
}