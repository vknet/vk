using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using VkNet.Enums;
using VkNet.Enums.Filters;
using VkNet.Enums.StringEnums;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Categories;

/// <inheritdoc />
public partial class FriendsCategory
{
	/// <inheritdoc />
	public Task<VkCollection<User>> GetAsync(FriendsGetParams @params,
											bool skipAuthorization = false,
											CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Get(@params, skipAuthorization), token);

	/// <inheritdoc />
	public Task<ReadOnlyCollection<long>> GetAppUsersAsync(CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(GetAppUsers, token);

	/// <inheritdoc />
	public Task<FriendOnline> GetOnlineAsync(FriendsGetOnlineParams @params,
											CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetOnline(@params), token);

	/// <inheritdoc />
	public Task<ReadOnlyCollection<MutualFriend>> GetMutualAsync(FriendsGetMutualParams @params,
																CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetMutual(@params), token);

	/// <inheritdoc />
	public Task<ReadOnlyCollection<AreFriendsResult>> AreFriendsAsync(IEnumerable<long> userIds,
																	bool? needSign = null,
																	CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			AreFriends(userIds, needSign), token);

	/// <inheritdoc />
	public Task<long> AddListAsync(string name,
									IEnumerable<long> userIds,
									CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			AddList(name, userIds), token);

	/// <inheritdoc />
	public Task<bool> DeleteListAsync(long listId,
									CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			DeleteList(listId), token);

	/// <inheritdoc />
	public Task<VkCollection<FriendList>> GetListsAsync(long? userId = null,
														bool? returnSystem = null,
														CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetLists(userId, returnSystem), token);

	/// <inheritdoc />
	public Task<bool> EditListAsync(long listId,
									string name = null,
									IEnumerable<long> userIds = null,
									IEnumerable<long> addUserIds = null,
									IEnumerable<long> deleteUserIds = null,
									CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			EditList(listId, name, userIds, addUserIds), token);

	/// <inheritdoc />
	public Task<bool> DeleteAllRequestsAsync(CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(DeleteAllRequests, token);

	/// <inheritdoc />
	public Task<AddFriendStatus> AddAsync(long userId,
										string text = "",
										bool? follow = null,
										CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Add(userId, text, follow), token);

	/// <inheritdoc />
	public Task<FriendsDeleteResult> DeleteAsync(long userId,
												CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Delete(userId), token);

	/// <inheritdoc />
	public Task<bool> EditAsync(long userId,
								IEnumerable<long> listIds,
								CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Edit(userId, listIds), token);

	/// <inheritdoc />
	public Task<ReadOnlyCollection<long>> GetRecentAsync(long? count = null,
														CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetRecent(count), token);

	/// <inheritdoc />
	public Task<GetRequestsResult> GetRequestsAsync(FriendsGetRequestsParams @params,
													CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetRequests(@params), token);

	/// <inheritdoc />
	public Task<VkCollection<FriendsGetRequestsResult>> GetRequestsExtendedAsync(FriendsGetRequestsParams @params,
																				CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetRequestsExtended(@params), token);

	/// <inheritdoc />
	public Task<VkCollection<User>> GetSuggestionsAsync(FriendsFilter? filter = null,
														long? count = null,
														long? offset = null,
														UsersFields fields = null,
														NameCase? nameCase = null,
														CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetSuggestions(filter, count, offset, fields, nameCase), token);

	/// <inheritdoc />
	public Task<ReadOnlyCollection<User>> GetByPhonesAsync(IEnumerable<string> phones,
															ProfileFields fields,
															CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetByPhones(phones, fields), token);

	/// <inheritdoc />
	public Task<VkCollection<User>> SearchAsync(FriendsSearchParams @params,
												CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Search(@params), token);
}