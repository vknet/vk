using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using VkNet.Enums;
using VkNet.Enums.SafetyEnums;
using VkNet.Model;
using VkNet.Model.Attachments;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkNet.Categories
{
	/// <inheritdoc />
	public partial class VideoCategory
	{
		/// <inheritdoc />
		public Task<VkCollection<Video>> GetAsync(VideoGetParams @params)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => _vk.Video.Get(@params: @params));
		}

		/// <inheritdoc />
		public Task<bool> EditAsync(VideoEditParams @params)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => _vk.Video.Edit(@params: @params));
		}

		/// <inheritdoc />
		public Task<long> AddAsync(long videoId, long ownerId, long? targetId = null)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => _vk.Video.Add(videoId: videoId, ownerId: ownerId, targetId: targetId));
		}

		/// <inheritdoc />
		public Task<Video> SaveAsync(VideoSaveParams @params)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => _vk.Video.Save(@params: @params));
		}

		/// <inheritdoc />
		public Task<bool> DeleteAsync(long videoId, long? ownerId = null, long? targetId = null)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.Video.Delete(videoId: videoId, ownerId: ownerId, targetId: targetId));
		}

		/// <inheritdoc />
		public Task<bool> RestoreAsync(long videoId, long? ownerId = null)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => _vk.Video.Restore(videoId: videoId, ownerId: ownerId));
		}

		/// <inheritdoc />
		public Task<VkCollection<Video>> SearchAsync(VideoSearchParams @params)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => _vk.Video.Search(@params: @params));
		}

		/// <inheritdoc />
		public Task<VkCollection<VideoAlbum>> GetAlbumsAsync(long? ownerId = null
																	, long? offset = null
																	, long? count = null
																	, bool? extended = null
																	, bool? needSystem = null)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.Video.GetAlbums(ownerId: ownerId, offset: offset, count: count, extended: extended, needSystem: needSystem));
		}

		/// <inheritdoc />
		public Task<long> AddAlbumAsync(string title, long? groupId = null, IEnumerable<Privacy> privacy = null)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => _vk.Video.AddAlbum(title: title, groupId: groupId, privacy: privacy));
		}

		/// <inheritdoc />
		public Task<bool> EditAlbumAsync(long albumId, string title, long? groupId = null, Privacy privacy = null)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.Video.EditAlbum(albumId: albumId, title: title, groupId: groupId, privacy: privacy));
		}

		/// <inheritdoc />
		public Task<bool> DeleteAlbumAsync(long albumId, long? groupId = null)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => _vk.Video.DeleteAlbum(albumId: albumId, groupId: groupId));
		}

		/// <inheritdoc />
		public Task<VkCollection<Comment>> GetCommentsAsync(VideoGetCommentsParams @params)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => _vk.Video.GetComments(@params: @params));
		}

		/// <inheritdoc />
		public Task<long> CreateCommentAsync(VideoCreateCommentParams @params)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => _vk.Video.CreateComment(@params: @params));
		}

		/// <inheritdoc />
		public Task<bool> DeleteCommentAsync(long commentId, long? ownerId)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => _vk.Video.DeleteComment(commentId: commentId, ownerId: ownerId));
		}

		/// <inheritdoc />
		public Task<bool> RestoreCommentAsync(long commentId, long? ownerId)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => _vk.Video.RestoreComment(commentId: commentId, ownerId: ownerId));
		}

		/// <inheritdoc />
		public Task<bool> EditCommentAsync(long commentId
												, string message
												, long? ownerId = null
												, IEnumerable<MediaAttachment> attachments = null)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.Video.EditComment(commentId: commentId, message: message, ownerId: ownerId, attachments: attachments));
		}

		/// <inheritdoc />
		public Task<bool> ReportAsync(long videoId
											, ReportReason reason
											, long? ownerId
											, string comment = null
											, string searchQuery = null)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.Video.Report(videoId: videoId, reason: reason, ownerId: ownerId, comment: comment, searchQuery: searchQuery));
		}

		/// <inheritdoc />
		public Task<bool> ReportCommentAsync(long commentId, long ownerId, ReportReason reason)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.Video.ReportComment(commentId: commentId, ownerId: ownerId, reason: reason));
		}

		/// <inheritdoc />
		public Task<VideoAlbum> GetAlbumByIdAsync(long albumId, long? ownerId = null)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => _vk.Video.GetAlbumById(albumId: albumId, ownerId: ownerId));
		}

		/// <inheritdoc />
		public Task<bool> ReorderAlbumsAsync(long albumId, long? ownerId, long? before, long? after)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.Video.ReorderAlbums(albumId: albumId, ownerId: ownerId, before: before, after: after));
		}

		/// <inheritdoc />
		public Task<bool> ReorderVideosAsync(VideoReorderVideosParams @params)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => _vk.Video.ReorderVideos(@params: @params));
		}

		/// <inheritdoc />
		public Task<bool> AddToAlbumAsync(long ownerId
												, long videoId
												, IEnumerable<string> albumIds
												, long? targetId = null
												, long? albumId = null)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.Video.AddToAlbum(ownerId: ownerId, videoId: videoId, albumIds: albumIds, targetId: targetId, albumId: albumId));
		}

		/// <inheritdoc />
		public Task<bool> RemoveFromAlbumAsync(long ownerId
													, long videoId
													, IEnumerable<string> albumIds
													, long? targetId = null
													, long? albumId = null)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.Video.RemoveFromAlbum(ownerId: ownerId
							, videoId: videoId
							, albumIds: albumIds
							, targetId: targetId
							, albumId: albumId));
		}

		/// <inheritdoc />
		public Task<VkCollection<VideoAlbum>> GetAlbumsByVideoAsync(long? targetId, long ownerId, long videoId, bool? extended)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.Video.GetAlbumsByVideo(targetId: targetId, ownerId: ownerId, videoId: videoId, extended: extended));
		}

		/// <inheritdoc />
		public Task<ReadOnlyCollection<VideoCatalog>> GetCatalogAsync(VideoGetCatalogParams @params)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => _vk.Video.GetCatalog(@params: @params));
		}

		/// <inheritdoc />
		public Task<ReadOnlyCollection<VideoCatalogItem>> GetCatalogSectionAsync(string sectionId
																						, string from
																						, long? count = null
																						, bool? extended = null)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.Video.GetCatalogSection(sectionId: sectionId, from: from, count: count, extended: extended));
		}

		/// <inheritdoc />
		public Task<bool> HideCatalogSectionAsync(long sectionId)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => _vk.Video.HideCatalogSection(sectionId: sectionId));
		}
	}
}