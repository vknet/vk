using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VkNet.Model;
using VkNet.Model.RequestParams.Stories;
using VkNet.Utils;

namespace VkNet.Categories
{
	/// <inheritdoc/>
	public partial class StoriesCategory
	{
		/// <inheritdoc/>
		public async Task<bool> BanOwnerAsync(IEnumerable<long> ownersIds)
		{
			return await TypeHelper.TryInvokeMethodAsync(() => BanOwner(ownersIds));
		}

		/// <inheritdoc/>
		public async Task<bool> DeleteAsync(long ownerId, ulong storyId)
		{
			return await TypeHelper.TryInvokeMethodAsync(() => Delete(ownerId, storyId));
		}

		/// <inheritdoc/>
		public async Task<StoryResult<IEnumerable<Story>>> GetAsync(long? ownerId = null, bool? extended = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(() => Get(ownerId, extended));
		}

		/// <inheritdoc/>
		public async Task<StoryResult<long>> GetBannedAsync(IEnumerable<string> fields, bool? extended = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(() => GetBanned(extended, fields));
		}

		/// <inheritdoc/>
		public async Task<StoryResult<Story>> GetByIdAsync(IEnumerable<string> stories, bool? extended = null, IEnumerable<string> fields = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(() => GetById(stories, extended, fields));
		}

		/// <inheritdoc/>
		public async Task<StoryServerUrl> GetPhotoUploadServerAsync(GetPhotoUploadServerParams getPhotoUploadServerParams)
		{
			return await TypeHelper.TryInvokeMethodAsync(() => GetPhotoUploadServer(getPhotoUploadServerParams));
		}

		/// <inheritdoc/>
		public async Task<StoryResult<IEnumerable<Story>>> GetRepliesAsync(long ownerId, ulong storyId, string accessKey = null, bool? extended = null, IEnumerable<string> fields = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(() => GetReplies(ownerId, storyId, accessKey, extended, fields));
		}

		/// <inheritdoc/>
		public async Task<StoryStatsResult> GetStatsAsync(long ownerId, ulong storyId)
		{
			return await TypeHelper.TryInvokeMethodAsync(() => GetStats(ownerId, storyId));
		}

		/// <inheritdoc/>
		public async Task<StoryServerUrl> GetVideoUploadServerAsync(GetVideoUploadServerParams getVideoUploadServerParams)
		{
			return await TypeHelper.TryInvokeMethodAsync(() => GetVideoUploadServer(getVideoUploadServerParams));
		}

		/// <inheritdoc/>
		public async Task<VkCollection<User>> GetViewersAsync(long ownerId, ulong storyId, ulong? count = null, ulong? offset = null,
																bool? extended = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(() => GetViewers(ownerId, storyId, count, offset, extended));
		}

		/// <inheritdoc/>
		public async Task<bool> HideAllRepliesAsync(long ownerId)
		{
			return await TypeHelper.TryInvokeMethodAsync(() => HideAllReplies(ownerId));
		}

		/// <inheritdoc/>
		public async Task<bool> HideReplyAsync(long ownerId, ulong storyId, string accessKey = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(() => HideReply(ownerId, storyId, accessKey));
		}

		/// <inheritdoc/>
		public async Task<bool> UnbanOwnerAsync(IEnumerable<long> ownersIds)
		{
			return await TypeHelper.TryInvokeMethodAsync(() => UnbanOwner(ownersIds));
		}
	}
}