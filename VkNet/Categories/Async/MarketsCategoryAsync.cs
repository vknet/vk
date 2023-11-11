using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VkNet.Enums;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Categories;

public partial class MarketsCategory
{
	/// <inheritdoc />
	public Task<VkCollection<Market>> GetAsync(MarketGetParams @params,
											CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Get(@params), token);

	/// <inheritdoc />
	public Task<VkCollection<Market>> GetAsync(long ownerId,
												long? albumId = null,
												int? count = null,
												int? offset = null,
												bool extended = false,
												CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Get(ownerId, albumId, count, offset, extended), token);

	/// <inheritdoc />
	public Task<VkCollection<Market>> GetByIdAsync(IEnumerable<string> itemIds,
													bool extended = false,
													CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetById(itemIds, extended), token);

	/// <inheritdoc />
	public Task<VkCollection<Market>> SearchAsync(MarketSearchParams @params,
												CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Search(@params), token);

	/// <inheritdoc />
	public Task<VkCollection<MarketAlbum>> GetAlbumsAsync(long ownerId,
														int? offset = null,
														int? count = null,
														CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetAlbums(ownerId, offset, count), token);

	/// <inheritdoc />
	public Task<VkCollection<MarketAlbum>> GetAlbumByIdAsync(long ownerId,
															IEnumerable<long> albumIds,
															CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetAlbumById(ownerId, albumIds), token);

	/// <inheritdoc />
	public Task<long> CreateCommentAsync(MarketCreateCommentParams @params,
										CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			CreateComment(@params), token);

	/// <inheritdoc />
	public Task<VkCollection<MarketComment>> GetCommentsAsync(MarketGetCommentsParams @params,
															CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetComments(@params), token);

	/// <inheritdoc />
	public Task<bool> DeleteCommentAsync(long ownerId,
										long commentId,
										CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			DeleteComment(ownerId, commentId), token);

	/// <inheritdoc />
	public Task<bool> RestoreCommentAsync(long ownerId,
										long commentId,
										CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			RestoreComment(ownerId, commentId), token);

	/// <inheritdoc />
	public Task<bool> EditCommentAsync(long ownerId,
										long commentId,
										string message,
										IEnumerable<MediaAttachment> attachments = null,
										CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			EditComment(ownerId, commentId, message, attachments), token);

	/// <inheritdoc />
	public Task<bool> ReportCommentAsync(long ownerId,
										long commentId,
										ReportReason reason,
										CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			ReportComment(ownerId, commentId, reason), token);

	/// <inheritdoc />
	public Task<bool> ReportAsync(long ownerId,
								long itemId,
								ReportReason reason,
								CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Report(ownerId, itemId, reason), token);

	/// <inheritdoc />
	public Task<long> AddAsync(MarketProductParams @params,
								CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Add(@params), token);

	/// <inheritdoc />
	public Task<bool> EditAsync(MarketProductParams @params,
								CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Edit(@params), token);

	/// <inheritdoc />
	public Task<bool> DeleteAsync(long ownerId,
								long itemId,
								CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Delete(ownerId, itemId), token);

	/// <inheritdoc />
	public Task<bool> RestoreAsync(long ownerId,
									long itemId,
									CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Restore(ownerId, itemId), token);

	/// <inheritdoc />
	public Task<bool> ReorderItemsAsync(long ownerId,
										long albumId,
										long itemId,
										long? before,
										long? after,
										CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			ReorderItems(ownerId, albumId, itemId, before, after), token);

	/// <inheritdoc />
	public Task<bool> ReorderAlbumsAsync(long ownerId,
										long albumId,
										long? before = null,
										long? after = null,
										CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			ReorderAlbums(ownerId, albumId, before, after), token);

	/// <inheritdoc />
	public Task<long> AddAlbumAsync(long ownerId,
									string title,
									long? photoId = null,
									bool mainAlbum = false,
									bool isHidden = false,
									CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			AddAlbum(ownerId, title, photoId, mainAlbum, isHidden), token);

	/// <inheritdoc />
	public Task<bool> EditAlbumAsync(long ownerId,
									long albumId,
									string title,
									long? photoId = null,
									bool mainAlbum = false,
									bool isHidden = false,
									CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			EditAlbum(ownerId, albumId, title, photoId, mainAlbum, isHidden), token);

	/// <inheritdoc />
	public Task<bool> DeleteAlbumAsync(long ownerId,
										long albumId,
										CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			DeleteAlbum(ownerId, albumId), token);

	/// <inheritdoc />
	public Task<bool> RemoveFromAlbumAsync(long ownerId,
											long itemId,
											IEnumerable<long> albumIds,
											CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			RemoveFromAlbum(ownerId, itemId, albumIds), token);

	/// <inheritdoc />
	public Task<bool> AddToAlbumAsync(long ownerId,
									long itemId,
									IEnumerable<long> albumIds,
									CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			AddToAlbum(ownerId, itemId, albumIds), token);

	/// <inheritdoc />
	public Task<VkCollection<MarketCategory>> GetCategoriesAsync(long? count,
																long? offset,
																CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetCategories(count, offset), token);
}