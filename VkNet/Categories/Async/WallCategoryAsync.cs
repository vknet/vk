using System.Collections.Generic;
using System.Threading.Tasks;
using VkNet.Enums;
using VkNet.Enums.Filters;
using VkNet.Model;
using VkNet.Model.Attachments;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkNet.Categories
{
    /// <inheritdoc />
    public partial class WallCategory
    {
        /// <inheritdoc />
        public async Task<WallGetObject> GetAsync(WallGetParams @params, bool skipAuthorization = false)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Wall.Get(@params, skipAuthorization));
        }

        /// <inheritdoc />
        public async Task<VkCollection<Comment>> GetCommentsAsync(WallGetCommentsParams @params,
            bool skipAuthorization = false)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Wall.GetComments(@params, skipAuthorization));
        }

        /// <inheritdoc />
        public async Task<WallGetObject> GetByIdAsync(IEnumerable<string> posts, bool? extended = null,
            long? copyHistoryDepth = null, ProfileFields fields = null, bool skipAuthorization = false)
        {
            return await TypeHelper.TryInvokeMethodAsync(() =>
                _vk.Wall.GetById(posts, extended, copyHistoryDepth, fields, skipAuthorization));
        }

        /// <inheritdoc />
        public async Task<long> PostAsync(WallPostParams @params)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Wall.Post(@params));
        }

        /// <inheritdoc />
        public async Task<RepostResult> RepostAsync(string @object, string message, long? groupId, bool markAsAds)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Wall.Repost(@object, message, groupId, markAsAds));
        }

        /// <inheritdoc />
        public async Task<bool> EditAsync(WallEditParams @params)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Wall.Edit(@params));
        }

        /// <inheritdoc />
        public async Task<bool> DeleteAsync(long? ownerId = null, long? postId = null)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Wall.Delete(ownerId, postId));
        }

        /// <inheritdoc />
        public async Task<bool> RestoreAsync(long? ownerId = null, long? postId = null)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Wall.Restore(ownerId, postId));
        }

        /// <inheritdoc />
        public async Task<long> CreateCommentAsync(WallCreateCommentParams @params)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Wall.CreateComment(@params));
        }

        /// <inheritdoc />
        public async Task<bool> DeleteCommentAsync(long? ownerId, long commentId)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Wall.DeleteComment(ownerId, commentId));
        }

        /// <inheritdoc />
        public async Task<bool> RestoreCommentAsync(long commentId, long? ownerId)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Wall.RestoreComment(commentId, ownerId));
        }

        /// <inheritdoc />
        public async Task<WallGetObject> SearchAsync(WallSearchParams @params, bool skipAuthorization = false)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Wall.Search(@params, skipAuthorization));
        }

        /// <inheritdoc />
        public async Task<WallGetObject> GetRepostsAsync(long? ownerId, long? postId, long? offset, long? count,
            bool skipAuthorization = false)
        {
            return await TypeHelper.TryInvokeMethodAsync(() =>
                _vk.Wall.GetReposts(ownerId, postId, offset, count, skipAuthorization));
        }

        /// <inheritdoc />
        public async Task<bool> PinAsync(long postId, long? ownerId = null)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Wall.Pin(postId, ownerId));
        }

        /// <inheritdoc />
        public async Task<bool> UnpinAsync(long postId, long? ownerId = null)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Wall.Unpin(postId, ownerId));
        }

        /// <inheritdoc />
        public async Task<bool> EditCommentAsync(long commentId, string message, long? ownerId = null,
            IEnumerable<MediaAttachment> attachments = null)
        {
            return await TypeHelper.TryInvokeMethodAsync(() =>
                _vk.Wall.EditComment(commentId, message, ownerId, attachments));
        }

        /// <inheritdoc />
        public async Task<bool> ReportPostAsync(long ownerId, long postId, ReportReason? reason = null)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Wall.ReportPost(ownerId, postId, reason));
        }

        /// <inheritdoc />
        public async Task<bool> ReportCommentAsync(long ownerId, long commentId, ReportReason? reason)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Wall.ReportComment(ownerId, commentId, reason));
        }

        /// <inheritdoc />
        public async Task<bool> EditAdsStealthAsync(EditAdsStealthParams @params)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Wall.EditAdsStealth(@params));
        }

        /// <inheritdoc />
        public async Task<long> PostAdsStealthAsync(PostAdsStealthParams @params)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Wall.PostAdsStealth(@params));
        }
    }
}