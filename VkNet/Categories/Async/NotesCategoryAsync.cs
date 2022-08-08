using System.Collections.Generic;
using System.Threading.Tasks;
using VkNet.Model;
using VkNet.Model.Attachments;
using VkNet.Model.RequestParams.Notes;
using VkNet.Utils;

namespace VkNet.Categories;

/// <inheritdoc />
public partial class NotesCategory
{
	/// <inheritdoc />
	public Task<long> AddAsync(NotesAddParams notesAddParams) =>
		TypeHelper.TryInvokeMethodAsync(func: () => Add(notesAddParams: notesAddParams));

	/// <inheritdoc />
	public Task<long> CreateCommentAsync(NotesCreateCommentParams createCommentParams) =>
		TypeHelper.TryInvokeMethodAsync(func: () => CreateComment(createCommentParams: createCommentParams));

	/// <inheritdoc />
	public Task<bool> DeleteCommentAsync(NotesDeleteCommentParams deleteCommentParams) =>
		TypeHelper.TryInvokeMethodAsync(func: () => DeleteComment(deleteCommentParams: deleteCommentParams));

	/// <inheritdoc />
	public Task<bool> DeleteAsync(long noteId) => TypeHelper.TryInvokeMethodAsync(func: () => Delete(noteId: noteId));

	/// <inheritdoc />
	public Task<bool> EditCommentAsync(NotesEditCommentParams editCommentParams) =>
		TypeHelper.TryInvokeMethodAsync(func: () => EditComment(editCommentParams: editCommentParams));

	/// <inheritdoc />
	public Task<bool> EditAsync(NotesEditParams editParams) => TypeHelper.TryInvokeMethodAsync(func: () => Edit(editParams: editParams));

	/// <inheritdoc />
	public Task<IEnumerable<CommentNote>> GetCommentsAsync(NotesGetCommentParams getCommentParams) =>
		TypeHelper.TryInvokeMethodAsync(func: () => GetComments(getCommentParams: getCommentParams));

	/// <inheritdoc />
	public Task<Note> GetByIdAsync(NotesGetByIdParams getByIdParams) =>
		TypeHelper.TryInvokeMethodAsync(func: () => GetById(getByIdParams: getByIdParams));

	/// <inheritdoc />
	public Task<IEnumerable<Note>> GetAsync(NotesGetParams notesGetParams) =>
		TypeHelper.TryInvokeMethodAsync(func: () => Get(notesGetParams: notesGetParams));

	/// <inheritdoc />
	public Task<bool> RestoreCommentAsync(NotesRestoreCommentParams restoreCommentParams) =>
		TypeHelper.TryInvokeMethodAsync(func: () => RestoreComment(restoreCommentParams: restoreCommentParams));
}