using System.Collections.Generic;
using System.Threading.Tasks;
using VkNet.Enums;
using VkNet.Model;
using VkNet.Model.Attachments;
using VkNet.Model.RequestParams.Market;
using VkNet.Utils;

namespace VkNet.Categories
{
	public partial class MarketsCategory
	{
		/// <inheritdoc />
		public Task<VkCollection<Market>> GetAsync(long ownerId, long? albumId = null, int? count = null, int? offset = null,
													bool extended = false)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>
				Get(ownerId, albumId, count, offset, extended));
		}

		/// <inheritdoc />
		public Task<VkCollection<Market>> GetByIdAsync(IEnumerable<string> itemIds, bool extended = false)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => GetById(itemIds, extended));
		}

		/// <inheritdoc />
		public Task<VkCollection<Market>> SearchAsync(MarketSearchParams @params)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => Search(@params: @params));
		}

		/// <inheritdoc />
		public Task<VkCollection<MarketAlbum>> GetAlbumsAsync(long ownerId, int? offset = null, int? count = null)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => GetAlbums(ownerId, offset, count));
		}

		/// <inheritdoc />
		public Task<VkCollection<MarketAlbum>> GetAlbumByIdAsync(long ownerId, IEnumerable<long> albumIds)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => GetAlbumById(ownerId, albumIds));
		}

		/// <inheritdoc />
		public Task<long> CreateCommentAsync(MarketCreateCommentParams @params)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => CreateComment(@params: @params));
		}

		/// <inheritdoc />
		public Task<VkCollection<MarketComment>> GetCommentsAsync(MarketGetCommentsParams @params)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => GetComments(@params: @params));
		}

		/// <inheritdoc />
		public Task<bool> DeleteCommentAsync(long ownerId, long commentId)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => DeleteComment(ownerId, commentId));
		}

		/// <inheritdoc />
		public Task<bool> RestoreCommentAsync(long ownerId, long commentId)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => RestoreComment(ownerId, commentId));
		}

		/// <inheritdoc />
		public Task<bool> EditCommentAsync(long ownerId, long commentId, string message, IEnumerable<MediaAttachment> attachments = null)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>
				EditComment(ownerId, commentId, message, attachments));
		}

		/// <inheritdoc />
		public Task<bool> ReportCommentAsync(long ownerId, long commentId, ReportReason reason)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>
				ReportComment(ownerId, commentId, reason));
		}

		/// <inheritdoc />
		public Task<bool> ReportAsync(long ownerId, long itemId, ReportReason reason)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => Report(ownerId, itemId, reason));
		}

		/// <inheritdoc />
		public Task<long> AddAsync(MarketProductParams @params)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => Add(@params: @params));
		}

		/// <inheritdoc />
		public Task<bool> EditAsync(MarketProductParams @params)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => Edit(@params: @params));
		}

		/// <inheritdoc />
		public Task<bool> DeleteAsync(long ownerId, long itemId)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => Delete(ownerId, itemId));
		}

		/// <inheritdoc />
		public Task<bool> RestoreAsync(long ownerId, long itemId)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => Restore(ownerId, itemId));
		}

		/// <inheritdoc />
		public Task<bool> ReorderItemsAsync(long ownerId, long albumId, long itemId, long? before, long? after)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>
				ReorderItems(ownerId, albumId, itemId, before, after));
		}

		/// <inheritdoc />
		public Task<bool> ReorderAlbumsAsync(long ownerId, long albumId, long? before = null, long? after = null)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>
				ReorderAlbums(ownerId, albumId, before, after));
		}

		/// <inheritdoc />
		public Task<long> AddAlbumAsync(long ownerId, string title, long? photoId = null, bool mainAlbum = false)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>
				AddAlbum(ownerId, title, photoId, mainAlbum));
		}

		/// <inheritdoc />
		public Task<bool> EditAlbumAsync(long ownerId, long albumId, string title, long? photoId = null, bool mainAlbum = false)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>
				EditAlbum(ownerId, albumId, title, photoId, mainAlbum));
		}

		/// <inheritdoc />
		public Task<bool> DeleteAlbumAsync(long ownerId, long albumId)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => DeleteAlbum(ownerId, albumId));
		}

		/// <inheritdoc />
		public Task<bool> RemoveFromAlbumAsync(long ownerId, long itemId, IEnumerable<long> albumIds)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>
				RemoveFromAlbum(ownerId, itemId, albumIds));
		}

		/// <inheritdoc />
		public Task<bool> AddToAlbumAsync(long ownerId, long itemId, IEnumerable<long> albumIds)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>
				AddToAlbum(ownerId, itemId, albumIds));
		}

		/// <inheritdoc />
		public Task<VkCollection<MarketCategory>> GetCategoriesAsync(long? count, long? offset)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => GetCategories(count, offset));
		}
	}
}