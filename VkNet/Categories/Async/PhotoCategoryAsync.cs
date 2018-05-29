using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using VkNet.Enums;
using VkNet.Model;
using VkNet.Model.Attachments;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkNet.Categories
{
	/// <inheritdoc />
	public partial class PhotoCategory
	{
		/// <inheritdoc />
		public async Task<PhotoAlbum> CreateAlbumAsync(PhotoCreateAlbumParams @params)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Photo.CreateAlbum(@params: @params));
		}

		/// <inheritdoc />
		public async Task<bool> EditAlbumAsync(PhotoEditAlbumParams @params)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Photo.EditAlbum(@params: @params));
		}

		/// <inheritdoc />
		public async Task<VkCollection<PhotoAlbum>> GetAlbumsAsync(PhotoGetAlbumsParams @params, bool skipAuthorization = false)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.Photo.GetAlbums(@params: @params, skipAuthorization: skipAuthorization));
		}

		/// <inheritdoc />
		public async Task<VkCollection<Photo>> GetAsync(PhotoGetParams @params, bool skipAuthorization = false)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Photo.Get(@params: @params, skipAuthorization: skipAuthorization));
		}

		/// <inheritdoc />
		public async Task<int> GetAlbumsCountAsync(long? userId = null, long? groupId = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Photo.GetAlbumsCount(userId: userId, groupId: groupId));
		}

		/// <inheritdoc />
		public async Task<ReadOnlyCollection<Photo>> GetByIdAsync(IEnumerable<string> photos
																, bool? extended = null
																, bool? photoSizes = null
																, bool skipAuthorization = false)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.Photo.GetById(photos: photos, extended: extended, photoSizes: photoSizes, skipAuthorization: skipAuthorization));
		}

		/// <inheritdoc />
		public async Task<UploadServerInfo> GetUploadServerAsync(long albumId, long? groupId = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Photo.GetUploadServer(albumId: albumId, groupId: groupId));
		}

		/// <inheritdoc />
		public async Task<UploadServerInfo> GetOwnerPhotoUploadServerAsync(long? ownerId = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Photo.GetOwnerPhotoUploadServer(ownerId: ownerId));
		}

		/// <inheritdoc />
		public async Task<UploadServerInfo> GetChatUploadServerAsync(ulong chatId
																	, ulong? cropX = null
																	, ulong? cropY = null
																	, ulong? cropWidth = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.Photo.GetChatUploadServer(chatId: chatId, cropX: cropX, cropY: cropY, cropWidth: cropWidth));
		}

		/// <inheritdoc />
		public async Task<Photo> SaveOwnerPhotoAsync(string response, long? captchaSid, string captchaKey)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.Photo.SaveOwnerPhoto(response: response, captchaSid: captchaSid, captchaKey: captchaKey));
		}

		/// <inheritdoc />
		public async Task<ReadOnlyCollection<Photo>> SaveWallPhotoAsync(string response
																		, ulong? userId
																		, ulong? groupId = null
																		, string caption = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.Photo.SaveWallPhoto(response: response, userId: userId, groupId: groupId, caption: caption));
		}

		/// <inheritdoc />
		public async Task<UploadServerInfo> GetWallUploadServerAsync(long? groupId = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Photo.GetWallUploadServer(groupId: groupId));
		}

		/// <inheritdoc />
		public async Task<UploadServerInfo> GetMessagesUploadServerAsync(long peerId)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Photo.GetMessagesUploadServer(peerId: peerId));
		}

		/// <inheritdoc />
		public async Task<ReadOnlyCollection<Photo>> SaveMessagesPhotoAsync(string response)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Photo.SaveMessagesPhoto(response: response));
		}

		/// <inheritdoc />
		public async Task<UploadServerInfo> GetOwnerCoverPhotoUploadServerAsync(long groupId
																				, long? cropX = null
																				, long? cropY = null
																				, long? cropX2 = null
																				, long? cropY2 = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.Photo.GetOwnerCoverPhotoUploadServer(groupId: groupId, cropX: cropX, cropY: cropY, cropX2: cropX2, cropY2: cropY2));
		}

		/// <inheritdoc />
		public async Task<GroupCover> SaveOwnerCoverPhotoAsync(string response)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Photo.SaveOwnerCoverPhoto(response: response));
		}

		/// <inheritdoc />
		public async Task<bool> ReportAsync(long ownerId, ulong photoId, ReportReason reason)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Photo.Report(ownerId: ownerId, photoId: photoId, reason: reason));
		}

		/// <inheritdoc />
		public async Task<bool> ReportCommentAsync(long ownerId, ulong commentId, ReportReason reason)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.Photo.ReportComment(ownerId: ownerId, commentId: commentId, reason: reason));
		}

		/// <inheritdoc />
		public async Task<VkCollection<Photo>> SearchAsync(PhotoSearchParams @params, bool skipAuthorization = false)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.Photo.Search(@params: @params, skipAuthorization: skipAuthorization));
		}

		/// <inheritdoc />
		public async Task<ReadOnlyCollection<Photo>> SaveAsync(PhotoSaveParams @params)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Photo.Save(@params: @params));
		}

		/// <inheritdoc />
		public async Task<long> CopyAsync(long ownerId, ulong photoId, string accessKey = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.Photo.Copy(ownerId: ownerId, photoId: photoId, accessKey: accessKey));
		}

		/// <inheritdoc />
		public async Task<bool> EditAsync(PhotoEditParams @params)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Photo.Edit(@params: @params));
		}

		/// <inheritdoc />
		public async Task<bool> MoveAsync(long targetAlbumId, ulong photoId, long? ownerId = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.Photo.Move(targetAlbumId: targetAlbumId, photoId: photoId, ownerId: ownerId));
		}

		/// <inheritdoc />
		public async Task<bool> MakeCoverAsync(ulong photoId, long? ownerId = null, long? albumId = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.Photo.MakeCover(photoId: photoId, ownerId: ownerId, albumId: albumId));
		}

		/// <inheritdoc />
		public async Task<bool> ReorderAlbumsAsync(long albumId, long? ownerId = null, long? before = null, long? after = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.Photo.ReorderAlbums(albumId: albumId, ownerId: ownerId, before: before, after: after));
		}

		/// <inheritdoc />
		public async Task<bool> ReorderPhotosAsync(ulong photoId, long? ownerId = null, long? before = null, long? after = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.Photo.ReorderPhotos(photoId: photoId, ownerId: ownerId, before: before, after: after));
		}

		/// <inheritdoc />
		public async Task<VkCollection<Photo>> GetAllAsync(PhotoGetAllParams @params)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Photo.GetAll(@params: @params));
		}

		/// <inheritdoc />
		public async Task<VkCollection<Photo>> GetUserPhotosAsync(PhotoGetUserPhotosParams @params)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Photo.GetUserPhotos(@params: @params));
		}

		/// <inheritdoc />
		public async Task<bool> DeleteAlbumAsync(long albumId, long? groupId = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Photo.DeleteAlbum(albumId: albumId, groupId: groupId));
		}

		/// <inheritdoc />
		public async Task<bool> DeleteAsync(ulong photoId, long? ownerId = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Photo.Delete(photoId: photoId, ownerId: ownerId));
		}

		/// <inheritdoc />
		public async Task<bool> RestoreAsync(ulong photoId, long? ownerId = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Photo.Restore(photoId: photoId, ownerId: ownerId));
		}

		/// <inheritdoc />
		public async Task<bool> ConfirmTagAsync(ulong photoId, ulong tagId, long? ownerId = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.Photo.ConfirmTag(photoId: photoId, tagId: tagId, ownerId: ownerId));
		}

		/// <inheritdoc />
		public async Task<VkCollection<Comment>> GetCommentsAsync(PhotoGetCommentsParams @params)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Photo.GetComments(@params: @params));
		}

		/// <inheritdoc />
		public async Task<VkCollection<Comment>> GetAllCommentsAsync(PhotoGetAllCommentsParams @params)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Photo.GetAllComments(@params: @params));
		}

		/// <inheritdoc />
		public async Task<long> CreateCommentAsync(PhotoCreateCommentParams @params)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Photo.CreateComment(@params: @params));
		}

		/// <inheritdoc />
		public async Task<bool> DeleteCommentAsync(ulong commentId, long? ownerId = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Photo.DeleteComment(commentId: commentId, ownerId: ownerId));
		}

		/// <inheritdoc />
		public async Task<long> RestoreCommentAsync(ulong commentId, long? ownerId = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Photo.RestoreComment(commentId: commentId, ownerId: ownerId));
		}

		/// <inheritdoc />
		public async Task<bool> EditCommentAsync(ulong commentId
												, string message
												, long? ownerId = null
												, IEnumerable<MediaAttachment> attachments = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.Photo.EditComment(commentId: commentId, message: message, ownerId: ownerId, attachments: attachments));
		}

		/// <inheritdoc />
		public async Task<ReadOnlyCollection<Tag>> GetTagsAsync(ulong photoId, long? ownerId = null, string accessKey = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.Photo.GetTags(photoId: photoId, ownerId: ownerId, accessKey: accessKey));
		}

		/// <inheritdoc />
		public async Task<ulong> PutTagAsync(PhotoPutTagParams @params)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Photo.PutTag(@params: @params));
		}

		/// <inheritdoc />
		public async Task<bool> RemoveTagAsync(ulong tagId, ulong photoId, long? ownerId = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Photo.RemoveTag(tagId: tagId, photoId: photoId, ownerId: ownerId));
		}

		/// <inheritdoc />
		public async Task<VkCollection<Photo>> GetNewTagsAsync(uint? offset = null, uint? count = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Photo.GetNewTags(offset: offset, count: count));
		}

		/// <inheritdoc />
		public async Task<UploadServerInfo> GetMarketUploadServerAsync(long groupId
																		, bool? mainPhoto = null
																		, long? cropX = null
																		, long? cropY = null
																		, long? cropWidth = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.Photo.GetMarketUploadServer(groupId: groupId
							, mainPhoto: mainPhoto
							, cropX: cropX
							, cropY: cropY
							, cropWidth: cropWidth));
		}

		/// <inheritdoc />
		public async Task<UploadServerInfo> GetMarketAlbumUploadServerAsync(long groupId)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Photo.GetMarketAlbumUploadServer(groupId: groupId));
		}

		/// <inheritdoc />
		public async Task<ReadOnlyCollection<Photo>> SaveMarketPhotoAsync(long groupId, string response)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Photo.SaveMarketPhoto(groupId: groupId, response: response));
		}

		/// <inheritdoc />
		public async Task<ReadOnlyCollection<Photo>> SaveMarketAlbumPhotoAsync(long groupId, string response)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Photo.SaveMarketAlbumPhoto(groupId: groupId, response: response));
		}
	}
}