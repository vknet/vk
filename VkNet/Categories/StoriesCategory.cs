using System;
using System.Collections.Generic;
using VkNet.Abstractions;
using VkNet.Model;
using VkNet.Model.RequestParams.Stories;
using VkNet.Utils;

namespace VkNet.Categories
{
	/// <inheritdoc/>
	public partial class StoriesCategory : IStoriesCategory
	{
		/// <summary>
		/// API.
		/// </summary>
		private readonly IVkApiInvoke _vk;

		/// <inheritdoc/>
		/// <param name = "api">
		/// Api vk.com
		/// </param>
		public StoriesCategory(IVkApiInvoke api)
		{
			_vk = api;
		}

		/// <inheritdoc/>
		public bool BanOwner(IEnumerable<long> ownersIds)
		{
			return _vk.Call<bool>("stories.banOwner", new VkParameters { { "owners_ids", ownersIds } });
		}

		/// <inheritdoc/>
		public bool Delete(long ownerId, ulong storyId)
		{
			return _vk.Call<bool>("stories.delete", new VkParameters { { "owner_id", ownerId }, { "story_id", storyId } });
		}

		/// <inheritdoc/>
		public StoryResult Get(long? ownerId = null, bool? extended = null)
		{
			return _vk.Call<StoryResult>("stories.get", new VkParameters { { "owner_id", ownerId }, { "extended", extended } });
		}

		/// <inheritdoc/>
		public IEnumerable<object> GetBanned(IEnumerable<string> fields, bool? extended = null)
		{
			return _vk.Call<IEnumerable<object>>("stories.getBanned", new VkParameters { { "fields", fields }, { "extended", extended } });
		}

		/// <inheritdoc/>
		public IEnumerable<object> GetById(IEnumerable<string> stories, IEnumerable<string> fields, bool? extended = null)
		{
			return _vk.Call<IEnumerable<object>>("stories.getById",
				new VkParameters { { "stories", stories }, { "fields", fields }, { "extended", extended } });
		}

		/// <inheritdoc/>
		public Uri GetPhotoUploadServer(GetPhotoUploadServerParams getPhotoUploadServerParams)
		{
			return _vk.Call<Uri>("stories.getPhotoUploadServer",
				new VkParameters
				{
					{ "reply_to_story", getPhotoUploadServerParams.ReplyToStory }, { "link_text", getPhotoUploadServerParams.LinkText },
					{ "link_url", getPhotoUploadServerParams.LinkUrl }, { "add_to_news", getPhotoUploadServerParams.AddToNews },
					{ "user_ids", getPhotoUploadServerParams.UserIds }, { "group_id", getPhotoUploadServerParams.GroupId }
				});
		}

		/// <inheritdoc/>
		public IEnumerable<object> GetReplies(long ownerId, ulong storyId, string accessKey, IEnumerable<string> fields,
											bool? extended = null)
		{
			return _vk.Call<IEnumerable<object>>("stories.getReplies",
				new VkParameters
				{
					{ "owner_id", ownerId }, { "story_id", storyId }, { "access_key", accessKey }, { "fields", fields },
					{ "extended", extended }
				});
		}

		/// <inheritdoc/>
		public object GetStats(long ownerId, ulong storyId)
		{
			return _vk.Call<object>("stories.getStats", new VkParameters { { "owner_id", ownerId }, { "story_id", storyId } });
		}

		/// <inheritdoc/>
		public Uri GetVideoUploadServer(GetVideoUploadServerParams getVideoUploadServerParams)
		{
			return _vk.Call<Uri>("stories.getVideoUploadServer",
				new VkParameters
				{
					{ "reply_to_story", getVideoUploadServerParams.ReplyToStory }, { "link_text", getVideoUploadServerParams.LinkText },
					{ "link_url", getVideoUploadServerParams.LinkUrl }, { "add_to_news", getVideoUploadServerParams.AddToNews },
					{ "user_ids", getVideoUploadServerParams.UserIds }, { "group_id", getVideoUploadServerParams.GroupId }
				});
		}

		/// <inheritdoc/>
		public IEnumerable<object> GetViewers(long ownerId, ulong storyId, ulong? count = null, ulong? offset = null, bool? extended = null)
		{
			return _vk.Call<IEnumerable<object>>("stories.getViewers",
				new VkParameters
				{
					{ "owner_id", ownerId }, { "story_id", storyId }, { "count", count }, { "offset", offset }, { "extended", extended }
				});
		}

		/// <inheritdoc/>
		public bool HideAllReplies(long ownerId)
		{
			return _vk.Call<bool>("stories.hideAllReplies", new VkParameters { { "owner_id", ownerId } });
		}

		/// <inheritdoc/>
		public bool HideReply(long ownerId, ulong storyId, string accessKey)
		{
			return _vk.Call<bool>("stories.hideReply",
				new VkParameters { { "owner_id", ownerId }, { "story_id", storyId }, { "access_key", accessKey } });
		}

		/// <inheritdoc/>
		public bool UnbanOwner(IEnumerable<long> ownersIds)
		{
			return _vk.Call<bool>("stories.unbanOwner", new VkParameters { { "owners_ids", ownersIds } });
		}
	}
}