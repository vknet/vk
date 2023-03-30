using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using VkNet.Enums;
using VkNet.Enums.Filters;
using VkNet.Enums.SafetyEnums;
using VkNet.Model;
using VkNet.Model.RequestParams;
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
			Get(@params, skipAuthorization));

	/// <inheritdoc />
	public Task<ReadOnlyCollection<long>> GetAppUsersAsync(CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(GetAppUsers);

	/// <inheritdoc />
	public Task<FriendOnline> GetOnlineAsync(FriendsGetOnlineParams @params,
											CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetOnline(@params));

	/// <inheritdoc />
	public Task<ReadOnlyCollection<MutualFriend>> GetMutualAsync(FriendsGetMutualParams @params,
																CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetMutual(@params));

	/// <inheritdoc />
	public Task<ReadOnlyCollection<AreFriendsResult>> AreFriendsAsync(IEnumerable<long> userIds,
																	bool? needSign = null,
																	CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			AreFriends(userIds, needSign));

	/// <inheritdoc />
	public Task<long> AddListAsync(string name,
									IEnumerable<long> userIds,
									CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			AddList(name, userIds));

	/// <inheritdoc />
	public Task<bool> DeleteListAsync(long listId,
									CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			DeleteList(listId));

	/// <inheritdoc />
	public Task<VkCollection<FriendList>> GetListsAsync(long? userId = null,
														bool? returnSystem = null,
														CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetLists(userId, returnSystem));

	/// <inheritdoc />
	public Task<bool> EditListAsync(long listId,
									string name = null,
									IEnumerable<long> userIds = null,
									IEnumerable<long> addUserIds = null,
									IEnumerable<long> deleteUserIds = null,
									CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			EditList(listId, name, userIds, addUserIds));

	/// <inheritdoc />
	public Task<bool> DeleteAllRequestsAsync(CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(DeleteAllRequests);

	/// <inheritdoc />
	public Task<AddFriendStatus> AddAsync(long userId,
										string text = "",
										bool? follow = null,
										CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Add(userId, text, follow));

	/// <inheritdoc />
	[Obsolete(ObsoleteText.CaptchaNeeded, true)]
	public Task<AddFriendStatus> AddAsync(long userId,
										string text = "",
										bool? follow = null,
										long? captchaSid = null,
										string captchaKey = null,
										CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Add(userId, text, follow, captchaSid, captchaKey));

	/// <inheritdoc />
	public Task<FriendsDeleteResult> DeleteAsync(long userId,
												CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Delete(userId));

	/// <inheritdoc />
	public Task<bool> EditAsync(long userId,
								IEnumerable<long> listIds,
								CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Edit(userId, listIds));

	/// <inheritdoc />
	public Task<ReadOnlyCollection<long>> GetRecentAsync(long? count = null,
														CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetRecent(count));

	/// <inheritdoc />
	public Task<GetRequestsResult> GetRequestsAsync(FriendsGetRequestsParams @params,
													CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetRequests(@params));

	/// <inheritdoc />
	public Task<VkCollection<FriendsGetRequestsResult>> GetRequestsExtendedAsync(FriendsGetRequestsParams @params,
																				CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetRequestsExtended(@params));

	/// <inheritdoc />
	public Task<VkCollection<User>> GetSuggestionsAsync(FriendsFilter? filter = null,
														long? count = null,
														long? offset = null,
														UsersFields fields = null,
														NameCase? nameCase = null,
														CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetSuggestions(filter, count, offset, fields, nameCase));

	/// <inheritdoc />
	public Task<ReadOnlyCollection<User>> GetByPhonesAsync(IEnumerable<string> phones,
															ProfileFields fields,
															CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetByPhones(phones, fields));

	/// <inheritdoc />
	public Task<VkCollection<User>> SearchAsync(FriendsSearchParams @params,
												CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Search(@params));
}