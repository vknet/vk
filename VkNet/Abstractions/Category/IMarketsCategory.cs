using System.Collections.Generic;
using VkNet.Enums;
using VkNet.Model;
using VkNet.Model.Attachments;
using VkNet.Model.RequestParams.Market;
using VkNet.Utils;

namespace VkNet.Abstractions
{
	/// <inheritdoc cref="IMarketsCategoryAsync"/>
	public interface IMarketsCategory : IMarketsCategoryAsync
	{
		/// <inheritdoc cref="IMarketsCategoryAsync.GetAsync"/>
		VkCollection<Market> Get(long ownerId, long? albumId = null, int? count = null, int? offset = null, bool extended = false);

		/// <inheritdoc cref="IMarketsCategoryAsync.GetByIdAsync"/>
		VkCollection<Market> GetById(IEnumerable<string> itemIds, bool extended = false);

		/// <inheritdoc cref="IMarketsCategoryAsync.SearchAsync"/>
		VkCollection<Market> Search(MarketSearchParams @params);

		/// <inheritdoc cref="IMarketsCategoryAsync.GetAlbumsAsync"/>
		VkCollection<MarketAlbum> GetAlbums(long ownerId, int? offset = null, int? count = null);

		/// <inheritdoc cref="IMarketsCategoryAsync.GetAlbumByIdAsync"/>
		VkCollection<MarketAlbum> GetAlbumById(long ownerId, IEnumerable<long> albumIds);

		/// <inheritdoc cref="IMarketsCategoryAsync.CreateCommentAsync"/>
		long CreateComment(MarketCreateCommentParams @params);

		/// <inheritdoc cref="IMarketsCategoryAsync.GetCommentsAsync"/>
		VkCollection<MarketComment> GetComments(MarketGetCommentsParams @params);

		/// <inheritdoc cref="IMarketsCategoryAsync.DeleteCommentAsync"/>
		bool DeleteComment(long ownerId, long commentId);

		/// <inheritdoc cref="IMarketsCategoryAsync.RestoreCommentAsync"/>
		bool RestoreComment(long ownerId, long commentId);

		/// <inheritdoc cref="IMarketsCategoryAsync.EditCommentAsync"/>
		bool EditComment(long ownerId, long commentId, string message, IEnumerable<MediaAttachment> attachments = null);

		/// <inheritdoc cref="IMarketsCategoryAsync.ReportCommentAsync"/>
		bool ReportComment(long ownerId, long commentId, ReportReason reason);

		/// <inheritdoc cref="IMarketsCategoryAsync.ReportAsync"/>
		bool Report(long ownerId, long itemId, ReportReason reason);

		/// <inheritdoc cref="IMarketsCategoryAsync.AddAsync"/>
		long Add(MarketProductParams @params);

		/// <inheritdoc cref="IMarketsCategoryAsync.EditAsync"/>
		bool Edit(MarketProductParams @params);

		/// <inheritdoc cref="IMarketsCategoryAsync.DeleteAsync"/>
		bool Delete(long ownerId, long itemId);

		/// <inheritdoc cref="IMarketsCategoryAsync.RestoreAsync"/>
		bool Restore(long ownerId, long itemId);

		/// <inheritdoc cref="IMarketsCategoryAsync.ReorderItemsAsync"/>
		bool ReorderItems(long ownerId, long albumId, long itemId, long? before, long? after);

		/// <inheritdoc cref="IMarketsCategoryAsync.ReorderAlbumsAsync"/>
		bool ReorderAlbums(long ownerId, long albumId, long? before = null, long? after = null);

		/// <inheritdoc cref="IMarketsCategoryAsync.AddAlbumAsync"/>
		long AddAlbum(long ownerId, string title, long? photoId = null, bool mainAlbum = false);

		/// <inheritdoc cref="IMarketsCategoryAsync.EditAlbumAsync"/>
		bool EditAlbum(long ownerId, long albumId, string title, long? photoId = null, bool mainAlbum = false);

		/// <inheritdoc cref="IMarketsCategoryAsync.DeleteAlbumAsync"/>
		bool DeleteAlbum(long ownerId, long albumId);

		/// <inheritdoc cref="IMarketsCategoryAsync.RemoveFromAlbumAsync"/>
		bool RemoveFromAlbum(long ownerId, long itemId, IEnumerable<long> albumIds);

		/// <inheritdoc cref="IMarketsCategoryAsync.AddToAlbumAsync"/>
		bool AddToAlbum(long ownerId, long itemId, IEnumerable<long> albumIds);

		/// <inheritdoc cref="IMarketsCategoryAsync.GetCategoriesAsync"/>
		VkCollection<MarketCategory> GetCategories(long? count, long? offset);
	}
}