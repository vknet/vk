using System;
using VkNet.Model;
using VkNet.Model.Attachments;
using VkNet.Utils;

namespace VkNet.Abstractions
{
	/// <inheritdoc cref="IFaveCategoryAsync" />
	public partial interface IFaveCategory
	{
		/// <inheritdoc cref="IFaveCategoryAsync.GetUsersAsync" />
		[Obsolete(ObsoleteText.Obsolete)]
		VkCollection<User> GetUsers(int? count = null, int? offset = null);

		/// <inheritdoc cref="IFaveCategoryAsync.GetPhotosAsync" />
		[Obsolete(ObsoleteText.Obsolete)]
		VkCollection<Photo> GetPhotos(int? count = null, int? offset = null, bool? photoSizes = null);

		/// <inheritdoc cref="IFaveCategoryAsync.GetPostsAsync" />
		[Obsolete(ObsoleteText.Obsolete)]
		WallGetObject GetPosts(int? count = null, int? offset = null, bool extended = false);

		/// <inheritdoc cref="IFaveCategoryAsync.GetVideosAsync" />
		[Obsolete(ObsoleteText.Obsolete)]
		FaveVideoEx GetVideos(int? count = null, int? offset = null, bool extended = false);

		/// <inheritdoc cref="IFaveCategoryAsync.GetLinksAsync" />
		[Obsolete(ObsoleteText.Obsolete)]
		VkCollection<ExternalLink> GetLinks(int? count = null, int? offset = null);

		/// <inheritdoc cref="IFaveCategoryAsync.AddUserAsync" />
		[Obsolete(ObsoleteText.Obsolete)]
		bool AddUser(long userId);

		/// <inheritdoc cref="IFaveCategoryAsync.RemoveUserAsync" />
		[Obsolete(ObsoleteText.Obsolete)]
		bool RemoveUser(long userId);

		/// <inheritdoc cref="IFaveCategoryAsync.AddGroupAsync" />
		[Obsolete(ObsoleteText.Obsolete)]
		bool AddGroup(long groupId);

		/// <inheritdoc cref="IFaveCategoryAsync.RemoveGroupAsync" />
		[Obsolete(ObsoleteText.Obsolete)]
		bool RemoveGroup(long groupId);

		/// <inheritdoc cref="IFaveCategoryAsync.AddLinkAsync(Uri,string)" />
		[Obsolete(ObsoleteText.Obsolete + "Используйте вместо него bool AddLink(Uri link)")]
		bool AddLink(Uri link, string text);

		/// <inheritdoc cref="IFaveCategoryAsync.GetMarketItemsAsync" />
		[Obsolete(ObsoleteText.Obsolete)]
		VkCollection<Market> GetMarketItems(ulong? count = null, ulong? offset = null, bool? extended = null);
	}
}