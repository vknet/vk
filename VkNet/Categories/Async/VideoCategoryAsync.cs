using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using VkNet.Enums;
using VkNet.Enums.SafetyEnums;
using VkNet.Model;
using VkNet.Model.Attachments;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkNet.Categories;

/// <inheritdoc />
public partial class VideoCategory
{
	/// <inheritdoc />
	public Task<VkCollection<Video>> GetAsync(VideoGetParams @params,
											CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Get(@params));

	/// <inheritdoc />
	public Task<bool> EditAsync(VideoEditParams @params,
								CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Edit(@params));

	/// <inheritdoc />
	public Task<long> AddAsync(long videoId,
								long ownerId,
								long? targetId = null,
								CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Add(videoId, ownerId, targetId));

	/// <inheritdoc />
	public Task<Video> SaveAsync(VideoSaveParams @params,
								CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Save(@params));

	/// <inheritdoc />
	public Task<bool> DeleteAsync(long videoId,
								long? ownerId = null,
								long? targetId = null,
								CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Delete(videoId, ownerId, targetId));

	/// <inheritdoc />
	public Task<bool> RestoreAsync(long videoId,
									long? ownerId = null,
									CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Restore(videoId, ownerId));

	/// <inheritdoc />
	public Task<VkCollection<Video>> SearchAsync(VideoSearchParams @params,
												CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Search(@params));

	/// <inheritdoc />
	public Task<VkCollection<VideoAlbum>> GetAlbumsAsync(long? ownerId = null,
														long? offset = null,
														long? count = null,
														bool? extended = null,
														bool? needSystem = null,
														CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetAlbums(ownerId, offset, count, extended, needSystem));

	/// <inheritdoc />
	public Task<long> AddAlbumAsync(string title,
									long? groupId = null,
									IEnumerable<Privacy> privacy = null,
									CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			AddAlbum(title, groupId, privacy));

	/// <inheritdoc />
	public Task<bool> EditAlbumAsync(long albumId,
									string title,
									long? groupId = null,
									Privacy privacy = null,
									CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			EditAlbum(albumId, title, groupId, privacy));

	/// <inheritdoc />
	public Task<bool> DeleteAlbumAsync(long albumId,
										long? groupId = null,
										CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			DeleteAlbum(albumId, groupId));

	/// <inheritdoc />
	public Task<VkCollection<Comment>> GetCommentsAsync(VideoGetCommentsParams @params,
														CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetComments(@params));

	/// <inheritdoc />
	public Task<long> CreateCommentAsync(VideoCreateCommentParams @params,
										CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			CreateComment(@params));

	/// <inheritdoc />
	public Task<bool> DeleteCommentAsync(long commentId,
										long? ownerId,
										CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			DeleteComment(commentId, ownerId));

	/// <inheritdoc />
	public Task<bool> RestoreCommentAsync(long commentId,
										long? ownerId,
										CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			RestoreComment(commentId, ownerId));

	/// <inheritdoc />
	public Task<bool> EditCommentAsync(long commentId,
										string message,
										long? ownerId = null,
										IEnumerable<MediaAttachment> attachments = null,
										CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			EditComment(commentId, message, ownerId, attachments));

	/// <inheritdoc />
	public Task<bool> ReportAsync(long videoId,
								ReportReason reason,
								long? ownerId,
								string comment = null,
								string searchQuery = null,
								CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Report(videoId, reason, ownerId, comment, searchQuery));

	/// <inheritdoc />
	public Task<bool> ReportCommentAsync(long commentId,
										long ownerId,
										ReportReason reason,
										CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			ReportComment(commentId, ownerId, reason));

	/// <inheritdoc />
	public Task<VideoAlbum> GetAlbumByIdAsync(long albumId,
											long? ownerId = null,
											CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetAlbumById(albumId, ownerId));

	/// <inheritdoc />
	public Task<bool> ReorderAlbumsAsync(long albumId,
										long? ownerId,
										long? before,
										long? after,
										CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			ReorderAlbums(albumId, ownerId, before, after));

	/// <inheritdoc />
	public Task<bool> ReorderVideosAsync(VideoReorderVideosParams @params,
										CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			ReorderVideos(@params));

	/// <inheritdoc />
	public Task<VkCollection<ulong>> AddToAlbumAsync(long ownerId,
													long videoId,
													IEnumerable<string> albumIds,
													long? targetId = null,
													long? albumId = null,
													CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			AddToAlbum(ownerId, videoId, albumIds, targetId, albumId));

	/// <inheritdoc />
	public Task<bool> RemoveFromAlbumAsync(long ownerId,
											long videoId,
											IEnumerable<string> albumIds,
											long? targetId = null,
											long? albumId = null,
											CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			RemoveFromAlbum(ownerId, videoId, albumIds, targetId, albumId));

	/// <inheritdoc />
	public Task<VkCollection<VideoAlbum>> GetAlbumsByVideoAsync(long? targetId,
																long ownerId,
																long videoId,
																bool? extended,
																CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetAlbumsByVideo(targetId, ownerId, videoId, extended));

	/// <inheritdoc />
	public Task<ReadOnlyCollection<VideoCatalog>> GetCatalogAsync(VideoGetCatalogParams @params,
																CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetCatalog(@params));

	/// <inheritdoc />
	public Task<ReadOnlyCollection<VideoCatalogItem>> GetCatalogSectionAsync(string sectionId,
																			string from,
																			long? count = null,
																			bool? extended = null,
																			CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetCatalogSection(sectionId, from, count, extended));

	/// <inheritdoc />
	public Task<bool> HideCatalogSectionAsync(long sectionId,
											CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			HideCatalogSection(sectionId));
}