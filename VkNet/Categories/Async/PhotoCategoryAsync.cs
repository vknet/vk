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
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Photo.CreateAlbum(@params));
        }

        /// <inheritdoc />
        public async Task<bool> EditAlbumAsync(PhotoEditAlbumParams @params)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Photo.EditAlbum(@params));
        }

        /// <inheritdoc />
        public async Task<VkCollection<PhotoAlbum>> GetAlbumsAsync(PhotoGetAlbumsParams @params,
            bool skipAuthorization = false)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Photo.GetAlbums(@params, skipAuthorization));
        }

        /// <inheritdoc />
        public async Task<VkCollection<Photo>> GetAsync(PhotoGetParams @params, bool skipAuthorization = false)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Photo.Get(@params, skipAuthorization));
        }

        /// <inheritdoc />
        public async Task<int> GetAlbumsCountAsync(long? userId = null, long? groupId = null)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Photo.GetAlbumsCount(userId, groupId));
        }

        /// <inheritdoc />
        public async Task<ReadOnlyCollection<Photo>> GetByIdAsync(IEnumerable<string> photos, bool? extended = null,
            bool? photoSizes = null, bool skipAuthorization = false)
        {
            return await TypeHelper.TryInvokeMethodAsync(() =>
                _vk.Photo.GetById(photos, extended, photoSizes, skipAuthorization));
        }

        /// <inheritdoc />
        public async Task<UploadServerInfo> GetUploadServerAsync(long albumId, long? groupId = null)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Photo.GetUploadServer(albumId, groupId));
        }

        /// <inheritdoc />
        public async Task<UploadServerInfo> GetOwnerPhotoUploadServerAsync(long? ownerId = null)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Photo.GetOwnerPhotoUploadServer(ownerId));
        }

        /// <inheritdoc />
        public async Task<UploadServerInfo> GetChatUploadServerAsync(ulong chatId, ulong? cropX = null,
            ulong? cropY = null, ulong? cropWidth = null)
        {
            return await TypeHelper.TryInvokeMethodAsync(() =>
                _vk.Photo.GetChatUploadServer(chatId, cropX, cropY, cropWidth));
        }

        /// <inheritdoc />
        public async Task<Photo> SaveOwnerPhotoAsync(string response, long? captchaSid, string captchaKey)
        {
            return await TypeHelper.TryInvokeMethodAsync(() =>
                _vk.Photo.SaveOwnerPhoto(response, captchaSid, captchaKey));
        }

        /// <inheritdoc />
        public async Task<ReadOnlyCollection<Photo>> SaveWallPhotoAsync(string response, ulong? userId,
            ulong? groupId = null, string caption = null)
        {
            return await TypeHelper.TryInvokeMethodAsync(() =>
                _vk.Photo.SaveWallPhoto(response, userId, groupId, caption));
        }

        /// <inheritdoc />
        public async Task<UploadServerInfo> GetWallUploadServerAsync(long? groupId = null)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Photo.GetWallUploadServer(groupId));
        }

        /// <inheritdoc />
        public async Task<UploadServerInfo> GetMessagesUploadServerAsync(long peerId)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Photo.GetMessagesUploadServer(peerId));
        }

        /// <inheritdoc />
        public async Task<ReadOnlyCollection<Photo>> SaveMessagesPhotoAsync(string response)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Photo.SaveMessagesPhoto(response));
        }
        /// <inheritdoc />
        public async Task<UploadServerInfo> GetOwnerCoverPhotoUploadServerAsync(long groupId, long? cropX = null,
            long? cropY = null, long? cropX2 = null,
            long? cropY2 = null)
        {
            return await TypeHelper.TryInvokeMethodAsync(() =>
                _vk.Photo.GetOwnerCoverPhotoUploadServer(groupId, cropX, cropY, cropX2, cropY2));
        }

        /// <inheritdoc />
        public async Task<GroupCover> SaveOwnerCoverPhotoAsync(string response)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Photo.SaveOwnerCoverPhoto(response));
        }

        /// <inheritdoc />
        public async Task<bool> ReportAsync(long ownerId, ulong photoId, ReportReason reason)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Photo.Report(ownerId, photoId, reason));
        }

        /// <inheritdoc />
        public async Task<bool> ReportCommentAsync(long ownerId, ulong commentId, ReportReason reason)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Photo.ReportComment(ownerId, commentId, reason));
        }

        /// <inheritdoc />
        public async Task<VkCollection<Photo>> SearchAsync(PhotoSearchParams @params, bool skipAuthorization = false)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Photo.Search(@params, skipAuthorization));
        }

        /// <inheritdoc />
        public async Task<ReadOnlyCollection<Photo>> SaveAsync(PhotoSaveParams @params)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Photo.Save(@params));
        }

        /// <inheritdoc />
        public async Task<long> CopyAsync(long ownerId, ulong photoId, string accessKey = null)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Photo.Copy(ownerId, photoId, accessKey));
        }

        /// <inheritdoc />
        public async Task<bool> EditAsync(PhotoEditParams @params)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Photo.Edit(@params));
        }

        /// <inheritdoc />
        public async Task<bool> MoveAsync(long targetAlbumId, ulong photoId, long? ownerId = null)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Photo.Move(targetAlbumId, photoId, ownerId));
        }

        /// <inheritdoc />
        public async Task<bool> MakeCoverAsync(ulong photoId, long? ownerId = null, long? albumId = null)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Photo.MakeCover(photoId, ownerId, albumId));
        }

        /// <inheritdoc />
        public async Task<bool> ReorderAlbumsAsync(long albumId, long? ownerId = null, long? before = null,
            long? after = null)
        {
            return await TypeHelper.TryInvokeMethodAsync(() =>
                _vk.Photo.ReorderAlbums(albumId, ownerId, before, after));
        }

        /// <inheritdoc />
        public async Task<bool> ReorderPhotosAsync(ulong photoId, long? ownerId = null, long? before = null,
            long? after = null)
        {
            return await TypeHelper.TryInvokeMethodAsync(() =>
                _vk.Photo.ReorderPhotos(photoId, ownerId, before, after));
        }

        /// <inheritdoc />
        public async Task<VkCollection<Photo>> GetAllAsync(PhotoGetAllParams @params)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Photo.GetAll(@params));
        }

        /// <inheritdoc />
        public async Task<VkCollection<Photo>> GetUserPhotosAsync(PhotoGetUserPhotosParams @params)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Photo.GetUserPhotos(@params));
        }

        /// <inheritdoc />
        public async Task<bool> DeleteAlbumAsync(long albumId, long? groupId = null)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Photo.DeleteAlbum(albumId, groupId));
        }

        /// <inheritdoc />
        public async Task<bool> DeleteAsync(ulong photoId, long? ownerId = null)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Photo.Delete(photoId, ownerId));
        }

        /// <inheritdoc />
        public async Task<bool> RestoreAsync(ulong photoId, long? ownerId = null)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Photo.Restore(photoId, ownerId));
        }

        /// <inheritdoc />
        public async Task<bool> ConfirmTagAsync(ulong photoId, ulong tagId, long? ownerId = null)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Photo.ConfirmTag(photoId, tagId, ownerId));
        }

        /// <inheritdoc />
        public async Task<VkCollection<Comment>> GetCommentsAsync(PhotoGetCommentsParams @params)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Photo.GetComments(@params));
        }

        /// <inheritdoc />
        public async Task<VkCollection<Comment>> GetAllCommentsAsync(PhotoGetAllCommentsParams @params)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Photo.GetAllComments(@params));
        }

        /// <inheritdoc />
        public async Task<long> CreateCommentAsync(PhotoCreateCommentParams @params)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Photo.CreateComment(@params));
        }

        /// <inheritdoc />
        public async Task<bool> DeleteCommentAsync(ulong commentId, long? ownerId = null)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Photo.DeleteComment(commentId, ownerId));
        }

        /// <inheritdoc />
        public async Task<long> RestoreCommentAsync(ulong commentId, long? ownerId = null)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Photo.RestoreComment(commentId, ownerId));
        }

        /// <inheritdoc />
        public async Task<bool> EditCommentAsync(ulong commentId, string message, long? ownerId = null,
            IEnumerable<MediaAttachment> attachments = null)
        {
            return await TypeHelper.TryInvokeMethodAsync(() =>
                _vk.Photo.EditComment(commentId, message, ownerId, attachments));
        }

        /// <inheritdoc />
        public async Task<ReadOnlyCollection<Tag>> GetTagsAsync(ulong photoId, long? ownerId = null,
            string accessKey = null)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Photo.GetTags(photoId, ownerId, accessKey));
        }

        /// <inheritdoc />
        public async Task<ulong> PutTagAsync(PhotoPutTagParams @params)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Photo.PutTag(@params));
        }

        /// <inheritdoc />
        public async Task<bool> RemoveTagAsync(ulong tagId, ulong photoId, long? ownerId = null)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Photo.RemoveTag(tagId, photoId, ownerId));
        }

        /// <inheritdoc />
        public async Task<VkCollection<Photo>> GetNewTagsAsync(uint? offset = null, uint? count = null)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Photo.GetNewTags(offset, count));
        }
        /// <inheritdoc />
        public async Task<UploadServerInfo> GetMarketUploadServerAsync(long groupId, bool? mainPhoto = null,
            long? cropX = null, long? cropY = null,
            long? cropWidth = null)
        {
            return await TypeHelper.TryInvokeMethodAsync(() =>
                _vk.Photo.GetMarketUploadServer(groupId, mainPhoto, cropX, cropY, cropWidth));
        }

        /// <inheritdoc />
        public async Task<UploadServerInfo> GetMarketAlbumUploadServerAsync(long groupId)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Photo.GetMarketAlbumUploadServer(groupId));
        }

        /// <inheritdoc />
        public async Task<ReadOnlyCollection<Photo>> SaveMarketPhotoAsync(long groupId, string response)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Photo.SaveMarketPhoto(groupId, response));
        }

        /// <inheritdoc />
        public async Task<ReadOnlyCollection<Photo>> SaveMarketAlbumPhotoAsync(long groupId, string response)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Photo.SaveMarketAlbumPhoto(groupId, response));
        }
    }
}