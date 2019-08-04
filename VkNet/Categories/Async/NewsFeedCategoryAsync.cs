using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VkNet.Enums.Filters;
using VkNet.Enums.SafetyEnums;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkNet.Categories
{
	/// <inheritdoc />
	public partial class NewsFeedCategory
	{
		/// <inheritdoc />
		public Task<NewsFeed> GetAsync(NewsFeedGetParams @params)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => Get(@params: @params));
		}

		/// <inheritdoc />
		public Task<NewsFeed> GetRecommendedAsync(NewsFeedGetRecommendedParams @params)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => GetRecommended(@params: @params));
		}

		/// <inheritdoc />
		public Task<NewsFeed> GetCommentsAsync(NewsFeedGetCommentsParams @params)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => GetComments(@params: @params));
		}

		/// <inheritdoc />
		public Task<VkCollection<Mention>> GetMentionsAsync(long? ownerId = null
															, DateTime? startTime = null
															, DateTime? endTime = null
															, long? offset = null
															, long? count = null)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>
				GetMentions(ownerId, startTime, endTime, offset));
		}

		/// <inheritdoc />
		public Task<NewsBannedList> GetBannedAsync()
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => GetBanned());
		}

		/// <inheritdoc />
		public Task<NewsBannedExList> GetBannedExAsync(UsersFields fields = null, NameCase nameCase = null)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => GetBannedEx(fields, nameCase));
		}

		/// <inheritdoc />
		public Task<bool> AddBanAsync(IEnumerable<long> userIds, IEnumerable<long> groupIds)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => AddBan(userIds, groupIds));
		}

		/// <inheritdoc />
		public Task<bool> DeleteBanAsync(IEnumerable<long> userIds, IEnumerable<long> groupIds)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => DeleteBan(userIds, groupIds));
		}

		/// <inheritdoc />
		public Task<bool> IgnoreItemAsync(NewsObjectTypes type, long ownerId, long itemId)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => IgnoreItem(type, ownerId, itemId));
		}

		/// <inheritdoc />
		public Task<bool> UnignoreItemAsync(NewsObjectTypes type, long ownerId, long itemId)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>
				UnignoreItem(type, ownerId, itemId));
		}

		/// <inheritdoc />
		public Task<NewsSearchResult> SearchAsync(NewsFeedSearchParams @params)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => Search(@params: @params));
		}

		/// <inheritdoc />
		public Task<VkCollection<NewsUserListItem>> GetListsAsync(IEnumerable<long> listIds, bool? extended = null)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => GetLists(listIds, extended));
		}

		/// <inheritdoc />
		public Task<long> SaveListAsync(string title, IEnumerable<long> sourceIds, long? listId = null, bool? noReposts = null)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>
				SaveList(title, sourceIds, listId, noReposts));
		}

		/// <inheritdoc />
		public Task<bool> DeleteListAsync(long listId)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => DeleteList(listId: listId));
		}

		/// <inheritdoc />
		public Task<bool> UnsubscribeAsync(CommentObjectType type, long itemId, long? ownerId = null)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>
				Unsubscribe(type, itemId, ownerId));
		}

		/// <inheritdoc />
		public Task<NewsSuggestions> GetSuggestedSourcesAsync(long? offset = null
															, long? count = null
															, bool? shuffle = null
															, UsersFields fields = null)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>
				GetSuggestedSources(offset, count, shuffle, fields));
		}
	}
}