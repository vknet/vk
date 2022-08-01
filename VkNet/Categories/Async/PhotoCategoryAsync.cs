using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
	public Task<PhotoAlbum> CreateAlbumAsync(PhotoCreateAlbumParams @params) =>
		TypeHelper.TryInvokeMethodAsync(func: () => CreateAlbum(@params: @params));

	/// <inheritdoc />
	public Task<bool> EditAlbumAsync(PhotoEditAlbumParams @params) =>
		TypeHelper.TryInvokeMethodAsync(func: () => EditAlbum(@params: @params));

	/// <inheritdoc />
	public Task<VkCollection<PhotoAlbum>> GetAlbumsAsync(PhotoGetAlbumsParams @params, bool skipAuthorization = false) =>
		TypeHelper.TryInvokeMethodAsync(func: () =>
			GetAlbums(@params, skipAuthorization));

	/// <inheritdoc />
	public Task<VkCollection<Photo>> GetAsync(PhotoGetParams @params, bool skipAuthorization = false) =>
		TypeHelper.TryInvokeMethodAsync(func: () => Get(@params, skipAuthorization));

	/// <inheritdoc />
	public Task<int> GetAlbumsCountAsync(long? userId = null, long? groupId = null) =>
		TypeHelper.TryInvokeMethodAsync(func: () => GetAlbumsCount(userId, groupId));

	/// <inheritdoc />
	public Task<ReadOnlyCollection<Photo>> GetByIdAsync(IEnumerable<string> photos
														, bool? extended = null
														, bool? photoSizes = null
														, bool skipAuthorization = false) => TypeHelper.TryInvokeMethodAsync(func: () =>
		GetById(photos, extended, photoSizes, skipAuthorization));

	/// <inheritdoc />
	public Task<UploadServerInfo> GetUploadServerAsync(long albumId, long? groupId = null) =>
		TypeHelper.TryInvokeMethodAsync(func: () => GetUploadServer(albumId, groupId));

	/// <inheritdoc />
	public Task<UploadServerInfo> GetOwnerPhotoUploadServerAsync(long? ownerId = null) =>
		TypeHelper.TryInvokeMethodAsync(func: () => GetOwnerPhotoUploadServer(ownerId: ownerId));

	/// <inheritdoc />
	public Task<UploadServerInfo> GetChatUploadServerAsync(ulong chatId
															, ulong? cropX = null
															, ulong? cropY = null
															, ulong? cropWidth = null) => TypeHelper.TryInvokeMethodAsync(func: () =>
		GetChatUploadServer(chatId, cropX, cropY, cropWidth));

	/// <inheritdoc />
	public Task<Photo> SaveOwnerPhotoAsync(string response) => TypeHelper.TryInvokeMethodAsync(func: () =>
		SaveOwnerPhoto(response));

	/// <inheritdoc />
	[Obsolete(ObsoleteText.CaptchaNeeded, true)]
	public Task<Photo> SaveOwnerPhotoAsync(string response, long? captchaSid, string captchaKey) => TypeHelper.TryInvokeMethodAsync(
		func: () =>
			SaveOwnerPhoto(response, captchaSid, captchaKey));

	/// <inheritdoc />
	public Task<ReadOnlyCollection<Photo>> SaveWallPhotoAsync(string response
															, ulong? userId
															, ulong? groupId = null
															, string caption = null) => TypeHelper.TryInvokeMethodAsync(func: () =>
		SaveWallPhoto(response, userId, groupId, caption));

	/// <inheritdoc />
	public Task<UploadServerInfo> GetWallUploadServerAsync(long? groupId = null) =>
		TypeHelper.TryInvokeMethodAsync(func: () => GetWallUploadServer(groupId: groupId));

	/// <inheritdoc />
	public Task<UploadServerInfo> GetMessagesUploadServerAsync(long? groupId) =>
		TypeHelper.TryInvokeMethodAsync(func: () => GetMessagesUploadServer(groupId: groupId));

	/// <inheritdoc />
	public Task<ReadOnlyCollection<Photo>> SaveMessagesPhotoAsync(string response) =>
		TypeHelper.TryInvokeMethodAsync(func: () => SaveMessagesPhoto(response: response));

	/// <inheritdoc />
	public Task<UploadServerInfo> GetOwnerCoverPhotoUploadServerAsync(long groupId
																	, long? cropX = null
																	, long? cropY = null
																	, long? cropX2 = 795L
																	, long? cropY2 = 200L) => TypeHelper.TryInvokeMethodAsync(func: () =>
		GetOwnerCoverPhotoUploadServer(groupId, cropX, cropY, cropX2, cropY2));

	/// <inheritdoc />
	public Task<GroupCover> SaveOwnerCoverPhotoAsync(string response) =>
		TypeHelper.TryInvokeMethodAsync(func: () => SaveOwnerCoverPhoto(response: response));

	/// <inheritdoc />
	public Task<bool> ReportAsync(long ownerId, ulong photoId, ReportReason reason) =>
		TypeHelper.TryInvokeMethodAsync(func: () => Report(ownerId, photoId, reason));

	/// <inheritdoc />
	public Task<bool> ReportCommentAsync(long ownerId, ulong commentId, ReportReason reason) => TypeHelper.TryInvokeMethodAsync(func: () =>
		ReportComment(ownerId, commentId, reason));

	/// <inheritdoc />
	public Task<VkCollection<Photo>> SearchAsync(PhotoSearchParams @params, bool skipAuthorization = false) =>
		TypeHelper.TryInvokeMethodAsync(func: () =>
			Search(@params, skipAuthorization));

	/// <inheritdoc />
	public Task<ReadOnlyCollection<Photo>> SaveAsync(PhotoSaveParams @params) =>
		TypeHelper.TryInvokeMethodAsync(func: () => Save(@params: @params));

	/// <inheritdoc />
	public Task<long> CopyAsync(long ownerId, ulong photoId, string accessKey = null) => TypeHelper.TryInvokeMethodAsync(func: () =>
		Copy(ownerId, photoId, accessKey));

	/// <inheritdoc />
	public Task<bool> EditAsync(PhotoEditParams @params) => TypeHelper.TryInvokeMethodAsync(func: () => Edit(@params: @params));

	/// <inheritdoc />
	public Task<bool> MoveAsync(long targetAlbumId, ulong photoId, long? ownerId = null) => TypeHelper.TryInvokeMethodAsync(func: () =>
		Move(targetAlbumId, photoId, ownerId));

	/// <inheritdoc />
	public Task<bool> MakeCoverAsync(ulong photoId, long? ownerId = null, long? albumId = null) => TypeHelper.TryInvokeMethodAsync(
		func: () =>
			MakeCover(photoId, ownerId, albumId));

	/// <inheritdoc />
	public Task<bool> ReorderAlbumsAsync(long albumId, long? ownerId = null, long? before = null, long? after = null) =>
		TypeHelper.TryInvokeMethodAsync(func: () =>
			ReorderAlbums(albumId, ownerId, before, after));

	/// <inheritdoc />
	public Task<bool> ReorderPhotosAsync(ulong photoId, long? ownerId = null, long? before = null, long? after = null) =>
		TypeHelper.TryInvokeMethodAsync(func: () =>
			ReorderPhotos(photoId, ownerId, before, after));

	/// <inheritdoc />
	public Task<VkCollection<Photo>> GetAllAsync(PhotoGetAllParams @params) =>
		TypeHelper.TryInvokeMethodAsync(func: () => GetAll(@params: @params));

	/// <inheritdoc />
	public Task<VkCollection<Photo>> GetUserPhotosAsync(PhotoGetUserPhotosParams @params) =>
		TypeHelper.TryInvokeMethodAsync(func: () => GetUserPhotos(@params: @params));

	/// <inheritdoc />
	public Task<bool> DeleteAlbumAsync(long albumId, long? groupId = null) =>
		TypeHelper.TryInvokeMethodAsync(func: () => DeleteAlbum(albumId, groupId));

	/// <inheritdoc />
	public Task<bool> DeleteAsync(ulong photoId, long? ownerId = null) =>
		TypeHelper.TryInvokeMethodAsync(func: () => Delete(photoId, ownerId));

	/// <inheritdoc />
	public Task<bool> RestoreAsync(ulong photoId, long? ownerId = null) =>
		TypeHelper.TryInvokeMethodAsync(func: () => Restore(photoId, ownerId));

	/// <inheritdoc />
	public Task<bool> ConfirmTagAsync(ulong photoId, ulong tagId, long? ownerId = null) => TypeHelper.TryInvokeMethodAsync(func: () =>
		ConfirmTag(photoId, tagId, ownerId));

	/// <inheritdoc />
	public Task<VkCollection<Comment>> GetCommentsAsync(PhotoGetCommentsParams @params) =>
		TypeHelper.TryInvokeMethodAsync(func: () => GetComments(@params: @params));

	/// <inheritdoc />
	public Task<VkCollection<Comment>> GetAllCommentsAsync(PhotoGetAllCommentsParams @params) =>
		TypeHelper.TryInvokeMethodAsync(func: () => GetAllComments(@params: @params));

	/// <inheritdoc />
	public Task<long> CreateCommentAsync(PhotoCreateCommentParams @params) =>
		TypeHelper.TryInvokeMethodAsync(func: () => CreateComment(@params: @params));

	/// <inheritdoc />
	public Task<bool> DeleteCommentAsync(ulong commentId, long? ownerId = null) =>
		TypeHelper.TryInvokeMethodAsync(func: () => DeleteComment(commentId, ownerId));

	/// <inheritdoc />
	public Task<long> RestoreCommentAsync(ulong commentId, long? ownerId = null) =>
		TypeHelper.TryInvokeMethodAsync(func: () => RestoreComment(commentId, ownerId));

	/// <inheritdoc />
	public Task<bool> EditCommentAsync(ulong commentId
										, string message
										, long? ownerId = null
										, IEnumerable<MediaAttachment> attachments = null) => TypeHelper.TryInvokeMethodAsync(func: () =>
		EditComment(commentId, message, ownerId, attachments));

	/// <inheritdoc />
	public Task<ReadOnlyCollection<Tag>> GetTagsAsync(ulong photoId, long? ownerId = null, string accessKey = null) =>
		TypeHelper.TryInvokeMethodAsync(func: () =>
			GetTags(photoId, ownerId, accessKey));

	/// <inheritdoc />
	public Task<ulong> PutTagAsync(PhotoPutTagParams @params) => TypeHelper.TryInvokeMethodAsync(func: () => PutTag(@params: @params));

	/// <inheritdoc />
	public Task<bool> RemoveTagAsync(ulong tagId, ulong photoId, long? ownerId = null) =>
		TypeHelper.TryInvokeMethodAsync(func: () => RemoveTag(tagId, photoId, ownerId));

	/// <inheritdoc />
	public Task<VkCollection<Photo>> GetNewTagsAsync(uint? offset = null, uint? count = null) =>
		TypeHelper.TryInvokeMethodAsync(func: () => GetNewTags(offset, count));

	/// <inheritdoc />
	public Task<UploadServerInfo> GetMarketUploadServerAsync(long groupId
															, bool? mainPhoto = null
															, long? cropX = null
															, long? cropY = null
															, long? cropWidth = null) => TypeHelper.TryInvokeMethodAsync(func: () =>
		GetMarketUploadServer(groupId, mainPhoto, cropX, cropY, cropWidth));

	/// <inheritdoc />
	public Task<UploadServerInfo> GetMarketAlbumUploadServerAsync(long groupId) =>
		TypeHelper.TryInvokeMethodAsync(func: () => GetMarketAlbumUploadServer(groupId: groupId));

	/// <inheritdoc />
	public Task<ReadOnlyCollection<Photo>> SaveMarketPhotoAsync(long groupId, string response) =>
		TypeHelper.TryInvokeMethodAsync(func: () => SaveMarketPhoto(groupId, response));

	/// <inheritdoc />
	public Task<ReadOnlyCollection<Photo>> SaveMarketAlbumPhotoAsync(long groupId, string response) =>
		TypeHelper.TryInvokeMethodAsync(func: () => SaveMarketAlbumPhoto(groupId, response));
}