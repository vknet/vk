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
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Fave.GetUsers(count: count, offset: offset));
		}

		/// <inheritdoc />
		public async Task<VkCollection<Photo>> GetPhotosAsync(int? count = null, int? offset = null, bool? photoSizes = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.Fave.GetPhotos(count: count, offset: offset, photoSizes: photoSizes));
		}

		/// <inheritdoc />
		public async Task<WallGetObject> GetPostsAsync(int? count = null, int? offset = null, bool extended = false)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Fave.GetPosts(count: count, offset: offset, extended: extended));
		}

		/// <inheritdoc />
		public async Task<FaveVideoEx> GetVideosAsync(int? count = null, int? offset = null, bool extended = false)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Fave.GetVideos(count: count, offset: offset, extended: extended));
		}

		/// <inheritdoc />
		public async Task<VkCollection<ExternalLink>> GetLinksAsync(int? count = null, int? offset = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Fave.GetLinks(count: count, offset: offset));
		}

		/// <inheritdoc />
		public async Task<bool> AddUserAsync(long userId)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Fave.AddUser(userId: userId));
		}

		/// <inheritdoc />
		public async Task<bool> RemoveUserAsync(long userId)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Fave.RemoveUser(userId: userId));
		}

		/// <inheritdoc />
		public async Task<bool> AddGroupAsync(long groupId)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Fave.AddGroup(groupId: groupId));
		}

		/// <inheritdoc />
		public async Task<bool> RemoveGroupAsync(long groupId)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Fave.RemoveGroup(groupId: groupId));
		}

		/// <inheritdoc />
		public async Task<bool> AddLinkAsync(Uri link, string text)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Fave.AddLink(link: link, text: text));
		}

		/// <inheritdoc />
		public async Task<bool> RemoveLinkAsync(string linkId)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Fave.RemoveLink(linkId: linkId));
		}

		/// <inheritdoc />
		public async Task<VkCollection<Market>> GetMarketItemsAsync(ulong? count = null, ulong? offset = null, bool? extended = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.Fave.GetMarketItems(count: count, offset: offset, extended: extended));
		}
	}
}