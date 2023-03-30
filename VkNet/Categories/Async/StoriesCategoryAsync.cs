using System;
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
	public Task<bool> BanOwnerAsync(IEnumerable<long> ownersIds,
									CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			BanOwner(ownersIds), token);

	/// <inheritdoc/>
	public Task<bool> DeleteAsync(long ownerId,
								ulong storyId,
								CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Delete(ownerId, storyId), token);

	/// <inheritdoc/>
	public Task<StoryResult<IEnumerable<Story>>> GetAsync(long? ownerId = null,
														bool? extended = null,
														CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Get(ownerId, extended), token);

	/// <inheritdoc/>
	public Task<StoryResult<long>> GetBannedAsync(IEnumerable<string> fields = null,
												bool? extended = null,
												CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetBanned(extended, fields), token);

	/// <inheritdoc/>
	public Task<StoryResult<Story>> GetByIdAsync(IEnumerable<string> stories,
												bool? extended = null,
												IEnumerable<string> fields = null,
												CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetById(stories, extended, fields), token);

	/// <inheritdoc/>
	public Task<StoryServerUrl> GetPhotoUploadServerAsync(GetPhotoUploadServerParams @params,
														CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetPhotoUploadServer(@params), token);

	/// <inheritdoc/>
	public Task<StoryResult<IEnumerable<Story>>> GetRepliesAsync(long ownerId,
																ulong storyId,
																string accessKey = null,
																bool? extended = null,
																IEnumerable<string> fields = null,
																CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetReplies(ownerId, storyId, accessKey, extended, fields), token);

	/// <inheritdoc/>
	public Task<StoryStatsResult> GetStatsAsync(long ownerId,
												ulong storyId,
												CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetStats(ownerId, storyId), token);

	/// <inheritdoc/>
	public Task<StoryServerUrl> GetVideoUploadServerAsync(GetVideoUploadServerParams @params,
														CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetVideoUploadServer(@params), token);

	/// <inheritdoc/>
	public Task<VkCollection<StoryViewers>> GetViewersAsync(long ownerId,
															ulong storyId,
															ulong? count = null,
															ulong? offset = null,
															CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetViewers(ownerId, storyId, count, offset), token);

	/// <inheritdoc />
	public Task<VkCollection<User>> GetViewersExtendedAsync(long ownerId,
															ulong storyId,
															ulong? count = null,
															ulong? offset = null,
															CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetViewersExtended(ownerId, storyId, count, offset), token);

	/// <inheritdoc/>
	public Task<bool> HideAllRepliesAsync(long ownerId,
										CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			HideAllReplies(ownerId), token);

	/// <inheritdoc/>
	public Task<bool> HideReplyAsync(long ownerId,
									ulong storyId,
									string accessKey = null,
									CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			HideReply(ownerId, storyId, accessKey), token);

	/// <inheritdoc/>
	public Task<bool> UnbanOwnerAsync(IEnumerable<long> ownersIds,
									CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			UnbanOwner(ownersIds), token);

	/// <inheritdoc />
	public Task<VkCollection<Story>> SaveAsync(StoryServerUrl uploadResults,
												CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Save(uploadResults), token);

	/// <inheritdoc />
	[Obsolete("Начиная с версии 5.118 используется только параметр uploadResults")]
	public Task<VkCollection<Story>> SaveAsync(StoryServerUrl uploadResults,
												bool extended,
												IEnumerable<string> fields,
												CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Save(uploadResults, extended, fields), token);

	/// <inheritdoc />
	public Task<StoryResult<Story>> SearchAsync(StoriesSearchParams searchParams,
												CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Search(searchParams), token);

	/// <inheritdoc />
	public Task<bool> SendInteractionAsync(string accessKey,
											string message,
											bool? isBroadcast = null,
											bool? isAnonymous = null,
											bool? unseenMarker = null,
											CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			SendInteraction(accessKey, message, isBroadcast, isAnonymous, unseenMarker), token);
}