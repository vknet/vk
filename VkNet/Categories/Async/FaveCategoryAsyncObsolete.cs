using System;
using System.Threading;
using System.Threading.Tasks;
using VkNet.Model;
using VkNet.Model.Attachments;
using VkNet.Utils;

namespace VkNet.Categories;

/// <inheritdoc />
public partial class FaveCategory
{
	/// <inheritdoc />
	[Obsolete(ObsoleteText.Obsolete)]
	public Task<VkCollection<User>> GetUsersAsync(int? count = null,
												int? offset = null,
												CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetUsers(count, offset), token);

	/// <inheritdoc />
	[Obsolete(ObsoleteText.Obsolete)]
	public Task<VkCollection<Photo>> GetPhotosAsync(int? count = null,
													int? offset = null,
													bool? photoSizes = null,
													CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetPhotos(count, offset, photoSizes), token);

	/// <inheritdoc />
	[Obsolete(ObsoleteText.Obsolete)]
	public Task<WallGetObject> GetPostsAsync(int? count = null,
											int? offset = null,
											bool extended = false,
											CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetPosts(count, offset, extended), token);

	/// <inheritdoc />
	[Obsolete(ObsoleteText.Obsolete)]
	public Task<FaveVideoEx> GetVideosAsync(int? count = null,
											int? offset = null,
											bool extended = false,
											CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetVideos(count, offset, extended), token);

	/// <inheritdoc />
	[Obsolete(ObsoleteText.Obsolete)]
	public Task<VkCollection<ExternalLink>> GetLinksAsync(int? count = null,
														int? offset = null,
														CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetLinks(count, offset), token);

	/// <inheritdoc />
	[Obsolete(ObsoleteText.Obsolete)]
	public Task<bool> AddUserAsync(long userId,
									CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			AddUser(userId), token);

	/// <inheritdoc />
	[Obsolete(ObsoleteText.Obsolete)]
	public Task<bool> RemoveUserAsync(long userId,
									CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			RemoveUser(userId), token);

	/// <inheritdoc />
	[Obsolete(ObsoleteText.Obsolete)]
	public Task<bool> AddGroupAsync(long groupId,
									CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			AddGroup(groupId), token);

	/// <inheritdoc />
	[Obsolete(ObsoleteText.Obsolete)]
	public Task<bool> RemoveGroupAsync(long groupId,
										CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			RemoveGroup(groupId), token);

	/// <inheritdoc />
	[Obsolete(ObsoleteText.Obsolete + "Используйте вместо него Task<bool> AddLinkAsync(Uri link)")]
	public Task<bool> AddLinkAsync(Uri link,
									string text,
									CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			AddLink(link, text), token);

	/// <inheritdoc />
	[Obsolete(ObsoleteText.Obsolete)]
	public Task<VkCollection<Market>> GetMarketItemsAsync(ulong? count = null,
														ulong? offset = null,
														bool? extended = null,
														CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetMarketItems(count, offset, extended));
}