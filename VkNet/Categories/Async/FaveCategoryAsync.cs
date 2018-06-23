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
		public Task<VkCollection<User>> GetUsersAsync(int? count = null, int? offset = null)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>GetUsers(count: count, offset: offset));
		}

		/// <inheritdoc />
		public Task<VkCollection<Photo>> GetPhotosAsync(int? count = null, int? offset = null, bool? photoSizes = null)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>
					GetPhotos(count: count, offset: offset, photoSizes: photoSizes));
		}

		/// <inheritdoc />
		public Task<WallGetObject> GetPostsAsync(int? count = null, int? offset = null, bool extended = false)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>GetPosts(count: count, offset: offset, extended: extended));
		}

		/// <inheritdoc />
		public Task<FaveVideoEx> GetVideosAsync(int? count = null, int? offset = null, bool extended = false)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>GetVideos(count: count, offset: offset, extended: extended));
		}

		/// <inheritdoc />
		public Task<VkCollection<ExternalLink>> GetLinksAsync(int? count = null, int? offset = null)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>GetLinks(count: count, offset: offset));
		}

		/// <inheritdoc />
		public Task<bool> AddUserAsync(long userId)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>AddUser(userId: userId));
		}

		/// <inheritdoc />
		public Task<bool> RemoveUserAsync(long userId)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>RemoveUser(userId: userId));
		}

		/// <inheritdoc />
		public Task<bool> AddGroupAsync(long groupId)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>AddGroup(groupId: groupId));
		}

		/// <inheritdoc />
		public Task<bool> RemoveGroupAsync(long groupId)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>RemoveGroup(groupId: groupId));
		}

		/// <inheritdoc />
		public Task<bool> AddLinkAsync(Uri link, string text)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>AddLink(link: link, text: text));
		}

		/// <inheritdoc />
		public Task<bool> RemoveLinkAsync(string linkId)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>RemoveLink(linkId: linkId));
		}

		/// <inheritdoc />
		public Task<VkCollection<Market>> GetMarketItemsAsync(ulong? count = null, ulong? offset = null, bool? extended = null)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>
					GetMarketItems(count: count, offset: offset, extended: extended));
		}
	}
}