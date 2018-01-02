using System;
using System.Threading.Tasks;
using VkNet.Model;
using VkNet.Model.Attachments;
using VkNet.Utils;

namespace VkNet.Categories
{
    /// <inheritdoc />
    public partial class FaveCategory
    {
        /// <inheritdoc />
        public async Task<VkCollection<User>> GetUsersAsync(int? count = null, int? offset = null)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Fave.GetUsers(count, offset));
        }
        
        /// <inheritdoc />
        public async Task<VkCollection<Photo>> GetPhotosAsync(int? count = null, int? offset = null, bool? photoSizes = null)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Fave.GetPhotos(count, offset, photoSizes));
        }

        /// <inheritdoc />
        public async Task<WallGetObject> GetPostsAsync(int? count = null, int? offset = null, bool extended = false)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Fave.GetPosts(count, offset, extended));
        }

        /// <inheritdoc />
        public async Task<FaveVideoEx> GetVideosAsync(int? count = null, int? offset = null, bool extended = false)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Fave.GetVideos(count, offset, extended));
        }

        /// <inheritdoc />
        public async Task<VkCollection<ExternalLink>> GetLinksAsync(int? count = null, int? offset = null)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Fave.GetLinks(count, offset));
        }

        /// <inheritdoc />
        public async Task<bool> AddUserAsync(long userId)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Fave.AddUser(userId));
        }

        /// <inheritdoc />
        public async Task<bool> RemoveUserAsync(long userId)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Fave.RemoveUser(userId));
        }

        /// <inheritdoc />
        public async Task<bool> AddGroupAsync(long groupId)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Fave.AddGroup(groupId));
        }

        /// <inheritdoc />
        public async Task<bool> RemoveGroupAsync(long groupId)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Fave.RemoveGroup(groupId));
        }

        /// <inheritdoc />
        public async Task<bool> AddLinkAsync(Uri link, string text)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Fave.AddLink(link, text));
        }

        /// <inheritdoc />
        public async Task<bool> RemoveLinkAsync(string linkId)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Fave.RemoveLink(linkId));
        }

        /// <inheritdoc />
        public async Task<VkCollection<Market>> GetMarketItemsAsync(ulong? count = null, ulong? offset = null, bool? extended = null)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Fave.GetMarketItems(count, offset, extended));
        }
    }
}