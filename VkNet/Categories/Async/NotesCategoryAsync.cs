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
								CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Add(notesAddParams));

	/// <inheritdoc />
	public Task<long> CreateCommentAsync(NotesCreateCommentParams createCommentParams,
										CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			CreateComment(createCommentParams));

	/// <inheritdoc />
	public Task<bool> DeleteCommentAsync(NotesDeleteCommentParams deleteCommentParams,
										CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			DeleteComment(deleteCommentParams));

	/// <inheritdoc />
	public Task<bool> DeleteAsync(long noteId,
								CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Delete(noteId));

	/// <inheritdoc />
	public Task<bool> EditCommentAsync(NotesEditCommentParams editCommentParams,
										CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			EditComment(editCommentParams));

	/// <inheritdoc />
	public Task<bool> EditAsync(NotesEditParams editParams,
								CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Edit(editParams));

	/// <inheritdoc />
	public Task<VkCollection<CommentNote>> GetCommentsAsync(NotesGetCommentParams getCommentParams,
															CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetComments(getCommentParams));

	/// <inheritdoc />
	public Task<Note> GetByIdAsync(NotesGetByIdParams getByIdParams,
									CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetById( getByIdParams));

	/// <inheritdoc />
	public Task<VkCollection<Note>> GetAsync(NotesGetParams notesGetParams,
											CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Get(notesGetParams));

	/// <inheritdoc />
	public Task<bool> RestoreCommentAsync(NotesRestoreCommentParams restoreCommentParams,
										CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			RestoreComment(restoreCommentParams));
}