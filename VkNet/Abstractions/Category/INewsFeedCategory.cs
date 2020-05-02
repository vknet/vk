using System;
using System.Collections.Generic;
using VkNet.Enums.Filters;
using VkNet.Enums.SafetyEnums;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkNet.Abstractions
{
	/// <inheritdoc cref="INewsFeedCategoryAsync"/>
	public interface INewsFeedCategory : INewsFeedCategoryAsync
	{
		/// <inheritdoc cref="INewsFeedCategoryAsync.GetAsync"/>
		NewsFeed Get(NewsFeedGetParams @params);

		/// <inheritdoc cref="INewsFeedCategoryAsync.GetRecommendedAsync"/>
		NewsFeed GetRecommended(NewsFeedGetRecommendedParams @params);

		/// <inheritdoc cref="INewsFeedCategoryAsync.GetCommentsAsync"/>
		NewsFeed GetComments(NewsFeedGetCommentsParams @params);

		/// <inheritdoc cref="INewsFeedCategoryAsync.GetMentionsAsync"/>
		VkCollection<Mention> GetMentions(long? ownerId = null
										, DateTime? startTime = null
										, DateTime? endTime = null
										, long? offset = null
										, long? count = null);

		/// <inheritdoc cref="INewsFeedCategoryAsync.GetBannedAsync"/>
		NewsBannedList GetBanned();

		/// <inheritdoc cref="INewsFeedCategoryAsync.GetBannedExAsync"/>
		NewsBannedExList GetBannedEx(UsersFields fields = null, NameCase nameCase = null);

		/// <inheritdoc cref="INewsFeedCategoryAsync.AddBanAsync"/>
		bool AddBan(IEnumerable<long> userIds, IEnumerable<long> groupIds);

		/// <inheritdoc cref="INewsFeedCategoryAsync.DeleteBanAsync"/>
		bool DeleteBan(IEnumerable<long> userIds, IEnumerable<long> groupIds);

		/// <inheritdoc cref="INewsFeedCategoryAsync.IgnoreItemAsync"/>
		bool IgnoreItem(NewsObjectTypes type, long ownerId, long itemId);

		/// <inheritdoc cref="INewsFeedCategoryAsync.UnignoreItemAsync"/>
		bool UnignoreItem(NewsObjectTypes type, long ownerId, long itemId);

		/// <inheritdoc cref="INewsFeedCategoryAsync.SearchAsync"/>
		NewsSearchResult Search(NewsFeedSearchParams @params);

		/// <inheritdoc cref="INewsFeedCategoryAsync.GetListsAsync"/>
		VkCollection<NewsUserListItem> GetLists(IEnumerable<long> listIds, bool? extended = null);

		/// <inheritdoc cref="INewsFeedCategoryAsync.SaveListAsync"/>
		long SaveList(string title, IEnumerable<long> sourceIds, long? listId = null, bool? noReposts = null);

		/// <inheritdoc cref="INewsFeedCategoryAsync.DeleteListAsync"/>
		bool DeleteList(long listId);

		/// <inheritdoc cref="INewsFeedCategoryAsync.UnsubscribeAsync"/>
		bool Unsubscribe(CommentObjectType type, long itemId, long? ownerId = null);

		/// <inheritdoc cref="INewsFeedCategoryAsync.GetSuggestedSourcesAsync"/>
		NewsSuggestions GetSuggestedSources(long? offset = null, long? count = null, bool? shuffle = null, UsersFields fields = null);
	}
}