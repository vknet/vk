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
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Video.Get(@params));
        }

        /// <inheritdoc />
        public async Task<bool> EditAsync(VideoEditParams @params)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Video.Edit(@params));
        }

        /// <inheritdoc />
        public async Task<long> AddAsync(long videoId, long ownerId, long? targetId = null)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Video.Add(videoId, ownerId, targetId));
        }

        /// <inheritdoc />
        public async Task<Video> SaveAsync(VideoSaveParams @params)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Video.Save(@params));
        }

        /// <inheritdoc />
        public async Task<bool> DeleteAsync(long videoId, long? ownerId = null, long? targetId = null)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Video.Delete(videoId, ownerId, targetId));
        }

        /// <inheritdoc />
        public async Task<bool> RestoreAsync(long videoId, long? ownerId = null)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Video.Restore(videoId, ownerId));
        }

        /// <inheritdoc />
        public async Task<VkCollection<Video>> SearchAsync(VideoSearchParams @params)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Video.Search(@params));
        }

        /// <inheritdoc />
        public async Task<VkCollection<VideoAlbum>> GetAlbumsAsync(long? ownerId = null, long? offset = null,
            long? count = null, bool? extended = null, bool? needSystem = null)
        {
            return await TypeHelper.TryInvokeMethodAsync(() =>
                _vk.Video.GetAlbums(ownerId, offset, count, extended, needSystem));
        }

        /// <inheritdoc />
        public async Task<long> AddAlbumAsync(string title, long? groupId = null, IEnumerable<Privacy> privacy = null)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Video.AddAlbum(title, groupId, privacy));
        }

        /// <inheritdoc />
        public async Task<bool> EditAlbumAsync(long albumId, string title, long? groupId = null, Privacy privacy = null)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Video.EditAlbum(albumId, title, groupId, privacy));
        }

        /// <inheritdoc />
        public async Task<bool> DeleteAlbumAsync(long albumId, long? groupId = null)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Video.DeleteAlbum(albumId, groupId));
        }

        /// <inheritdoc />
        public async Task<VkCollection<Comment>> GetCommentsAsync(VideoGetCommentsParams @params)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Video.GetComments(@params));
        }

        /// <inheritdoc />
        public async Task<long> CreateCommentAsync(VideoCreateCommentParams @params)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Video.CreateComment(@params));
        }

        /// <inheritdoc />
        public async Task<bool> DeleteCommentAsync(long commentId, long? ownerId)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Video.DeleteComment(commentId, ownerId));
        }

        /// <inheritdoc />
        public async Task<bool> RestoreCommentAsync(long commentId, long? ownerId)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Video.RestoreComment(commentId, ownerId));
        }

        /// <inheritdoc />
        public async Task<bool> EditCommentAsync(long commentId, string message, long? ownerId = null,
            IEnumerable<MediaAttachment> attachments = null)
        {
            return await TypeHelper.TryInvokeMethodAsync(() =>
                _vk.Video.EditComment(commentId, message, ownerId, attachments));
        }

        /// <inheritdoc />
        public async Task<bool> ReportAsync(long videoId, ReportReason reason, long? ownerId, string comment = null,
            string searchQuery = null)
        {
            return await TypeHelper.TryInvokeMethodAsync(() =>
                _vk.Video.Report(videoId, reason, ownerId, comment, searchQuery));
        }

        /// <inheritdoc />
        public async Task<bool> ReportCommentAsync(long commentId, long ownerId, ReportReason reason)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Video.ReportComment(commentId, ownerId, reason));
        }

        /// <inheritdoc />
        public async Task<VideoAlbum> GetAlbumByIdAsync(long albumId, long? ownerId = null)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Video.GetAlbumById(albumId, ownerId));
        }

        /// <inheritdoc />
        public async Task<bool> ReorderAlbumsAsync(long albumId, long? ownerId, long? before, long? after)
        {
            return await TypeHelper.TryInvokeMethodAsync(() =>
                _vk.Video.ReorderAlbums(albumId, ownerId, before, after));
        }

        /// <inheritdoc />
        public async Task<bool> ReorderVideosAsync(VideoReorderVideosParams @params)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Video.ReorderVideos(@params));
        }

        /// <inheritdoc />
        public async Task<bool> AddToAlbumAsync(long ownerId, long videoId, IEnumerable<string> albumIds,
            long? targetId = null, long? albumId = null)
        {
            return await TypeHelper.TryInvokeMethodAsync(() =>
                _vk.Video.AddToAlbum(ownerId, videoId, albumIds, targetId, albumId));
        }

        /// <inheritdoc />
        public async Task<bool> RemoveFromAlbumAsync(long ownerId, long videoId, IEnumerable<string> albumIds,
            long? targetId = null, long? albumId = null)
        {
            return await TypeHelper.TryInvokeMethodAsync(() =>
                _vk.Video.RemoveFromAlbum(ownerId, videoId, albumIds, targetId, albumId));
        }

        /// <inheritdoc />
        public async Task<VkCollection<VideoAlbum>> GetAlbumsByVideoAsync(long? targetId, long ownerId, long videoId,
            bool? extended)
        {
            return await TypeHelper.TryInvokeMethodAsync(() =>
                _vk.Video.GetAlbumsByVideo(targetId, ownerId, videoId, extended));
        }

        /// <inheritdoc />
        public async Task<ReadOnlyCollection<VideoCatalog>> GetCatalogAsync(VideoGetCatalogParams @params)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Video.GetCatalog(@params));
        }

        /// <inheritdoc />
        public async Task<ReadOnlyCollection<VideoCatalogItem>> GetCatalogSectionAsync(string sectionId, string @from,
            long? count = null, bool? extended = null)
        {
            return await TypeHelper.TryInvokeMethodAsync(() =>
                _vk.Video.GetCatalogSection(sectionId, @from, count, extended));
        }

        /// <inheritdoc />
        public async Task<bool> HideCatalogSectionAsync(long sectionId)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Video.HideCatalogSection(sectionId));
        }
    }
}