using System.Collections.Generic;
using System.Threading.Tasks;
using VkNet.Enums;
using VkNet.Model;
using VkNet.Model.Attachments;
using VkNet.Model.RequestParams.Market;
using VkNet.Utils;

namespace VkNet.Categories;

public partial class MarketsCategory
{
	/// <inheritdoc />
	public Task<VkCollection<Market>> GetAsync(long ownerId, long? albumId = null, int? count = null, int? offset = null,
												bool extended = false) => TypeHelper.TryInvokeMethodAsync(() =>
		Get(ownerId, albumId, count, offset, extended));

	/// <inheritdoc />
	public Task<VkCollection<Market>> GetByIdAsync(IEnumerable<string> itemIds, bool extended = false) =>
		TypeHelper.TryInvokeMethodAsync(() => GetById(itemIds, extended));

	/// <inheritdoc />
	public Task<VkCollection<Market>> SearchAsync(MarketSearchParams @params) => TypeHelper.TryInvokeMethodAsync(() => Search(@params));

	/// <inheritdoc />
	public Task<VkCollection<MarketAlbum>> GetAlbumsAsync(long ownerId, int? offset = null, int? count = null) =>
		TypeHelper.TryInvokeMethodAsync(() => GetAlbums(ownerId, offset, count));

	/// <inheritdoc />
	public Task<VkCollection<MarketAlbum>> GetAlbumByIdAsync(long ownerId, IEnumerable<long> albumIds) =>
		TypeHelper.TryInvokeMethodAsync(() => GetAlbumById(ownerId, albumIds));

	/// <inheritdoc />
	public Task<long> CreateCommentAsync(MarketCreateCommentParams @params) =>
		TypeHelper.TryInvokeMethodAsync(() => CreateComment(@params));

	/// <inheritdoc />
	public Task<VkCollection<MarketComment>> GetCommentsAsync(MarketGetCommentsParams @params) =>
		TypeHelper.TryInvokeMethodAsync(() => GetComments(@params));

	/// <inheritdoc />
	public Task<bool> DeleteCommentAsync(long ownerId, long commentId) =>
		TypeHelper.TryInvokeMethodAsync(() => DeleteComment(ownerId, commentId));

	/// <inheritdoc />
	public Task<bool> RestoreCommentAsync(long ownerId, long commentId) =>
		TypeHelper.TryInvokeMethodAsync(() => RestoreComment(ownerId, commentId));

	/// <inheritdoc />
	public Task<bool> EditCommentAsync(long ownerId, long commentId, string message, IEnumerable<MediaAttachment> attachments = null) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			EditComment(ownerId, commentId, message, attachments));

	/// <inheritdoc />
	public Task<bool> ReportCommentAsync(long ownerId, long commentId, ReportReason reason) => TypeHelper.TryInvokeMethodAsync(() =>
		ReportComment(ownerId, commentId, reason));

	/// <inheritdoc />
	public Task<bool> ReportAsync(long ownerId, long itemId, ReportReason reason) =>
		TypeHelper.TryInvokeMethodAsync(() => Report(ownerId, itemId, reason));

	/// <inheritdoc />
	public Task<long> AddAsync(MarketProductParams @params) => TypeHelper.TryInvokeMethodAsync(() => Add(@params));

	/// <inheritdoc />
	public Task<bool> EditAsync(MarketProductParams @params) => TypeHelper.TryInvokeMethodAsync(() => Edit(@params));

	/// <inheritdoc />
	public Task<bool> DeleteAsync(long ownerId, long itemId) => TypeHelper.TryInvokeMethodAsync(() => Delete(ownerId, itemId));

	/// <inheritdoc />
	public Task<bool> RestoreAsync(long ownerId, long itemId) => TypeHelper.TryInvokeMethodAsync(() => Restore(ownerId, itemId));

	/// <inheritdoc />
	public Task<bool> ReorderItemsAsync(long ownerId, long albumId, long itemId, long? before, long? after) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			ReorderItems(ownerId, albumId, itemId, before, after));

	/// <inheritdoc />
	public Task<bool> ReorderAlbumsAsync(long ownerId, long albumId, long? before = null, long? after = null) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			ReorderAlbums(ownerId, albumId, before, after));

	/// <inheritdoc />
	public Task<long> AddAlbumAsync(long ownerId, string title, long? photoId = null, bool mainAlbum = false) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			AddAlbum(ownerId, title, photoId, mainAlbum));

	/// <inheritdoc />
	public Task<bool> EditAlbumAsync(long ownerId, long albumId, string title, long? photoId = null, bool mainAlbum = false) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			EditAlbum(ownerId, albumId, title, photoId, mainAlbum));

	/// <inheritdoc />
	public Task<bool> DeleteAlbumAsync(long ownerId, long albumId) => TypeHelper.TryInvokeMethodAsync(() => DeleteAlbum(ownerId, albumId));

	/// <inheritdoc />
	public Task<bool> RemoveFromAlbumAsync(long ownerId, long itemId, IEnumerable<long> albumIds) => TypeHelper.TryInvokeMethodAsync(() =>
		RemoveFromAlbum(ownerId, itemId, albumIds));

	/// <inheritdoc />
	public Task<bool> AddToAlbumAsync(long ownerId, long itemId, IEnumerable<long> albumIds) => TypeHelper.TryInvokeMethodAsync(() =>
		AddToAlbum(ownerId, itemId, albumIds));

	/// <inheritdoc />
	public Task<VkCollection<MarketCategory>> GetCategoriesAsync(long? count, long? offset) =>
		TypeHelper.TryInvokeMethodAsync(() => GetCategories(count, offset));
}