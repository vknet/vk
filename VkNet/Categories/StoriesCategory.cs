using System;
using System.Collections.Generic;
using VkNet.Abstractions;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Categories;

/// <inheritdoc cref="IStoriesCategory" />
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
	public StoriesCategory(IVkApiInvoke vk) => _vk = vk;

	/// <inheritdoc/>
	public bool BanOwner(IEnumerable<long> ownersIds) => _vk.Call<bool>("stories.banOwner",
		new()
		{
			{
				"owners_ids", ownersIds
			}
		});

	/// <inheritdoc/>
	public bool Delete(long ownerId, ulong storyId) => _vk.Call<bool>("stories.delete",
		new()
		{
			{
				"owner_id", ownerId
			},
			{
				"story_id", storyId
			}
		});

	/// <inheritdoc/>
	public StoryResult<IEnumerable<Story>> Get(long? ownerId = null, bool? extended = null) => _vk.Call<StoryResult<IEnumerable<Story>>>(
		"stories.get",
		new()
		{
			{
				"owner_id", ownerId
			},
			{
				"extended", extended
			}
		});

	/// <inheritdoc/>
	public StoryResult<long> GetBanned(bool? extended = null, IEnumerable<string> fields = null) => _vk.Call<StoryResult<long>>(
		"stories.getBanned",
		new()
		{
			{
				"fields", fields
			},
			{
				"extended", extended
			}
		});

	/// <inheritdoc/>
	public StoryResult<Story> GetById(IEnumerable<string> stories, bool? extended = null, IEnumerable<string> fields = null) =>
		_vk.Call<StoryResult<Story>>("stories.getById",
			new()
			{
				{
					"stories", stories
				},
				{
					"fields", fields
				},
				{
					"extended", extended
				}
			});

	/// <inheritdoc/>
	public StoryServerUrl GetPhotoUploadServer(GetPhotoUploadServerParams getPhotoUploadServerParams) => _vk.Call<StoryServerUrl>(
		"stories.getPhotoUploadServer",
		new()
		{
			{
				"reply_to_story", getPhotoUploadServerParams.ReplyToStory
			},
			{
				"link_text", getPhotoUploadServerParams.LinkText
			},
			{
				"link_url", getPhotoUploadServerParams.LinkUrl
			},
			{
				"add_to_news", getPhotoUploadServerParams.AddToNews
			},
			{
				"user_ids", getPhotoUploadServerParams.UserIds
			},
			{
				"group_id", getPhotoUploadServerParams.GroupId
			},
			{
				"clickable_stickers", Utilities.SerializeToJson(getPhotoUploadServerParams.ClickableStickers)
			}
		});

	/// <inheritdoc/>
	public StoryResult<IEnumerable<Story>> GetReplies(long ownerId, ulong storyId, string accessKey = null, bool? extended = null,
													IEnumerable<string> fields = null) => _vk.Call<StoryResult<IEnumerable<Story>>>(
		"stories.getReplies",
		new()
		{
			{
				"owner_id", ownerId
			},
			{
				"story_id", storyId
			},
			{
				"access_key", accessKey
			},
			{
				"fields", fields
			},
			{
				"extended", extended
			}
		});

	/// <inheritdoc/>
	public StoryStatsResult GetStats(long ownerId, ulong storyId) => _vk.Call<StoryStatsResult>("stories.getStats",
		new()
		{
			{
				"owner_id", ownerId
			},
			{
				"story_id", storyId
			}
		});

	/// <inheritdoc/>
	public StoryServerUrl GetVideoUploadServer(GetVideoUploadServerParams getVideoUploadServerParams) => _vk.Call<StoryServerUrl>(
		"stories.getVideoUploadServer",
		new()
		{
			{
				"reply_to_story", getVideoUploadServerParams.ReplyToStory
			},
			{
				"link_text", getVideoUploadServerParams.LinkText
			},
			{
				"link_url", getVideoUploadServerParams.LinkUrl
			},
			{
				"add_to_news", getVideoUploadServerParams.AddToNews
			},
			{
				"user_ids", getVideoUploadServerParams.UserIds
			},
			{
				"group_id", getVideoUploadServerParams.GroupId
			},
			{
				"clickable_stickers", Utilities.SerializeToJson(getVideoUploadServerParams.ClickableStickers)
			}
		});

	/// <inheritdoc/>
	public VkCollection<StoryViewers> GetViewers(long ownerId, ulong storyId, ulong? count = null, ulong? offset = null) =>
		_vk.Call<VkCollection<StoryViewers>>("stories.getViewers",
			new()
			{
				{
					"owner_id", ownerId
				},
				{
					"story_id", storyId
				},
				{
					"count", count
				},
				{
					"offset", offset
				}
			});

	/// <inheritdoc />
	public VkCollection<User> GetViewersExtended(long ownerId, ulong storyId, ulong? count = null, ulong? offset = null) =>
		_vk.Call<VkCollection<User>>("stories.getViewers",
			new()
			{
				{
					"owner_id", ownerId
				},
				{
					"story_id", storyId
				},
				{
					"count", count
				},
				{
					"offset", offset
				},
				{
					"extended", true
				}
			});

	/// <inheritdoc/>
	public bool HideAllReplies(long ownerId) => _vk.Call<bool>("stories.hideAllReplies",
		new()
		{
			{
				"owner_id", ownerId
			}
		});

	/// <inheritdoc/>
	public bool HideReply(long ownerId, ulong storyId, string accessKey = null) => _vk.Call<bool>("stories.hideReply",
		new()
		{
			{
				"owner_id", ownerId
			},
			{
				"story_id", storyId
			},
			{
				"access_key", accessKey
			}
		});

	/// <inheritdoc/>
	public bool UnbanOwner(IEnumerable<long> ownersIds) => _vk.Call<bool>("stories.unbanOwner",
		new()
		{
			{
				"owners_ids", ownersIds
			}
		});

	/// <inheritdoc />
	[Obsolete("Начиная с версии 5.118 используется только параметр uploadResults")]
	public VkCollection<Story> Save(StoryServerUrl uploadResults) =>
		_vk.Call<VkCollection<Story>>("stories.save",
			new()
			{
				{
					"upload_results", new VkResponseObject<StoryServerUrl>
					{
						Response = uploadResults
					}
				}
			});

	/// <inheritdoc />
	[Obsolete("Начиная с версии 5.118 используется только параметр uploadResults")]
	public VkCollection<Story> Save(StoryServerUrl uploadResults, bool extended, IEnumerable<string> fields) =>
		_vk.Call<VkCollection<Story>>("stories.save",
			new()
			{
				{
					"upload_results", new VkResponseObject<StoryServerUrl>
					{
						Response = uploadResults
					}
				},
				{
					"extended", extended
				},
				{
					"fields", fields
				}
			});

	/// <inheritdoc />
	public StoryResult<Story> Search(StoriesSearchParams searchParams) => _vk.Call<StoryResult<Story>>("stories.search",
		new()
		{
			{
				"q", searchParams.Query
			},
			{
				"fields", searchParams.Fields
			},
			{
				"place_id", searchParams.PlaceId
			},
			{
				"latitude", searchParams.Latitude
			},
			{
				"longitude", searchParams.Longitude
			},
			{
				"radius", searchParams.Radius
			},
			{
				"mentioned_id", searchParams.MentionedId
			},
			{
				"count", searchParams.Count
			},
			{
				"extended", searchParams.Extended
			}
		});

	/// <inheritdoc />
	public bool SendInteraction(string accessKey, string message, bool? isBroadcast = null, bool? isAnonymous = null,
								bool? unseenMarker = null) => _vk.Call<bool>("stories.sendInteraction",
		new()
		{
			{
				"access_key", accessKey
			},
			{
				"message", message
			},
			{
				"is_broadcast", isBroadcast
			},
			{
				"is_anonymous", isAnonymous
			},
			{
				"unseen_marker", unseenMarker
			}
		});
}