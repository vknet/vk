using System.Collections.Generic;
using VkNet.Abstractions;
using VkNet.Enums;
using VkNet.Model;
using VkNet.Model.Attachments;
using VkNet.Model.RequestParams.Market;
using VkNet.Utils;

namespace VkNet.Categories
{
	/// <inheritdoc />
	public partial class MarketsCategory : IMarketsCategory
	{
		/// <summary>
		/// API.
		/// </summary>
		private readonly IVkApiInvoke _vk;

		/// <summary>
		/// api vk.com
		/// </summary>
		/// <param name="vk"> API. </param>
		public MarketsCategory(IVkApiInvoke vk)
		{
			_vk = vk;
		}

		/// <inheritdoc />
		public VkCollection<Market> Get(long ownerId, long? albumId = null, int? count = null, int? offset = null, bool extended = false)
		{
			var parameters = new VkParameters
			{
				{ "owner_id", ownerId },
				{ "album_id", albumId },
				{ "count", count },
				{ "offset", offset },
				{ "extended", extended }
			};

			return _vk.Call("market.get", parameters).ToVkCollectionOf<Market>(selector: x => x);
		}

		/// <inheritdoc />
		public VkCollection<Market> GetById(IEnumerable<string> itemIds, bool extended = false)
		{
			var parameters = new VkParameters
			{
				{ "item_ids", itemIds },
				{ "extended", extended }
			};

			return _vk.Call("market.getById", parameters).ToVkCollectionOf<Market>(selector: x => x);
		}

		/// <inheritdoc />
		public VkCollection<Market> Search(MarketSearchParams @params)
		{
			return _vk.Call("market.search",
					new VkParameters
					{
						{ "owner_id", @params.OwnerId },
						{ "album_id", @params.AlbumId },
						{ "q", @params.Query },
						{ "price_from", @params.PriceFrom },
						{ "price_to", @params.PriceTo },
						{ "tags", @params.Tags },
						{ "sort", @params.Sort },
						{ "rev", @params.Rev },
						{ "offset", @params.Offset },
						{ "count", @params.Count },
						{ "extended", @params.Extended }
					})
				.ToVkCollectionOf<Market>(selector: x => x);
		}

		/// <inheritdoc />
		public VkCollection<MarketAlbum> GetAlbums(long ownerId, int? offset = null, int? count = null)
		{
			var parameters = new VkParameters
			{
				{ "owner_id", ownerId },
				{ "offset", offset },
				{ "count", count }
			};

			return _vk.Call("market.getAlbums", parameters).ToVkCollectionOf<MarketAlbum>(selector: x => x);
		}

		/// <inheritdoc />
		public VkCollection<MarketAlbum> GetAlbumById(long ownerId, IEnumerable<long> albumIds)
		{
			var parameters = new VkParameters
			{
				{ "owner_id", ownerId },
				{ "album_ids", albumIds }
			};

			return _vk.Call("market.getAlbumById", parameters).ToVkCollectionOf<MarketAlbum>(selector: x => x);
		}

		/// <inheritdoc />
		public long CreateComment(MarketCreateCommentParams @params)
		{
			return _vk.Call("market.createComment",
				new VkParameters
				{
					{ "owner_id", @params.OwnerId },
					{ "item_id", @params.ItemId },
					{ "message", @params.Message },
					{ "attachments", @params.Attachments },
					{ "from_group", @params.FromGroup },
					{ "reply_to_comment", @params.ReplyToComment },
					{ "sticker_id", @params.StickerId },
					{ "guid", @params.Guid }
				});
		}

		/// <inheritdoc />
		public VkCollection<MarketComment> GetComments(MarketGetCommentsParams @params)
		{
			return _vk.Call("market.getComments",
					new VkParameters
					{
						{ "owner_id", @params.OwnerId },
						{ "item_id", @params.ItemId },
						{ "need_likes", @params.NeedLikes },
						{ "start_comment_id", @params.StartCommentId },
						{ "offset", @params.Offset },
						{ "count", @params.Count },
						{ "sort", @params.Sort },
						{ "extended", @params.Extended },
						{ "fields", @params.Fields }
					})
				.ToVkCollectionOf<MarketComment>(selector: x => x);
		}

		/// <inheritdoc />
		public bool DeleteComment(long ownerId, long commentId)
		{
			var parameters = new VkParameters
			{
				{ "owner_id", ownerId },
				{ "comment_id", commentId }
			};

			return _vk.Call("market.deleteComment", parameters);
		}

		/// <inheritdoc />
		public bool RestoreComment(long ownerId, long commentId)
		{
			var parameters = new VkParameters
			{
				{ "owner_id", ownerId },
				{ "comment_id", commentId }
			};

			return _vk.Call("market.restoreComment", parameters);
		}

		/// <inheritdoc />
		public bool EditComment(long ownerId, long commentId, string message, IEnumerable<MediaAttachment> attachments = null)
		{
			var parameters = new VkParameters
			{
				{ "owner_id", ownerId },
				{ "comment_id", commentId },
				{ "message", message },
				{ "attachments", attachments }
			};

			return _vk.Call("market.editComment", parameters);
		}

		/// <inheritdoc />
		public bool ReportComment(long ownerId, long commentId, ReportReason reason)
		{
			var parameters = new VkParameters
			{
				{ "owner_id", ownerId },
				{ "comment_id", commentId },
				{ "reason", reason }
			};

			return _vk.Call("market.reportComment", parameters);
		}

		/// <inheritdoc />
		public bool Report(long ownerId, long itemId, ReportReason reason)
		{
			var parameters = new VkParameters
			{
				{ "owner_id", ownerId },
				{ "item_id", itemId },
				{ "reason", reason }
			};

			return _vk.Call("market.report", parameters);
		}

		/// <inheritdoc />
		public long Add(MarketProductParams @params)
		{
			return _vk.Call("market.add",
				new VkParameters
				{
					{ "owner_id", @params.OwnerId },
					{ "item_id", @params.ItemId },
					{ "name", @params.Name },
					{ "description", @params.Description },
					{ "url", @params.Url },
					{ "sku", @params.Sku },
					{ "category_id", @params.CategoryId },
					{ "price", @params.Price },
					{ "old_price", @params.OldPrice },
					{ "deleted", @params.Deleted },
					{ "main_photo_id", @params.MainPhotoId },
					{ "photo_ids", @params.PhotoIds },
					{ "dimension_width", @params.DimensionWidth },
					{ "dimension_height", @params.DimensionHeight },
					{ "dimension_length", @params.DimensionLength },
					{ "weight", @params.Weight }
				})[key: "market_item_id"];
		}

		/// <inheritdoc />
		public bool Edit(MarketProductParams editParams)
		{
			return _vk.Call<bool>("market.edit",
				new VkParameters
				{
					{ "owner_id", editParams.OwnerId },
					{ "item_id", editParams.ItemId },
					{ "name", editParams.Name },
					{ "description", editParams.Description },
					{ "url", editParams.Url },
					{ "sku", editParams.Sku },
					{ "category_id", editParams.CategoryId },
					{ "price", editParams.Price },
					{ "old_price", editParams.OldPrice },
					{ "deleted", editParams.Deleted },
					{ "main_photo_id", editParams.MainPhotoId },
					{ "photo_ids", editParams.PhotoIds },
					{ "dimension_width", editParams.DimensionWidth },
					{ "dimension_height", editParams.DimensionHeight },
					{ "dimension_length", editParams.DimensionLength },
					{ "weight", editParams.Weight }
				});
		}

		/// <inheritdoc />
		public bool Delete(long ownerId, long itemId)
		{
			var parameters = new VkParameters
			{
				{ "owner_id", ownerId },
				{ "item_id", itemId }
			};

			return _vk.Call("market.delete", parameters);
		}

		/// <inheritdoc />
		public bool Restore(long ownerId, long itemId)
		{
			var parameters = new VkParameters
			{
				{ "owner_id", ownerId },
				{ "item_id", itemId }
			};

			return _vk.Call("market.restore", parameters);
		}

		/// <inheritdoc />
		public bool ReorderItems(long ownerId, long albumId, long itemId, long? before, long? after)
		{
			var parameters = new VkParameters
			{
				{ "owner_id", ownerId },
				{ "album_id", albumId },
				{ "item_id", itemId },
				{ "before", before },
				{ "after", after }
			};

			return _vk.Call("market.reorderItems", parameters);
		}

		/// <inheritdoc />
		public bool ReorderAlbums(long ownerId, long albumId, long? before = null, long? after = null)
		{
			var parameters = new VkParameters
			{
				{ "owner_id", ownerId },
				{ "album_id", albumId },
				{ "before", before },
				{ "after", after }
			};

			return _vk.Call("market.reorderAlbums", parameters);
		}

		/// <inheritdoc />
		public long AddAlbum(long ownerId, string title, long? photoId = null, bool mainAlbum = false)
		{
			var parameters = new VkParameters
			{
				{ "owner_id", ownerId },
				{ "title", title },
				{ "photo_id", photoId },
				{ "main_album", mainAlbum }
			};

			return _vk.Call("market.addAlbum", parameters)[key: "market_album_id"];
		}

		/// <inheritdoc />
		public bool EditAlbum(long ownerId, long albumId, string title, long? photoId = null, bool mainAlbum = false)
		{
			var parameters = new VkParameters
			{
				{ "owner_id", ownerId },
				{ "album_id", albumId },
				{ "title", title },
				{ "photo_id", photoId },
				{ "main_album", mainAlbum }
			};

			return _vk.Call("market.editAlbum", parameters);
		}

		/// <inheritdoc />
		public bool DeleteAlbum(long ownerId, long albumId)
		{
			var parameters = new VkParameters
			{
				{ "owner_id", ownerId },
				{ "album_id", albumId }
			};

			return _vk.Call("market.deleteAlbum", parameters);
		}

		/// <inheritdoc />
		public bool RemoveFromAlbum(long ownerId, long itemId, IEnumerable<long> albumIds)
		{
			var parameters = new VkParameters
			{
				{ "owner_id", ownerId },
				{ "item_id", itemId },
				{ "album_ids", albumIds }
			};

			return _vk.Call("market.removeFromAlbum", parameters);
		}

		/// <inheritdoc />
		public bool AddToAlbum(long ownerId, long itemId, IEnumerable<long> albumIds)
		{
			var parameters = new VkParameters
			{
				{ "owner_id", ownerId },
				{ "item_id", itemId },
				{ "album_ids", albumIds }
			};

			return _vk.Call("market.addToAlbum", parameters);
		}

		/// <inheritdoc />
		public VkCollection<MarketCategory> GetCategories(long? count, long? offset)
		{
			var parameters = new VkParameters
			{
				{ "count", count },
				{ "offset", offset }
			};

			return _vk.Call("market.getCategories", parameters).ToVkCollectionOf<MarketCategory>(selector: x => x);
		}
	}
}