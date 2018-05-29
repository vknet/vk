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
		public async Task<VkCollection<Video>> GetAsync(VideoGetParams @params)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Video.Get(@params: @params));
		}

		/// <inheritdoc />
		public async Task<bool> EditAsync(VideoEditParams @params)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Video.Edit(@params: @params));
		}

		/// <inheritdoc />
		public async Task<long> AddAsync(long videoId, long ownerId, long? targetId = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Video.Add(videoId: videoId, ownerId: ownerId, targetId: targetId));
		}

		/// <inheritdoc />
		public async Task<Video> SaveAsync(VideoSaveParams @params)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Video.Save(@params: @params));
		}

		/// <inheritdoc />
		public async Task<bool> DeleteAsync(long videoId, long? ownerId = null, long? targetId = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.Video.Delete(videoId: videoId, ownerId: ownerId, targetId: targetId));
		}

		/// <inheritdoc />
		public async Task<bool> RestoreAsync(long videoId, long? ownerId = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Video.Restore(videoId: videoId, ownerId: ownerId));
		}

		/// <inheritdoc />
		public async Task<VkCollection<Video>> SearchAsync(VideoSearchParams @params)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Video.Search(@params: @params));
		}

		/// <inheritdoc />
		public async Task<VkCollection<VideoAlbum>> GetAlbumsAsync(long? ownerId = null
																	, long? offset = null
																	, long? count = null
																	, bool? extended = null
																	, bool? needSystem = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.Video.GetAlbums(ownerId: ownerId, offset: offset, count: count, extended: extended, needSystem: needSystem));
		}

		/// <inheritdoc />
		public async Task<long> AddAlbumAsync(string title, long? groupId = null, IEnumerable<Privacy> privacy = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Video.AddAlbum(title: title, groupId: groupId, privacy: privacy));
		}

		/// <inheritdoc />
		public async Task<bool> EditAlbumAsync(long albumId, string title, long? groupId = null, Privacy privacy = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.Video.EditAlbum(albumId: albumId, title: title, groupId: groupId, privacy: privacy));
		}

		/// <inheritdoc />
		public async Task<bool> DeleteAlbumAsync(long albumId, long? groupId = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Video.DeleteAlbum(albumId: albumId, groupId: groupId));
		}

		/// <inheritdoc />
		public async Task<VkCollection<Comment>> GetCommentsAsync(VideoGetCommentsParams @params)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Video.GetComments(@params: @params));
		}

		/// <inheritdoc />
		public async Task<long> CreateCommentAsync(VideoCreateCommentParams @params)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Video.CreateComment(@params: @params));
		}

		/// <inheritdoc />
		public async Task<bool> DeleteCommentAsync(long commentId, long? ownerId)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Video.DeleteComment(commentId: commentId, ownerId: ownerId));
		}

		/// <inheritdoc />
		public async Task<bool> RestoreCommentAsync(long commentId, long? ownerId)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Video.RestoreComment(commentId: commentId, ownerId: ownerId));
		}

		/// <inheritdoc />
		public async Task<bool> EditCommentAsync(long commentId
												, string message
												, long? ownerId = null
												, IEnumerable<MediaAttachment> attachments = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.Video.EditComment(commentId: commentId, message: message, ownerId: ownerId, attachments: attachments));
		}

		/// <inheritdoc />
		public async Task<bool> ReportAsync(long videoId
											, ReportReason reason
											, long? ownerId
											, string comment = null
											, string searchQuery = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.Video.Report(videoId: videoId, reason: reason, ownerId: ownerId, comment: comment, searchQuery: searchQuery));
		}

		/// <inheritdoc />
		public async Task<bool> ReportCommentAsync(long commentId, long ownerId, ReportReason reason)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.Video.ReportComment(commentId: commentId, ownerId: ownerId, reason: reason));
		}

		/// <inheritdoc />
		public async Task<VideoAlbum> GetAlbumByIdAsync(long albumId, long? ownerId = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Video.GetAlbumById(albumId: albumId, ownerId: ownerId));
		}

		/// <inheritdoc />
		public async Task<bool> ReorderAlbumsAsync(long albumId, long? ownerId, long? before, long? after)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.Video.ReorderAlbums(albumId: albumId, ownerId: ownerId, before: before, after: after));
		}

		/// <inheritdoc />
		public async Task<bool> ReorderVideosAsync(VideoReorderVideosParams @params)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Video.ReorderVideos(@params: @params));
		}

		/// <inheritdoc />
		public async Task<bool> AddToAlbumAsync(long ownerId
												, long videoId
												, IEnumerable<string> albumIds
												, long? targetId = null
												, long? albumId = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.Video.AddToAlbum(ownerId: ownerId, videoId: videoId, albumIds: albumIds, targetId: targetId, albumId: albumId));
		}

		/// <inheritdoc />
		public async Task<bool> RemoveFromAlbumAsync(long ownerId
													, long videoId
													, IEnumerable<string> albumIds
													, long? targetId = null
													, long? albumId = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.Video.RemoveFromAlbum(ownerId: ownerId
							, videoId: videoId
							, albumIds: albumIds
							, targetId: targetId
							, albumId: albumId));
		}

		/// <inheritdoc />
		public async Task<VkCollection<VideoAlbum>> GetAlbumsByVideoAsync(long? targetId, long ownerId, long videoId, bool? extended)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.Video.GetAlbumsByVideo(targetId: targetId, ownerId: ownerId, videoId: videoId, extended: extended));
		}

		/// <inheritdoc />
		public async Task<ReadOnlyCollection<VideoCatalog>> GetCatalogAsync(VideoGetCatalogParams @params)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Video.GetCatalog(@params: @params));
		}

		/// <inheritdoc />
		public async Task<ReadOnlyCollection<VideoCatalogItem>> GetCatalogSectionAsync(string sectionId
																						, string from
																						, long? count = null
																						, bool? extended = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.Video.GetCatalogSection(sectionId: sectionId, from: from, count: count, extended: extended));
		}

		/// <inheritdoc />
		public async Task<bool> HideCatalogSectionAsync(long sectionId)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Video.HideCatalogSection(sectionId: sectionId));
		}
	}
}