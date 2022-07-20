using System.Collections.Generic;
using VkNet.Abstractions;
using VkNet.Model;
using VkNet.Model.Attachments;
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

		/// <summary>
		/// api vk.com
		/// </summary>
		/// <param name = "vk">
		/// Api vk.com
		/// </param>
		public StoriesCategory(IVkApiInvoke vk)
		{
			_vk = vk;
		}

		/// <inheritdoc/>
		public bool BanOwner(IEnumerable<long> ownersIds)
		{
			return _vk.Call<bool>("stories.banOwner",
				new VkParameters
				{
					{ "owners_ids", ownersIds }
				});
		}

		/// <inheritdoc/>
		public bool Delete(long ownerId, ulong storyId)
		{
			return _vk.Call<bool>("stories.delete",
				new VkParameters
				{
					{ "owner_id", ownerId },
					{ "story_id", storyId }
				});
		}

		/// <inheritdoc/>
		public StoryResult<IEnumerable<Story>> Get(long? ownerId = null, bool? extended = null)
		{
			return _vk.Call<StoryResult<IEnumerable<Story>>>("stories.get",
				new VkParameters
				{
					{ "owner_id", ownerId },
					{ "extended", extended }
				});
		}

		/// <inheritdoc/>
		public StoryResult<long> GetBanned(bool? extended = null, IEnumerable<string> fields = null)
		{
			return _vk.Call<StoryResult<long>>("stories.getBanned",
				new VkParameters
				{
					{ "fields", fields },
					{ "extended", extended }
				});
		}

		/// <inheritdoc/>
		public StoryResult<Story> GetById(IEnumerable<string> stories, bool? extended = null, IEnumerable<string> fields = null)
		{
			return _vk.Call<StoryResult<Story>>("stories.getById",
				new VkParameters
				{
					{ "stories", stories },
					{ "fields", fields },
					{ "extended", extended }
				});
		}

		/// <inheritdoc/>
		public StoryServerUrl GetPhotoUploadServer(GetPhotoUploadServerParams getPhotoUploadServerParams)
		{
			return _vk.Call<StoryServerUrl>("stories.getPhotoUploadServer",
				new VkParameters
				{
					{ "reply_to_story", getPhotoUploadServerParams.ReplyToStory },
					{ "link_text", getPhotoUploadServerParams.LinkText },
					{ "link_url", getPhotoUploadServerParams.LinkUrl },
					{ "add_to_news", getPhotoUploadServerParams.AddToNews },
					{ "user_ids", getPhotoUploadServerParams.UserIds },
					{ "group_id", getPhotoUploadServerParams.GroupId },
					{ "clickable_stickers", Utilities.SerializeToJson(getPhotoUploadServerParams.ClickableStickers) }
				});
		}

		/// <inheritdoc/>
		public StoryResult<IEnumerable<Story>> GetReplies(long ownerId, ulong storyId, string accessKey = null, bool? extended = null,
														IEnumerable<string> fields = null)
		{
			return _vk.Call<StoryResult<IEnumerable<Story>>>("stories.getReplies",
				new VkParameters
				{
					{ "owner_id", ownerId },
					{ "story_id", storyId },
					{ "access_key", accessKey },
					{ "fields", fields },
					{ "extended", extended }
				});
		}

		/// <inheritdoc/>
		public StoryStatsResult GetStats(long ownerId, ulong storyId)
		{
			return _vk.Call<StoryStatsResult>("stories.getStats",
				new VkParameters
				{
					{ "owner_id", ownerId },
					{ "story_id", storyId }
				});
		}

		/// <inheritdoc/>
		public StoryServerUrl GetVideoUploadServer(GetVideoUploadServerParams getVideoUploadServerParams)
		{
			return _vk.Call<StoryServerUrl>("stories.getVideoUploadServer",
				new VkParameters
				{
					{ "reply_to_story", getVideoUploadServerParams.ReplyToStory },
					{ "link_text", getVideoUploadServerParams.LinkText },
					{ "link_url", getVideoUploadServerParams.LinkUrl },
					{ "add_to_news", getVideoUploadServerParams.AddToNews },
					{ "user_ids", getVideoUploadServerParams.UserIds },
					{ "group_id", getVideoUploadServerParams.GroupId },
					{ "clickable_stickers", Utilities.SerializeToJson(getVideoUploadServerParams.ClickableStickers) }
				});
		}

		/// <inheritdoc/>
		public VkCollection<long> GetViewers(long ownerId, ulong storyId, ulong? count = null, ulong? offset = null)
		{
			return _vk.Call<VkCollection<long>>("stories.getViewers",
				new VkParameters
				{
					{ "owner_id", ownerId },
					{ "story_id", storyId },
					{ "count", count },
					{ "offset", offset }
				});
		}

		/// <inheritdoc />
		public VkCollection<User> GetViewersExtended(long ownerId, ulong storyId, ulong? count = null, ulong? offset = null)
		{
			return _vk.Call<VkCollection<User>>("stories.getViewers",
				new VkParameters
				{
					{ "owner_id", ownerId },
					{ "story_id", storyId },
					{ "count", count },
					{ "offset", offset },
					{ "extended", true }
				});
		}

		/// <inheritdoc/>
		public bool HideAllReplies(long ownerId)
		{
			return _vk.Call<bool>("stories.hideAllReplies",
				new VkParameters
				{
					{ "owner_id", ownerId }
				});
		}

		/// <inheritdoc/>
		public bool HideReply(long ownerId, ulong storyId, string accessKey = null)
		{
			return _vk.Call<bool>("stories.hideReply",
				new VkParameters
				{
					{ "owner_id", ownerId },
					{ "story_id", storyId },
					{ "access_key", accessKey }
				});
		}

		/// <inheritdoc/>
		public bool UnbanOwner(IEnumerable<long> ownersIds)
		{
			return _vk.Call<bool>("stories.unbanOwner",
				new VkParameters
				{
					{ "owners_ids", ownersIds }
				});
		}

		/// <inheritdoc />
		public VkCollection<Story> Save(StoryServerUrl uploadResults, bool extended, IEnumerable<string> fields)
		{
			return _vk.Call<VkCollection<Story>>("stories.save",
				new VkParameters
				{
					{
						"upload_results", new VkResponseObject<StoryServerUrl>
						{
							Response = uploadResults
						}
					},
					{ "extended", extended },
					{ "fields", fields }
				});
		}

		/// <inheritdoc />
		public StoryResult<Story> Search(StoriesSearchParams searchParams)
		{
			return _vk.Call<StoryResult<Story>>("stories.search",
				new VkParameters
				{
					{ "q", searchParams.Query },
					{ "fields", searchParams.Fields },
					{ "place_id", searchParams.PlaceId },
					{ "latitude", searchParams.Latitude },
					{ "longitude", searchParams.Longitude },
					{ "radius", searchParams.Radius },
					{ "mentioned_id", searchParams.MentionedId },
					{ "count", searchParams.Count },
					{ "extended", searchParams.Extended }
				});
		}

		/// <inheritdoc />
		public bool SendInteraction(string accessKey, string message, bool? isBroadcast = null, bool? isAnonymous = null,
									bool? unseenMarker = null)
		{
			return _vk.Call<bool>("stories.sendInteraction",
				new VkParameters
				{
					{ "access_key", accessKey },
					{ "message", message },
					{ "is_broadcast", isBroadcast },
					{ "is_anonymous", isAnonymous },
					{ "unseen_marker", unseenMarker }
				});
		}
	}
}