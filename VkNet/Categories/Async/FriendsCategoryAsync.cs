using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
	public Task<VkCollection<User>> GetAsync(FriendsGetParams @params, bool skipAuthorization = false) => TypeHelper.TryInvokeMethodAsync(
		() =>
			Get(@params, skipAuthorization));

	/// <inheritdoc />
	public Task<ReadOnlyCollection<long>> GetAppUsersAsync() => TypeHelper.TryInvokeMethodAsync(GetAppUsers);

	/// <inheritdoc />
	public Task<FriendOnline> GetOnlineAsync(FriendsGetOnlineParams @params) => TypeHelper.TryInvokeMethodAsync(() => GetOnline(@params));

	/// <inheritdoc />
	public Task<ReadOnlyCollection<MutualFriend>> GetMutualAsync(FriendsGetMutualParams @params) =>
		TypeHelper.TryInvokeMethodAsync(() => GetMutual(@params));

	/// <inheritdoc />
	public Task<ReadOnlyCollection<AreFriendsResult>> AreFriendsAsync(IEnumerable<long> userIds, bool? needSign = null) =>
		TypeHelper.TryInvokeMethodAsync(() => AreFriends(userIds, needSign));

	/// <inheritdoc />
	public Task<long> AddListAsync(string name, IEnumerable<long> userIds) => TypeHelper.TryInvokeMethodAsync(() => AddList(name, userIds));

	/// <inheritdoc />
	public Task<bool> DeleteListAsync(long listId) => TypeHelper.TryInvokeMethodAsync(() => DeleteList(listId));

	/// <inheritdoc />
	public Task<VkCollection<FriendList>> GetListsAsync(long? userId = null, bool? returnSystem = null) =>
		TypeHelper.TryInvokeMethodAsync(() => GetLists(userId, returnSystem));

	/// <inheritdoc />
	public Task<bool> EditListAsync(long listId, string name = null, IEnumerable<long> userIds = null,
									IEnumerable<long> addUserIds = null, IEnumerable<long> deleteUserIds = null) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			EditList(listId, name, userIds, addUserIds));

	/// <inheritdoc />
	public Task<bool> DeleteAllRequestsAsync() => TypeHelper.TryInvokeMethodAsync(DeleteAllRequests);

	/// <inheritdoc />
	public Task<AddFriendStatus> AddAsync(long userId, string text = "", bool? follow = null) =>
		TypeHelper.TryInvokeMethodAsync(() => Add(userId, text, follow));

	/// <inheritdoc />
	[Obsolete(ObsoleteText.CaptchaNeeded, true)]
	public Task<AddFriendStatus> AddAsync(long userId, string text = "", bool? follow = null, long? captchaSid = null,
										string captchaKey = null) => TypeHelper.TryInvokeMethodAsync(() =>
		Add(userId, text, follow, captchaSid, captchaKey));

	/// <inheritdoc />
	public Task<FriendsDeleteResult> DeleteAsync(long userId) => TypeHelper.TryInvokeMethodAsync(() => Delete(userId));

	/// <inheritdoc />
	public Task<bool> EditAsync(long userId, IEnumerable<long> listIds) => TypeHelper.TryInvokeMethodAsync(() => Edit(userId, listIds));

	/// <inheritdoc />
	public Task<ReadOnlyCollection<long>> GetRecentAsync(long? count = null) => TypeHelper.TryInvokeMethodAsync(() => GetRecent(count));

	/// <inheritdoc />
	public Task<GetRequestsResult> GetRequestsAsync(FriendsGetRequestsParams @params) =>
		TypeHelper.TryInvokeMethodAsync(() => GetRequests(@params));

	/// <inheritdoc />
	public Task<VkCollection<FriendsGetRequestsResult>> GetRequestsExtendedAsync(FriendsGetRequestsParams @params) =>
		TypeHelper.TryInvokeMethodAsync(() => GetRequestsExtended(@params));

	/// <inheritdoc />
	public Task<VkCollection<User>> GetSuggestionsAsync(FriendsFilter? filter = null, long? count = null, long? offset = null,
														UsersFields fields = null, NameCase? nameCase = null) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetSuggestions(filter, count, offset, fields, nameCase));

	/// <inheritdoc />
	public Task<ReadOnlyCollection<User>> GetByPhonesAsync(IEnumerable<string> phones, ProfileFields fields) =>
		TypeHelper.TryInvokeMethodAsync(() => GetByPhones(phones, fields));

	/// <inheritdoc />
	public Task<VkCollection<User>> SearchAsync(FriendsSearchParams @params) => TypeHelper.TryInvokeMethodAsync(() => Search(@params));
}