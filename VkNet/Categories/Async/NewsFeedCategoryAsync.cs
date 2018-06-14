using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
		public async Task<NewsFeed> GetAsync(NewsFeedGetParams @params)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.NewsFeed.Get(@params: @params));
		}

		/// <inheritdoc />
		public async Task<NewsFeed> GetRecommendedAsync(NewsFeedGetRecommendedParams @params)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.NewsFeed.GetRecommended(@params: @params));
		}

		/// <inheritdoc />
		public async Task<NewsFeed> GetCommentsAsync(NewsFeedGetCommentsParams @params)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.NewsFeed.GetComments(@params: @params));
		}

		/// <inheritdoc />
		public async Task<VkCollection<Mention>> GetMentionsAsync(long? ownerId = null
																, DateTime? startTime = null
																, DateTime? endTime = null
																, long? offset = null
																, long? count = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.NewsFeed.GetMentions(ownerId: ownerId, startTime: startTime, endTime: endTime, offset: offset));
		}

		/// <inheritdoc />
		public async Task<NewsBannedList> GetBannedAsync()
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.NewsFeed.GetBanned());
		}

		/// <inheritdoc />
		public async Task<NewsBannedExList> GetBannedExAsync(UsersFields fields = null, NameCase nameCase = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.NewsFeed.GetBannedEx(fields: fields, nameCase: nameCase));
		}

		/// <inheritdoc />
		public async Task<bool> AddBanAsync(IEnumerable<long> userIds, IEnumerable<long> groupIds)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.NewsFeed.AddBan(userIds: userIds, groupIds: groupIds));
		}

		/// <inheritdoc />
		public async Task<bool> DeleteBanAsync(IEnumerable<long> userIds, IEnumerable<long> groupIds)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.NewsFeed.DeleteBan(userIds: userIds, groupIds: groupIds));
		}

		/// <inheritdoc />
		public async Task<bool> IgnoreItemAsync(NewsObjectTypes type, long ownerId, long itemId)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.NewsFeed.IgnoreItem(type: type, ownerId: ownerId, itemId: itemId));
		}

		/// <inheritdoc />
		public async Task<bool> UnignoreItemAsync(NewsObjectTypes type, long ownerId, long itemId)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.NewsFeed.UnignoreItem(type: type, ownerId: ownerId, itemId: itemId));
		}

		/// <inheritdoc />
		public async Task<ReadOnlyCollection<NewsSearchResult>> SearchAsync(NewsFeedSearchParams @params)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.NewsFeed.Search(@params: @params));
		}

		/// <inheritdoc />
		public async Task<VkCollection<NewsUserListItem>> GetListsAsync(IEnumerable<long> listIds, bool? extended = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.NewsFeed.GetLists(listIds: listIds, extended: extended));
		}

		/// <inheritdoc />
		public async Task<long> SaveListAsync(string title, IEnumerable<long> sourceIds, long? listId = null, bool? noReposts = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.NewsFeed.SaveList(title: title, sourceIds: sourceIds, listId: listId, noReposts: noReposts));
		}

		/// <inheritdoc />
		public async Task<bool> DeleteListAsync(long listId)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.NewsFeed.DeleteList(listId: listId));
		}

		/// <inheritdoc />
		public async Task<bool> UnsubscribeAsync(CommentObjectType type, long itemId, long? ownerId = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.NewsFeed.Unsubscribe(type: type, itemId: itemId, ownerId: ownerId));
		}

		/// <inheritdoc />
		public async Task<NewsSuggestions> GetSuggestedSourcesAsync(long? offset = null
																	, long? count = null
																	, bool? shuffle = null
																	, UsersFields fields = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.NewsFeed.GetSuggestedSources(offset: offset, count: count, shuffle: shuffle, fields: fields));
		}
	}
}