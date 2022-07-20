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
		[Obsolete(ObsoleteText.Obsolete)]
		public Task<VkCollection<User>> GetUsersAsync(int? count = null, int? offset = null)
		{
			return TypeHelper.TryInvokeMethodAsync(() => GetUsers(count, offset));
		}

		/// <inheritdoc />
		[Obsolete(ObsoleteText.Obsolete)]
		public Task<VkCollection<Photo>> GetPhotosAsync(int? count = null, int? offset = null, bool? photoSizes = null)
		{
			return TypeHelper.TryInvokeMethodAsync(() => GetPhotos(count, offset, photoSizes));
		}

		/// <inheritdoc />
		[Obsolete(ObsoleteText.Obsolete)]
		public Task<WallGetObject> GetPostsAsync(int? count = null, int? offset = null, bool extended = false)
		{
			return TypeHelper.TryInvokeMethodAsync(() => GetPosts(count, offset, extended));
		}

		/// <inheritdoc />
		[Obsolete(ObsoleteText.Obsolete)]
		public Task<FaveVideoEx> GetVideosAsync(int? count = null, int? offset = null, bool extended = false)
		{
			return TypeHelper.TryInvokeMethodAsync(() => GetVideos(count, offset, extended));
		}

		/// <inheritdoc />
		[Obsolete(ObsoleteText.Obsolete)]
		public Task<VkCollection<ExternalLink>> GetLinksAsync(int? count = null, int? offset = null)
		{
			return TypeHelper.TryInvokeMethodAsync(() => GetLinks(count, offset));
		}

		/// <inheritdoc />
		[Obsolete(ObsoleteText.Obsolete)]
		public Task<bool> AddUserAsync(long userId)
		{
			return TypeHelper.TryInvokeMethodAsync(() => AddUser(userId));
		}

		/// <inheritdoc />
		[Obsolete(ObsoleteText.Obsolete)]
		public Task<bool> RemoveUserAsync(long userId)
		{
			return TypeHelper.TryInvokeMethodAsync(() => RemoveUser(userId));
		}

		/// <inheritdoc />
		[Obsolete(ObsoleteText.Obsolete)]
		public Task<bool> AddGroupAsync(long groupId)
		{
			return TypeHelper.TryInvokeMethodAsync(() => AddGroup(groupId));
		}

		/// <inheritdoc />
		[Obsolete(ObsoleteText.Obsolete)]
		public Task<bool> RemoveGroupAsync(long groupId)
		{
			return TypeHelper.TryInvokeMethodAsync(() => RemoveGroup(groupId));
		}

		/// <inheritdoc />
		[Obsolete(ObsoleteText.Obsolete + "Используйте вместо него Task<bool> AddLinkAsync(Uri link)")]
		public Task<bool> AddLinkAsync(Uri link, string text)
		{
			return TypeHelper.TryInvokeMethodAsync(() => AddLink(link, text));
		}

		/// <inheritdoc />
		[Obsolete(ObsoleteText.Obsolete)]
		public Task<VkCollection<Market>> GetMarketItemsAsync(ulong? count = null, ulong? offset = null, bool? extended = null)
		{
			return TypeHelper.TryInvokeMethodAsync(() => GetMarketItems(count, offset, extended));
		}
	}
}