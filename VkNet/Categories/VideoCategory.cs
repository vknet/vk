using System.Collections.Generic;
using System.Collections.ObjectModel;
using VkNet.Abstractions;
using VkNet.Enums;
using VkNet.Enums.SafetyEnums;
using VkNet.Model;
using VkNet.Model.Attachments;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkNet.Categories
{
	/// <inheritdoc />
	public partial class VideoCategory : IVideoCategory
	{
		private readonly IVkApiInvoke _vk;

		/// <summary>
		/// </summary>
		/// <param name="vk"> </param>
		public VideoCategory(IVkApiInvoke vk)
		{
			_vk = vk;
		}

		/// <inheritdoc />
		public VkCollection<Video> Get(VideoGetParams @params)
		{
			VkErrors.ThrowIfNumberIsNegative(expr: () => @params.Count);
			VkErrors.ThrowIfNumberIsNegative(expr: () => @params.Offset);

			return _vk.Call("video.get", @params).ToVkCollectionOf<Video>(selector: x => x);
		}

		/// <inheritdoc />
		public bool Edit(VideoEditParams @params)
		{
			VkErrors.ThrowIfNumberIsNegative(expr: () => @params.VideoId);

			return _vk.Call("video.edit", @params);
		}

		/// <inheritdoc />
		public long Add(long videoId, long ownerId, long? targetId = null)
		{
			VkErrors.ThrowIfNumberIsNegative(expr: () => videoId);

			var parameters = new VkParameters
			{
				{ "target_id", targetId },
				{ "video_id", videoId },
				{ "owner_id", ownerId }
			};

			return _vk.Call("video.add", parameters);
		}

		/// <inheritdoc />
		public Video Save(VideoSaveParams @params)
		{
			return _vk.Call("video.save", @params);
		}

		/// <inheritdoc />
		public bool Delete(long videoId, long? ownerId = null, long? targetId = null)
		{
			var parameters = new VkParameters
			{
				{ "video_id", videoId },
				{ "owner_id", ownerId },
				{ "target_id", targetId }
			};

			return _vk.Call("video.delete", parameters);
		}

		/// <inheritdoc />
		public bool Restore(long videoId, long? ownerId = null)
		{
			VkErrors.ThrowIfNumberIsNegative(expr: () => videoId);

			var parameters = new VkParameters
			{
				{ "video_id", videoId },
				{ "owner_id", ownerId }
			};

			return _vk.Call("video.restore", parameters);
		}

		/// <inheritdoc />
		public VkCollection<Video> Search(VideoSearchParams @params)
		{
			VkErrors.ThrowIfNullOrEmpty(expr: () => @params.Query);
			VkErrors.ThrowIfNumberIsNegative(expr: () => @params.Count);
			VkErrors.ThrowIfNumberIsNegative(expr: () => @params.Offset);

			return _vk.Call("video.search", @params).ToVkCollectionOf<Video>(selector: x => x);
		}

		/// <inheritdoc />
		public VkCollection<VideoAlbum> GetAlbums(long? ownerId = null, long? offset = null, long? count = null, bool? extended = null,
												bool? needSystem = null)
		{
			VkErrors.ThrowIfNumberIsNegative(expr: () => count);
			VkErrors.ThrowIfNumberIsNegative(expr: () => offset);

			var parameters = new VkParameters
			{
				{ "owner_id", ownerId },
				{ "offset", offset },
				{ "count", count },
				{ "extended", extended },
				{ "need_system", needSystem }
			};

			return _vk.Call("video.getAlbums", parameters).ToVkCollectionOf<VideoAlbum>(selector: x => x);
		}

		/// <inheritdoc />
		public long AddAlbum(string title, long? groupId = null, IEnumerable<Privacy> privacy = null)
		{
			VkErrors.ThrowIfNullOrEmpty(expr: () => title);
			VkErrors.ThrowIfNumberIsNegative(expr: () => groupId);

			var parameters = new VkParameters
			{
				{ "group_id", groupId },
				{ "title", title },
				{ "privacy", privacy }
			};

			var response = _vk.Call("video.addAlbum", parameters);

			return response[key: "album_id"];
		}

		/// <inheritdoc />
		public bool EditAlbum(long albumId, string title, long? groupId = null, Privacy privacy = null)
		{
			VkErrors.ThrowIfNullOrEmpty(expr: () => title);
			VkErrors.ThrowIfNumberIsNegative(expr: () => groupId);

			var parameters = new VkParameters
			{
				{ "group_id", groupId },
				{ "album_id", albumId },
				{ "title", title },
				{ "privacy", privacy }
			};

			return _vk.Call("video.editAlbum", parameters);
		}

		/// <inheritdoc />
		public bool DeleteAlbum(long albumId, long? groupId = null)
		{
			var parameters = new VkParameters
			{
				{ "group_id", groupId },
				{ "album_id", albumId }
			};

			return _vk.Call("video.deleteAlbum", parameters);
		}

		/// <inheritdoc />
		public VkCollection<Comment> GetComments(VideoGetCommentsParams @params)
		{
			VkErrors.ThrowIfNumberIsNegative(expr: () => @params.VideoId);
			VkErrors.ThrowIfNumberIsNegative(expr: () => @params.Count);
			VkErrors.ThrowIfNumberIsNegative(expr: () => @params.Offset);

			return _vk.Call("video.getComments", @params).ToVkCollectionOf<Comment>(selector: x => x);
		}

		/// <inheritdoc />
		public long CreateComment(VideoCreateCommentParams @params)
		{
			VkErrors.ThrowIfNullOrEmpty(expr: () => @params.Message);
			VkErrors.ThrowIfNumberIsNegative(expr: () => @params.VideoId);

			return _vk.Call("video.createComment", @params);
		}

		/// <inheritdoc />
		public bool DeleteComment(long commentId, long? ownerId)
		{
			VkErrors.ThrowIfNumberIsNegative(expr: () => commentId);

			var parameters = new VkParameters
			{
				{ "comment_id", commentId },
				{ "owner_id", ownerId }
			};

			return _vk.Call("video.deleteComment", parameters);
		}

		/// <inheritdoc />
		public bool RestoreComment(long commentId, long? ownerId)
		{
			VkErrors.ThrowIfNumberIsNegative(expr: () => commentId);

			var parameters = new VkParameters
			{
				{ "comment_id", commentId },
				{ "owner_id", ownerId }
			};

			return _vk.Call("video.restoreComment", parameters);
		}

		/// <inheritdoc />
		public bool EditComment(long commentId, string message, long? ownerId = null, IEnumerable<MediaAttachment> attachments = null)
		{
			VkErrors.ThrowIfNullOrEmpty(expr: () => message);
			VkErrors.ThrowIfNumberIsNegative(expr: () => commentId);

			var parameters = new VkParameters
			{
				{ "owner_id", ownerId },
				{ "comment_id", commentId },
				{ "message", message },
				{ "attachments", attachments }
			};

			return _vk.Call("video.editComment", parameters);
		}

		/// <inheritdoc />
		public bool Report(long videoId, ReportReason reason, long? ownerId, string comment = null, string searchQuery = null)
		{
			VkErrors.ThrowIfNumberIsNegative(expr: () => videoId);

			var parameters = new VkParameters
			{
				{ "video_id", videoId },
				{ "owner_id", ownerId },
				{ "reason", reason },
				{ "comment", comment },
				{ "search_query", searchQuery }
			};

			return _vk.Call("video.report", parameters);
		}

		/// <inheritdoc />
		public bool ReportComment(long commentId, long ownerId, ReportReason reason)
		{
			VkErrors.ThrowIfNumberIsNegative(expr: () => commentId);

			var parameters = new VkParameters
			{
				{ "comment_id", commentId },
				{ "owner_id", ownerId },
				{ "reason", reason }
			};

			return _vk.Call("video.reportComment", parameters);
		}

		/// <inheritdoc />
		public VideoAlbum GetAlbumById(long albumId, long? ownerId = null)
		{
			var parameters = new VkParameters
			{
				{ "owner_id", ownerId },
				{ "album_id", albumId }
			};

			return _vk.Call("video.getAlbumById", parameters);
		}

		/// <inheritdoc />
		public bool ReorderAlbums(long albumId, long? ownerId, long? before, long? after)
		{
			var parameters = new VkParameters
			{
				{ "owner_id", ownerId },
				{ "album_id", albumId },
				{ "before", before },
				{ "after", after }
			};

			return _vk.Call("video.reorderAlbums", parameters);
		}

		/// <inheritdoc />
		public bool ReorderVideos(VideoReorderVideosParams @params)
		{
			return _vk.Call("video.reorderVideos", @params);
		}

		/// <inheritdoc />
		public bool AddToAlbum(long ownerId, long videoId, IEnumerable<string> albumIds, long? targetId = null, long? albumId = null)
		{
			var parameters = new VkParameters
			{
				{ "target_id", targetId },
				{ "album_id", albumId },
				{ "album_ids", albumIds },
				{ "owner_id", ownerId },
				{ "video_id", videoId }
			};

			return _vk.Call("video.addToAlbum", parameters);
		}

		/// <inheritdoc />
		public bool RemoveFromAlbum(long ownerId, long videoId, IEnumerable<string> albumIds, long? targetId = null, long? albumId = null)
		{
			var parameters = new VkParameters
			{
				{ "target_id", targetId },
				{ "album_id", albumId },
				{ "album_ids", albumIds },
				{ "owner_id", ownerId },
				{ "video_id", videoId }
			};

			return _vk.Call("video.removeFromAlbum", parameters);
		}

		/// <inheritdoc />
		public VkCollection<VideoAlbum> GetAlbumsByVideo(long? targetId, long ownerId, long videoId, bool? extended)
		{
			var parameters = new VkParameters
			{
				{ "target_id", targetId },
				{ "owner_id", ownerId },
				{ "video_id", videoId },
				{ "extended", extended }
			};

			return _vk.Call("video.getAlbumsByVideo", parameters).ToVkCollectionOf<VideoAlbum>(selector: x => x);
		}

		/// <inheritdoc />
		public ReadOnlyCollection<VideoCatalog> GetCatalog(VideoGetCatalogParams @params)
		{
			var parameters = new VkParameters
			{
				{ "count", @params.Count },
				{ "items_count", @params.ItemsCount },
				{ "from", @params.From },
				{ "extended", @params.Extended }
			};

			return _vk.Call("video.getCatalog", parameters).ToReadOnlyCollectionOf<VideoCatalog>(selector: x => x);
		}

		/// <inheritdoc />
		public ReadOnlyCollection<VideoCatalogItem> GetCatalogSection(string sectionId, string from, long? count = null,
																	bool? extended = null)
		{
			var parameters = new VkParameters
			{
				{ "section_id", sectionId },
				{ "from", from },
				{ "count", count },
				{ "extended", extended }
			};

			return _vk.Call("video.getCatalogSection", parameters)
				.ToReadOnlyCollectionOf<VideoCatalogItem>(selector: x => x);
		}

		/// <inheritdoc />
		public bool HideCatalogSection(long sectionId)
		{
			var parameters = new VkParameters
			{
				{ "section_id", sectionId }
			};

			return _vk.Call("video.hideCatalogSection", parameters);
		}
	}
}