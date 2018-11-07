using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using VkNet.Abstractions;
using VkNet.Enums.Filters;
using VkNet.Enums.SafetyEnums;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkNet.Categories
{
	/// <summary>
	/// Методы для работы с новостной лентой пользователя.
	/// </summary>
	public partial class NewsFeedCategory : INewsFeedCategory
	{
		/// <summary>
		/// API.
		/// </summary>
		private readonly IVkApiInvoke _vk;

		/// <summary>
		/// Методы для работы с новостной лентой пользователя.
		/// </summary>
		/// <param name="vk"> API. </param>
		public NewsFeedCategory(IVkApiInvoke vk)
		{
			_vk = vk;
		}

		/// <inheritdoc />
		public NewsFeed Get(NewsFeedGetParams @params)
		{
			return _vk.Call<NewsFeed>("newsfeed.get", @params);
		}

		/// <inheritdoc />
		public NewsFeed GetRecommended(NewsFeedGetRecommendedParams @params)
		{
			return _vk.Call<NewsFeed>("newsfeed.getRecommended", @params);
		}

		/// <inheritdoc />
		public NewsFeed GetComments(NewsFeedGetCommentsParams @params)
		{
			var response = _vk.Call(methodName: "newsfeed.getComments", parameters: @params);

			var result = new NewsFeed
			{
				Items = response[key: "items"].ToReadOnlyCollectionOf<NewsItem>(selector: x => x),
				Profiles = response[key: "profiles"].ToReadOnlyCollectionOf<User>(selector: x => x),
				Groups = response[key: "groups"].ToReadOnlyCollectionOf<Group>(selector: x => x),
				NewOffset = response[key: "new_offset"],
				NextFrom = response[key: "next_from"]
			};

			return result;
		}

		/// <inheritdoc />
		public VkCollection<Mention> GetMentions(long? ownerId = null
												, DateTime? startTime = null
												, DateTime? endTime = null
												, long? offset = null
												, long? count = null)
		{
			var parameters = new VkParameters
			{
				{ "owner_id", ownerId },
				{ "start_time", startTime },
				{ "end_time", endTime },
				{ "offset", offset }
			};

			if (count <= 50)
			{
				parameters.Add(name: "count", nullableValue: count);
			}

			return _vk.Call(methodName: "newsfeed.getMentions", parameters: parameters).ToVkCollectionOf<Mention>(selector: x => x);
		}

		/// <inheritdoc />
		public NewsBannedList GetBanned()
		{
			return _vk.Call(methodName: "newsfeed.getBanned", parameters: VkParameters.Empty);
		}

		/// <inheritdoc />
		public NewsBannedExList GetBannedEx(UsersFields fields = null, NameCase nameCase = null)
		{
			var parameters = new VkParameters
			{
				{ "extended", true },
				{ "fields", fields },
				{ "name_case", nameCase }
			};

			return _vk.Call(methodName: "newsfeed.getBanned", parameters: parameters);
		}

		/// <inheritdoc />
		public bool AddBan(IEnumerable<long> userIds, IEnumerable<long> groupIds)
		{
			var parameters = new VkParameters
			{
				{ "user_ids", userIds },
				{ "group_ids", groupIds }
			};

			return _vk.Call(methodName: "newsfeed.addBan", parameters: parameters);
		}

		/// <inheritdoc />
		public bool DeleteBan(IEnumerable<long> userIds, IEnumerable<long> groupIds)
		{
			var parameters = new VkParameters
			{
				{ "user_ids", userIds },
				{ "group_ids", groupIds }
			};

			return _vk.Call(methodName: "newsfeed.deleteBan", parameters: parameters);
		}

		/// <inheritdoc />
		public bool IgnoreItem(NewsObjectTypes type, long ownerId, long itemId)
		{
			var parameters = new VkParameters
			{
				{ "type", type },
				{ "owner_id", ownerId },
				{ "item_id", itemId }
			};

			return _vk.Call(methodName: "newsfeed.ignoreItem", parameters: parameters);
		}

		/// <inheritdoc />
		public bool UnignoreItem(NewsObjectTypes type, long ownerId, long itemId)
		{
			var parameters = new VkParameters
			{
				{ "type", type },
				{ "owner_id", ownerId },
				{ "item_id", itemId }
			};

			return _vk.Call(methodName: "newsfeed.unignoreItem", parameters: parameters);
		}

		/// <inheritdoc />
		public ReadOnlyCollection<NewsSearchResult> Search(NewsFeedSearchParams @params)
		{
			VkResponseArray response = _vk.Call(methodName: "newsfeed.search", parameters: @params);

			return response.ToReadOnlyCollectionOf<NewsSearchResult>(selector: x => x);
		}

		/// <inheritdoc />
		public VkCollection<NewsUserListItem> GetLists(IEnumerable<long> listIds, bool? extended = null)
		{
			var parameters = new VkParameters
			{
				{ "list_ids", listIds },
				{ "extended", extended }
			};

			return _vk.Call(methodName: "newsfeed.getLists", parameters: parameters).ToVkCollectionOf<NewsUserListItem>(selector: x => x);
		}

		/// <inheritdoc />
		public long SaveList(string title, IEnumerable<long> sourceIds, long? listId = null, bool? noReposts = null)
		{
			var parameters = new VkParameters
			{
				{ "list_id", listId },
				{ "title", title },
				{ "source_ids", sourceIds },
				{ "no_reposts", noReposts }
			};

			return _vk.Call(methodName: "newsfeed.saveList", parameters: parameters);
		}

		/// <inheritdoc />
		public bool DeleteList(long listId)
		{
			var parameters = new VkParameters
			{
				{ "list_id", listId }
			};

			return _vk.Call(methodName: "newsfeed.deleteList", parameters: parameters);
		}

		/// <inheritdoc />
		public bool Unsubscribe(CommentObjectType type, long itemId, long? ownerId = null)
		{
			var parameters = new VkParameters
			{
				{ "type", type },
				{ "owner_id", ownerId },
				{ "item_id", itemId }
			};

			return _vk.Call(methodName: "newsfeed.unsubscribe", parameters: parameters);
		}

		/// <inheritdoc />
		public NewsSuggestions GetSuggestedSources(long? offset = null, long? count = null, bool? shuffle = null, UsersFields fields = null)
		{
			var parameters = new VkParameters
			{
				{ "offset", offset },
				{ "shuffle", shuffle },
				{ "fields", fields }
			};

			if (count <= 1000)
			{
				parameters.Add(name: "count", nullableValue: count);
			}

			return _vk.Call(methodName: "newsfeed.getSuggestedSources", parameters: parameters);
		}
	}
}