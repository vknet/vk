using System.Threading;
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
	public Task<long> AddAsync(NotesAddParams notesAddParams,
								CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Add(notesAddParams), token);

	/// <inheritdoc />
	public Task<long> CreateCommentAsync(NotesCreateCommentParams createCommentParams,
										CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			CreateComment(createCommentParams), token);

	/// <inheritdoc />
	public Task<bool> DeleteCommentAsync(NotesDeleteCommentParams deleteCommentParams,
										CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			DeleteComment(deleteCommentParams), token);

	/// <inheritdoc />
	public Task<bool> DeleteAsync(long noteId,
								CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Delete(noteId), token);

	/// <inheritdoc />
	public Task<bool> EditCommentAsync(NotesEditCommentParams editCommentParams,
										CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			EditComment(editCommentParams), token);

	/// <inheritdoc />
	public Task<bool> EditAsync(NotesEditParams editParams,
								CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Edit(editParams), token);

	/// <inheritdoc />
	public Task<VkCollection<CommentNote>> GetCommentsAsync(NotesGetCommentParams getCommentParams,
															CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetComments(getCommentParams), token);

	/// <inheritdoc />
	public Task<Note> GetByIdAsync(NotesGetByIdParams getByIdParams,
									CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetById( getByIdParams), token);

	/// <inheritdoc />
	public Task<VkCollection<Note>> GetAsync(NotesGetParams notesGetParams,
											CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Get(notesGetParams), token);

	/// <inheritdoc />
	public Task<bool> RestoreCommentAsync(NotesRestoreCommentParams restoreCommentParams,
										CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			RestoreComment(restoreCommentParams));
}