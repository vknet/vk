using System;
using System.Collections.Generic;
using System.Threading;
using VkNet.Abstractions.Category;
using VkNet.Model;
using VkNet.Model.Attachments;
using VkNet.Model.RequestParams.Stories;
using VkNet.Utils;

namespace VkNet.Abstractions;

/// <inheritdoc cref="IStoriesCategoryAsync"/>
public interface IStoriesCategory : IStoriesCategoryAsync
{
	/// <inheritdoc cref="IStoriesCategoryAsync.BanOwnerAsync"/>
	bool BanOwner(IEnumerable<long> ownersIds);

	/// <inheritdoc cref="IStoriesCategoryAsync.DeleteAsync"/>
	bool Delete(long ownerId, ulong storyId);

	/// <inheritdoc cref="IStoriesCategoryAsync.GetAsync"/>
	StoryResult<IEnumerable<Story>> Get(long? ownerId = null, bool? extended = null);

	/// <inheritdoc cref="IStoriesCategoryAsync.GetBannedAsync"/>
	StoryResult<long> GetBanned(bool? extended = null, IEnumerable<string> fields = null);

	/// <inheritdoc cref="IStoriesCategoryAsync.GetByIdAsync"/>
	StoryResult<Story> GetById(IEnumerable<string> stories, bool? extended = null, IEnumerable<string> fields = null);

	/// <inheritdoc cref="IStoriesCategoryAsync.GetPhotoUploadServerAsync"/>
	StoryServerUrl GetPhotoUploadServer(GetPhotoUploadServerParams getPhotoUploadServerParams);

	/// <inheritdoc cref="IStoriesCategoryAsync.GetRepliesAsync"/>
	StoryResult<IEnumerable<Story>> GetReplies(long ownerId, ulong storyId, string accessKey = null, bool? extended = null,
												IEnumerable<string> fields = null);

	/// <inheritdoc cref="IStoriesCategoryAsync.GetStatsAsync"/>
	StoryStatsResult GetStats(long ownerId, ulong storyId);

	/// <inheritdoc cref="IStoriesCategoryAsync.GetVideoUploadServerAsync"/>
	StoryServerUrl GetVideoUploadServer(GetVideoUploadServerParams getVideoUploadServerParams);

	/// <inheritdoc cref="IStoriesCategoryAsync.GetViewersAsync"/>
	VkCollection<StoryViewers> GetViewers(long ownerId, ulong storyId, ulong? count = null, ulong? offset = null);

	/// <inheritdoc cref="IStoriesCategoryAsync.GetViewersExtendedAsync"/>
	VkCollection<User> GetViewersExtended(long ownerId, ulong storyId, ulong? count = null, ulong? offset = null);

	/// <inheritdoc cref="IStoriesCategoryAsync.HideAllRepliesAsync"/>
	bool HideAllReplies(long ownerId);

	/// <inheritdoc cref="IStoriesCategoryAsync.HideReplyAsync"/>
	bool HideReply(long ownerId, ulong storyId, string accessKey = null);

	/// <inheritdoc cref="IStoriesCategoryAsync.UnbanOwnerAsync"/>
	bool UnbanOwner(IEnumerable<long> ownersIds);

	/// <inheritdoc cref="IStoriesCategoryAsync.SaveAsync(StoryServerUrl, CancellationToken)"/>
	VkCollection<Story> Save(StoryServerUrl uploadResults);

	/// <inheritdoc cref="IStoriesCategoryAsync.SaveAsync(StoryServerUrl, bool, IEnumerable{string}, CancellationToken)"/>

	[Obsolete("Начиная с версии 5.118 используется только параметр uploadResults")]
	VkCollection<Story> Save(StoryServerUrl uploadResults, bool extended, IEnumerable<string> fields);

	/// <inheritdoc cref = "IStoriesCategoryAsync.SearchAsync"/>
	StoryResult<Story> Search(StoriesSearchParams searchParams);

	/// <inheritdoc cref = "IStoriesCategoryAsync.SendInteractionAsync"/>
	bool SendInteraction(string accessKey, string message, bool? isBroadcast = null, bool? isAnonymous = null,
						bool? unseenMarker = null);
}