using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VkNet.Model;
using VkNet.Model.Attachments;
using VkNet.Model.RequestParams.Stories;
using VkNet.Utils;

namespace VkNet.Categories;

/// <inheritdoc/>
public partial class StoriesCategory
{
	/// <inheritdoc/>
	public Task<bool> BanOwnerAsync(IEnumerable<long> ownersIds) => TypeHelper.TryInvokeMethodAsync(() => BanOwner(ownersIds));

	/// <inheritdoc/>
	public Task<bool> DeleteAsync(long ownerId, ulong storyId) => TypeHelper.TryInvokeMethodAsync(() => Delete(ownerId, storyId));

	/// <inheritdoc/>
	public Task<StoryResult<IEnumerable<Story>>> GetAsync(long? ownerId = null, bool? extended = null) =>
		TypeHelper.TryInvokeMethodAsync(() => Get(ownerId, extended));

	/// <inheritdoc/>
	public Task<StoryResult<long>> GetBannedAsync(IEnumerable<string> fields = null, bool? extended = null) =>
		TypeHelper.TryInvokeMethodAsync(() => GetBanned(extended, fields));

	/// <inheritdoc/>
	public Task<StoryResult<Story>> GetByIdAsync(IEnumerable<string> stories, bool? extended = null, IEnumerable<string> fields = null) =>
		TypeHelper.TryInvokeMethodAsync(() => GetById(stories, extended, fields));

	/// <inheritdoc/>
	public Task<StoryServerUrl> GetPhotoUploadServerAsync(GetPhotoUploadServerParams @params) =>
		TypeHelper.TryInvokeMethodAsync(() => GetPhotoUploadServer(@params));

	/// <inheritdoc/>
	public Task<StoryResult<IEnumerable<Story>>> GetRepliesAsync(long ownerId, ulong storyId, string accessKey = null,
																bool? extended = null, IEnumerable<string> fields = null) =>
		TypeHelper.TryInvokeMethodAsync(() => GetReplies(ownerId, storyId, accessKey, extended, fields));

	/// <inheritdoc/>
	public Task<StoryStatsResult> GetStatsAsync(long ownerId, ulong storyId) =>
		TypeHelper.TryInvokeMethodAsync(() => GetStats(ownerId, storyId));

	/// <inheritdoc/>
	public Task<StoryServerUrl> GetVideoUploadServerAsync(GetVideoUploadServerParams @params) =>
		TypeHelper.TryInvokeMethodAsync(() => GetVideoUploadServer(@params));

	/// <inheritdoc/>
	public Task<VkCollection<StoryViewers>> GetViewersAsync(long ownerId, ulong storyId, ulong? count = null, ulong? offset = null) =>
		TypeHelper.TryInvokeMethodAsync(() => GetViewers(ownerId, storyId, count, offset));

	/// <inheritdoc />
	public Task<VkCollection<User>> GetViewersExtendedAsync(long ownerId, ulong storyId, ulong? count = null, ulong? offset = null) =>
		TypeHelper.TryInvokeMethodAsync(() => GetViewersExtended(ownerId, storyId, count, offset));

	/// <inheritdoc/>
	public Task<bool> HideAllRepliesAsync(long ownerId) => TypeHelper.TryInvokeMethodAsync(() => HideAllReplies(ownerId));

	/// <inheritdoc/>
	public Task<bool> HideReplyAsync(long ownerId, ulong storyId, string accessKey = null) =>
		TypeHelper.TryInvokeMethodAsync(() => HideReply(ownerId, storyId, accessKey));

	/// <inheritdoc/>
	public Task<bool> UnbanOwnerAsync(IEnumerable<long> ownersIds) => TypeHelper.TryInvokeMethodAsync(() => UnbanOwner(ownersIds));

	/// <inheritdoc />
	public Task<VkCollection<Story>> SaveAsync(StoryServerUrl uploadResults, bool extended, IEnumerable<string> fields,
												CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() => Save(uploadResults, extended, fields));

	/// <inheritdoc />
	public Task<StoryResult<Story>> SearchAsync(StoriesSearchParams searchParams, CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() => Search(searchParams));

	/// <inheritdoc />
	public Task<bool> SendInteractionAsync(string accessKey, string message, bool? isBroadcast = null, bool? isAnonymous = null,
											bool? unseenMarker = null,
											CancellationToken token = default) => TypeHelper.TryInvokeMethodAsync(() =>
		SendInteraction(accessKey, message, isBroadcast, isAnonymous, unseenMarker));
}