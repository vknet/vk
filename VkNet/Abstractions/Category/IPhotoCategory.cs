using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using VkNet.Enums;
using VkNet.Model;
using VkNet.Model.Attachments;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkNet.Abstractions
{
	/// <inheritdoc cref="IPhotoCategoryAsync"/>
	public interface IPhotoCategory : IPhotoCategoryAsync
	{
		/// <inheritdoc cref="IPhotoCategoryAsync.CreateAlbumAsync"/>
		PhotoAlbum CreateAlbum(PhotoCreateAlbumParams @params);

		/// <inheritdoc cref="IPhotoCategoryAsync.EditAlbumAsync"/>
		bool EditAlbum(PhotoEditAlbumParams @params);

		/// <inheritdoc cref="IPhotoCategoryAsync.GetAlbumsAsync"/>
		VkCollection<PhotoAlbum> GetAlbums(PhotoGetAlbumsParams @params, bool skipAuthorization = false);

		/// <inheritdoc cref="IPhotoCategoryAsync.GetAsync"/>
		VkCollection<Photo> Get(PhotoGetParams @params, bool skipAuthorization = false);

		/// <inheritdoc cref="IPhotoCategoryAsync.GetAlbumsCountAsync"/>
		int GetAlbumsCount(long? userId = null, long? groupId = null);

		/// <inheritdoc cref="IPhotoCategoryAsync.GetByIdAsync"/>
		ReadOnlyCollection<Photo> GetById(IEnumerable<string> photos
										, bool? extended = null
										, bool? photoSizes = null
										, bool skipAuthorization = false);

		/// <inheritdoc cref="IPhotoCategoryAsync.GetUploadServerAsync"/>
		UploadServerInfo GetUploadServer(long albumId, long? groupId = null);

		/// <inheritdoc cref="IPhotoCategoryAsync.GetOwnerPhotoUploadServerAsync"/>
		UploadServerInfo GetOwnerPhotoUploadServer(long? ownerId = null);

		/// <inheritdoc cref="IPhotoCategoryAsync.GetChatUploadServerAsync"/>
		UploadServerInfo GetChatUploadServer(ulong chatId, ulong? cropX = null, ulong? cropY = null, ulong? cropWidth = null);

		/// <inheritdoc cref="IPhotoCategoryAsync.SaveOwnerPhotoAsync(string)"/>
		Photo SaveOwnerPhoto(string response);

		/// <inheritdoc cref="IPhotoCategoryAsync.SaveOwnerPhotoAsync(string,long?,string)"/>
		[Obsolete(ObsoleteText.CaptchaNeeded, true)]
		Photo SaveOwnerPhoto(string response, long? captchaSid, string captchaKey);

		/// <inheritdoc cref="IPhotoCategoryAsync.SaveWallPhotoAsync"/>
		ReadOnlyCollection<Photo> SaveWallPhoto(string response, ulong? userId, ulong? groupId = null, string caption = null);

		/// <inheritdoc cref="IPhotoCategoryAsync.GetWallUploadServerAsync"/>
		UploadServerInfo GetWallUploadServer(long? groupId = null);

		/// <inheritdoc cref="IPhotoCategoryAsync.GetMessagesUploadServerAsync"/>
		UploadServerInfo GetMessagesUploadServer(long? groupId);

		/// <inheritdoc cref="IPhotoCategoryAsync.SaveMessagesPhotoAsync"/>
		ReadOnlyCollection<Photo> SaveMessagesPhoto(string response);

		/// <inheritdoc cref="IPhotoCategoryAsync.GetOwnerCoverPhotoUploadServerAsync"/>
		UploadServerInfo GetOwnerCoverPhotoUploadServer(long groupId
														, long? cropX = null
														, long? cropY = null
														, long? cropX2 = 795L
														, long? cropY2 = 200L);

		/// <inheritdoc cref="IPhotoCategoryAsync.SaveOwnerCoverPhotoAsync"/>
		GroupCover SaveOwnerCoverPhoto(string response);

		/// <inheritdoc cref="IPhotoCategoryAsync.ReportAsync"/>
		bool Report(long ownerId, ulong photoId, ReportReason reason);

		/// <inheritdoc cref="IPhotoCategoryAsync.ReportCommentAsync"/>
		bool ReportComment(long ownerId, ulong commentId, ReportReason reason);

		/// <inheritdoc cref="IPhotoCategoryAsync.SearchAsync"/>
		VkCollection<Photo> Search(PhotoSearchParams @params, bool skipAuthorization = false);

		/// <inheritdoc cref="IPhotoCategoryAsync.SaveAsync"/>
		ReadOnlyCollection<Photo> Save(PhotoSaveParams @params);

		/// <inheritdoc cref="IPhotoCategoryAsync.CopyAsync"/>
		long Copy(long ownerId, ulong photoId, string accessKey = null);

		/// <inheritdoc cref="IPhotoCategoryAsync.EditAsync"/>
		bool Edit(PhotoEditParams @params);

		/// <inheritdoc cref="IPhotoCategoryAsync.MoveAsync"/>
		bool Move(long targetAlbumId, ulong photoId, long? ownerId = null);

		/// <inheritdoc cref="IPhotoCategoryAsync.MakeCoverAsync"/>
		bool MakeCover(ulong photoId, long? ownerId = null, long? albumId = null);

		/// <inheritdoc cref="IPhotoCategoryAsync.ReorderAlbumsAsync"/>
		bool ReorderAlbums(long albumId, long? ownerId = null, long? before = null, long? after = null);

		/// <inheritdoc cref="IPhotoCategoryAsync.ReorderPhotosAsync"/>
		bool ReorderPhotos(ulong photoId, long? ownerId = null, long? before = null, long? after = null);

		/// <inheritdoc cref="IPhotoCategoryAsync.GetAllAsync"/>
		VkCollection<Photo> GetAll(PhotoGetAllParams @params);

		/// <inheritdoc cref="IPhotoCategoryAsync.GetUserPhotosAsync"/>
		VkCollection<Photo> GetUserPhotos(PhotoGetUserPhotosParams @params);

		/// <inheritdoc cref="IPhotoCategoryAsync.DeleteAlbumAsync"/>
		bool DeleteAlbum(long albumId, long? groupId = null);

		/// <inheritdoc cref="IPhotoCategoryAsync.DeleteAsync"/>
		bool Delete(ulong photoId, long? ownerId = null);

		/// <inheritdoc cref="IPhotoCategoryAsync.RestoreAsync"/>
		bool Restore(ulong photoId, long? ownerId = null);

		/// <inheritdoc cref="IPhotoCategoryAsync.CreateAlbumAsync"/>
		bool ConfirmTag(ulong photoId, ulong tagId, long? ownerId = null);

		/// <inheritdoc cref="IPhotoCategoryAsync.GetAllCommentsAsync"/>
		VkCollection<Comment> GetComments(PhotoGetCommentsParams @params);

		/// <inheritdoc cref="IPhotoCategoryAsync.GetAllCommentsAsync"/>
		VkCollection<Comment> GetAllComments(PhotoGetAllCommentsParams @params);

		/// <inheritdoc cref="IPhotoCategoryAsync.CreateCommentAsync"/>
		long CreateComment(PhotoCreateCommentParams @params);

		/// <inheritdoc cref="IPhotoCategoryAsync.DeleteCommentAsync"/>
		bool DeleteComment(ulong commentId, long? ownerId = null);

		/// <inheritdoc cref="IPhotoCategoryAsync.RestoreCommentAsync"/>
		long RestoreComment(ulong commentId, long? ownerId = null);

		/// <inheritdoc cref="IPhotoCategoryAsync.EditCommentAsync"/>
		bool EditComment(ulong commentId, string message, long? ownerId = null, IEnumerable<MediaAttachment> attachments = null);

		/// <inheritdoc cref="IPhotoCategoryAsync.GetTagsAsync"/>
		ReadOnlyCollection<Tag> GetTags(ulong photoId, long? ownerId = null, string accessKey = null);

		/// <inheritdoc cref="IPhotoCategoryAsync.PutTagAsync"/>
		ulong PutTag(PhotoPutTagParams @params);

		/// <inheritdoc cref="IPhotoCategoryAsync.RemoveTagAsync"/>
		bool RemoveTag(ulong tagId, ulong photoId, long? ownerId = null);

		/// <inheritdoc cref="IPhotoCategoryAsync.GetNewTagsAsync"/>
		VkCollection<Photo> GetNewTags(uint? offset = null, uint? count = null);

		/// <inheritdoc cref="IPhotoCategoryAsync.GetMarketUploadServerAsync"/>
		UploadServerInfo GetMarketUploadServer(long groupId
												, bool? mainPhoto = null
												, long? cropX = null
												, long? cropY = null
												, long? cropWidth = null);

		/// <inheritdoc cref="IPhotoCategoryAsync.GetMarketAlbumUploadServerAsync"/>
		UploadServerInfo GetMarketAlbumUploadServer(long groupId);

		/// <inheritdoc cref="IPhotoCategoryAsync.SaveMarketPhotoAsync"/>
		ReadOnlyCollection<Photo> SaveMarketPhoto(long groupId, string response);

		/// <inheritdoc cref="IPhotoCategoryAsync.SaveMarketAlbumPhotoAsync"/>
		ReadOnlyCollection<Photo> SaveMarketAlbumPhoto(long groupId, string response);
	}
}