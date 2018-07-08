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
		public async Task<StoryResult> GetAsync(long? ownerId = null, bool? extended = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(() => Get(ownerId, extended));
		}

		/// <inheritdoc/>
		public async Task<IEnumerable<object>> GetBannedAsync(IEnumerable<string> fields, bool? extended = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(() => GetBanned(fields, extended));
		}

		/// <inheritdoc/>
		public async Task<IEnumerable<object>> GetByIdAsync(IEnumerable<string> stories, IEnumerable<string> fields, bool? extended = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(() => GetById(stories, fields, extended));
		}

		/// <inheritdoc/>
		public async Task<Uri> GetPhotoUploadServerAsync(GetPhotoUploadServerParams getPhotoUploadServerParams)
		{
			return await TypeHelper.TryInvokeMethodAsync(() => GetPhotoUploadServer(getPhotoUploadServerParams));
		}

		/// <inheritdoc/>
		public async Task<IEnumerable<object>> GetRepliesAsync(long ownerId, ulong storyId, string accessKey, IEnumerable<string> fields,
																bool? extended = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(() => GetReplies(ownerId, storyId, accessKey, fields, extended));
		}

		/// <inheritdoc/>
		public async Task<object> GetStatsAsync(long ownerId, ulong storyId)
		{
			return await TypeHelper.TryInvokeMethodAsync(() => GetStats(ownerId, storyId));
		}

		/// <inheritdoc/>
		public async Task<Uri> GetVideoUploadServerAsync(GetVideoUploadServerParams getVideoUploadServerParams)
		{
			return await TypeHelper.TryInvokeMethodAsync(() => GetVideoUploadServer(getVideoUploadServerParams));
		}

		/// <inheritdoc/>
		public async Task<IEnumerable<object>> GetViewersAsync(long ownerId, ulong storyId, ulong? count = null, ulong? offset = null,
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
		public async Task<bool> HideReplyAsync(long ownerId, ulong storyId, string accessKey)
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