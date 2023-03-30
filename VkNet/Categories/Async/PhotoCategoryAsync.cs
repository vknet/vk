using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using VkNet.Enums;
using VkNet.Model;
using VkNet.Model.Attachments;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkNet.Categories;

/// <inheritdoc />
public partial class PhotoCategory
{
	/// <inheritdoc />
	public Task<PhotoAlbum> CreateAlbumAsync(PhotoCreateAlbumParams @params,
											CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			CreateAlbum(@params));

	/// <inheritdoc />
	public Task<bool> EditAlbumAsync(PhotoEditAlbumParams @params,
									CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			EditAlbum(@params));

	/// <inheritdoc />
	public Task<VkCollection<PhotoAlbum>> GetAlbumsAsync(PhotoGetAlbumsParams @params,
														bool skipAuthorization = false,
														CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetAlbums(@params, skipAuthorization));

	/// <inheritdoc />
	public Task<VkCollection<Photo>> GetAsync(PhotoGetParams @params,
											bool skipAuthorization = false,
											CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Get(@params, skipAuthorization));

	/// <inheritdoc />
	public Task<int> GetAlbumsCountAsync(long? userId = null,
										long? groupId = null,
										CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetAlbumsCount(userId, groupId));

	/// <inheritdoc />
	public Task<ReadOnlyCollection<Photo>> GetByIdAsync(IEnumerable<string> photos,
														bool? extended = null,
														bool? photoSizes = null,
														bool skipAuthorization = false,
														CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetById(photos, extended, photoSizes, skipAuthorization));

	/// <inheritdoc />
	public Task<UploadServerInfo> GetUploadServerAsync(long albumId,
														long? groupId = null,
														CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetUploadServer(albumId, groupId));

	/// <inheritdoc />
	public Task<UploadServerInfo> GetOwnerPhotoUploadServerAsync(long? ownerId = null,
																CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetOwnerPhotoUploadServer(ownerId: ownerId));

	/// <inheritdoc />
	public Task<UploadServerInfo> GetChatUploadServerAsync(ulong chatId,
															ulong? cropX = null,
															ulong? cropY = null,
															ulong? cropWidth = null,
															CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetChatUploadServer(chatId, cropX, cropY, cropWidth));

	/// <inheritdoc />
	public Task<Photo> SaveOwnerPhotoAsync(string response,
											CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			SaveOwnerPhoto(response));

	/// <inheritdoc />
	[Obsolete(ObsoleteText.CaptchaNeeded, true)]
	public Task<Photo> SaveOwnerPhotoAsync(string response,
											long? captchaSid,
											string captchaKey,
											CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			SaveOwnerPhoto(response, captchaSid, captchaKey));

	/// <inheritdoc />
	public Task<ReadOnlyCollection<Photo>> SaveWallPhotoAsync(string response,
															ulong? userId,
															ulong? groupId = null,
															string caption = null,
															CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			SaveWallPhoto(response, userId, groupId, caption));

	/// <inheritdoc />
	public Task<UploadServerInfo> GetWallUploadServerAsync(long? groupId = null,
															CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetWallUploadServer(groupId));

	/// <inheritdoc />
	public Task<UploadServerInfo> GetMessagesUploadServerAsync(long? groupId,
																CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetMessagesUploadServer(groupId));

	/// <inheritdoc />
	public Task<ReadOnlyCollection<Photo>> SaveMessagesPhotoAsync(string response,
																CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() => SaveMessagesPhoto(response));

	/// <inheritdoc />
	public Task<UploadServerInfo> GetOwnerCoverPhotoUploadServerAsync(long groupId,
																	long? cropX = null,
																	long? cropY = null,
																	long? cropX2 = 795L,
																	long? cropY2 = 200L,
																	CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetOwnerCoverPhotoUploadServer(groupId, cropX, cropY, cropX2, cropY2));

	/// <inheritdoc />
	public Task<GroupCover> SaveOwnerCoverPhotoAsync(string response,
													CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			SaveOwnerCoverPhoto(response));

	/// <inheritdoc />
	public Task<bool> ReportAsync(long ownerId,
								ulong photoId,
								ReportReason reason,
								CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Report(ownerId, photoId, reason));

	/// <inheritdoc />
	public Task<bool> ReportCommentAsync(long ownerId,
										ulong commentId,
										ReportReason reason,
										CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			ReportComment(ownerId, commentId, reason));

	/// <inheritdoc />
	public Task<VkCollection<Photo>> SearchAsync(PhotoSearchParams @params,
												bool skipAuthorization = false,
												CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Search(@params, skipAuthorization));

	/// <inheritdoc />
	public Task<ReadOnlyCollection<Photo>> SaveAsync(PhotoSaveParams @params,
													CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Save(@params));

	/// <inheritdoc />
	public Task<long> CopyAsync(long ownerId,
								ulong photoId,
								string accessKey = null,
								CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Copy(ownerId, photoId, accessKey));

	/// <inheritdoc />
	public Task<bool> EditAsync(PhotoEditParams @params,
								CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Edit(@params));

	/// <inheritdoc />
	public Task<bool> MoveAsync(long targetAlbumId,
								ulong photoId,
								long? ownerId = null,
								CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Move(targetAlbumId, photoId, ownerId));

	/// <inheritdoc />
	public Task<bool> MakeCoverAsync(ulong photoId,
									long? ownerId = null,
									long? albumId = null,
									CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			MakeCover(photoId, ownerId, albumId));

	/// <inheritdoc />
	public Task<bool> ReorderAlbumsAsync(long albumId,
										long? ownerId = null,
										long? before = null,
										long? after = null,
										CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			ReorderAlbums(albumId, ownerId, before, after));

	/// <inheritdoc />
	public Task<bool> ReorderPhotosAsync(ulong photoId,
										long? ownerId = null,
										long? before = null,
										long? after = null,
										CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			ReorderPhotos(photoId, ownerId, before, after));

	/// <inheritdoc />
	public Task<VkCollection<Photo>> GetAllAsync(PhotoGetAllParams @params,
												CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetAll(@params));

	/// <inheritdoc />
	public Task<VkCollection<Photo>> GetUserPhotosAsync(PhotoGetUserPhotosParams @params,
														CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetUserPhotos(@params));

	/// <inheritdoc />
	public Task<bool> DeleteAlbumAsync(long albumId,
										long? groupId = null,
										CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			DeleteAlbum(albumId, groupId));

	/// <inheritdoc />
	public Task<bool> DeleteAsync(ulong photoId,
								long? ownerId = null,
								CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Delete(photoId, ownerId));

	/// <inheritdoc />
	public Task<bool> RestoreAsync(ulong photoId,
									long? ownerId = null,
									CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Restore(photoId, ownerId));

	/// <inheritdoc />
	public Task<bool> ConfirmTagAsync(ulong photoId,
									ulong tagId,
									long? ownerId = null,
									CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			ConfirmTag(photoId, tagId, ownerId));

	/// <inheritdoc />
	public Task<VkCollection<Comment>> GetCommentsAsync(PhotoGetCommentsParams @params,
														CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetComments(@params));

	/// <inheritdoc />
	public Task<VkCollection<Comment>> GetAllCommentsAsync(PhotoGetAllCommentsParams @params,
															CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetAllComments(@params));

	/// <inheritdoc />
	public Task<long> CreateCommentAsync(PhotoCreateCommentParams @params,
										CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			CreateComment(@params));

	/// <inheritdoc />
	public Task<bool> DeleteCommentAsync(ulong commentId,
										long? ownerId = null,
										CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			DeleteComment(commentId, ownerId));

	/// <inheritdoc />
	public Task<long> RestoreCommentAsync(ulong commentId,
										long? ownerId = null,
										CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			RestoreComment(commentId, ownerId));

	/// <inheritdoc />
	public Task<bool> EditCommentAsync(ulong commentId,
										string message,
										long? ownerId = null,
										IEnumerable<MediaAttachment> attachments = null,
										CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			EditComment(commentId, message, ownerId, attachments));

	/// <inheritdoc />
	public Task<ReadOnlyCollection<Tag>> GetTagsAsync(ulong photoId,
													long? ownerId = null,
													string accessKey = null,
													CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetTags(photoId, ownerId, accessKey));

	/// <inheritdoc />
	public Task<ulong> PutTagAsync(PhotoPutTagParams @params,
									CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			PutTag(@params));

	/// <inheritdoc />
	public Task<bool> RemoveTagAsync(ulong tagId,
									ulong photoId,
									long? ownerId = null,
									CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			RemoveTag(tagId, photoId, ownerId));

	/// <inheritdoc />
	public Task<VkCollection<Photo>> GetNewTagsAsync(uint? offset = null,
													uint? count = null,
													CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetNewTags(offset, count));

	/// <inheritdoc />
	public Task<UploadServerInfo> GetMarketUploadServerAsync(long groupId,
															bool? mainPhoto = null,
															long? cropX = null,
															long? cropY = null,
															long? cropWidth = null,
															CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetMarketUploadServer(groupId, mainPhoto, cropX, cropY, cropWidth));

	/// <inheritdoc />
	public Task<UploadServerInfo> GetMarketAlbumUploadServerAsync(long groupId,
																CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetMarketAlbumUploadServer(groupId: groupId));

	/// <inheritdoc />
	public Task<ReadOnlyCollection<Photo>> SaveMarketPhotoAsync(long groupId,
																string response,
																CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			SaveMarketPhoto(groupId, response));

	/// <inheritdoc />
	public Task<ReadOnlyCollection<Photo>> SaveMarketAlbumPhotoAsync(long groupId,
																	string response,
																	CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			SaveMarketAlbumPhoto(groupId, response));
}