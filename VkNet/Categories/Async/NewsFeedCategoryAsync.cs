using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VkNet.Enums.Filters;
using VkNet.Enums.SafetyEnums;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkNet.Categories;

/// <inheritdoc />
public partial class NewsFeedCategory
{
	/// <inheritdoc />
	public Task<NewsFeed> GetAsync(NewsFeedGetParams @params,
									CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Get(@params));

	/// <inheritdoc />
	public Task<NewsFeed> GetRecommendedAsync(NewsFeedGetRecommendedParams @params,
											CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetRecommended(@params));

	/// <inheritdoc />
	public Task<NewsFeed> GetCommentsAsync(NewsFeedGetCommentsParams @params,
											CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetComments(@params));

	/// <inheritdoc />
	public Task<VkCollection<Mention>> GetMentionsAsync(long? ownerId = null,
														DateTime? startTime = null,
														DateTime? endTime = null,
														long? offset = null,
														long? count = null,
														CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetMentions(ownerId, startTime, endTime, offset));

	/// <inheritdoc />
	public Task<NewsBannedList> GetBannedAsync(CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(GetBanned);

	/// <inheritdoc />
	public Task<NewsBannedExList> GetBannedExAsync(UsersFields fields = null,
													NameCase? nameCase = null,
													CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetBannedEx(fields, nameCase));

	/// <inheritdoc />
	public Task<bool> AddBanAsync(IEnumerable<long> userIds,
								IEnumerable<long> groupIds,
								CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			AddBan(userIds, groupIds));

	/// <inheritdoc />
	public Task<bool> DeleteBanAsync(IEnumerable<long> userIds,
									IEnumerable<long> groupIds,
									CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			DeleteBan(userIds, groupIds));

	/// <inheritdoc />
	public Task<bool> IgnoreItemAsync(NewsObjectTypes type,
									long ownerId,
									long itemId,
									CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			IgnoreItem(type, ownerId, itemId));

	/// <inheritdoc />
	public Task<bool> UnignoreItemAsync(NewsObjectTypes type,
										long ownerId,
										long itemId,
										CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			UnignoreItem(type, ownerId, itemId));

	/// <inheritdoc />
	public Task<NewsSearchResult> SearchAsync(NewsFeedSearchParams @params,
											CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Search(@params));

	/// <inheritdoc />
	public Task<VkCollection<NewsUserListItem>> GetListsAsync(IEnumerable<long> listIds,
															bool? extended = null,
															CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetLists(listIds, extended));

	/// <inheritdoc />
	public Task<long> SaveListAsync(string title,
									IEnumerable<long> sourceIds,
									long? listId = null,
									bool? noReposts = null,
									CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			SaveList(title, sourceIds, listId, noReposts));

	/// <inheritdoc />
	public Task<bool> DeleteListAsync(long listId,
									CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			DeleteList(listId));

	/// <inheritdoc />
	public Task<bool> UnsubscribeAsync(CommentObjectType type,
										long itemId,
										long? ownerId = null,
										CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Unsubscribe(type, itemId, ownerId));

	/// <inheritdoc />
	public Task<NewsSuggestions> GetSuggestedSourcesAsync(long? offset = null,
														long? count = null,
														bool? shuffle = null,
														UsersFields fields = null,
														CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetSuggestedSources(offset, count, shuffle, fields));
}