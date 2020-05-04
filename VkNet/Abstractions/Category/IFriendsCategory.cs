using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using JetBrains.Annotations;
using VkNet.Enums;
using VkNet.Enums.Filters;
using VkNet.Enums.SafetyEnums;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkNet.Abstractions
{
	/// <inheritdoc cref="IFriendsCategoryAsync" />
	public interface IFriendsCategory : IFriendsCategoryAsync
	{
		/// <inheritdoc cref="IFriendsCategoryAsync.GetAsync" />
		VkCollection<User> Get(FriendsGetParams @params, bool skipAuthorization = false);

		/// <inheritdoc cref="IFriendsCategoryAsync.GetAppUsersAsync" />
		ReadOnlyCollection<long> GetAppUsers();

		/// <inheritdoc cref="IFriendsCategoryAsync.GetOnlineAsync" />
		FriendOnline GetOnline(FriendsGetOnlineParams @params);

		/// <inheritdoc cref="IFriendsCategoryAsync.GetMutualAsync" />
		ReadOnlyCollection<MutualFriend> GetMutual(FriendsGetMutualParams @params);

		/// <inheritdoc cref="IFriendsCategoryAsync.AreFriendsAsync" />
		ReadOnlyCollection<AreFriendsResult> AreFriends([NotNull] IEnumerable<long> userIds, bool? needSign = null);

		/// <inheritdoc cref="IFriendsCategoryAsync.AddListAsync" />
		long AddList(string name, IEnumerable<long> userIds);

		/// <inheritdoc cref="IFriendsCategoryAsync.DeleteListAsync" />
		bool DeleteList(long listId);

		/// <inheritdoc cref="IFriendsCategoryAsync.GetListsAsync" />
		VkCollection<FriendList> GetLists(long? userId = null, bool? returnSystem = null);

		/// <inheritdoc cref="IFriendsCategoryAsync.EditListAsync" />
		bool EditList(long listId, string name = null, IEnumerable<long> userIds = null, IEnumerable<long> addUserIds = null,
					IEnumerable<long> deleteUserIds = null);

		/// <inheritdoc cref="IFriendsCategoryAsync.DeleteAllRequestsAsync" />
		bool DeleteAllRequests();

		/// <inheritdoc cref="IFriendsCategoryAsync.AddAsync(long, string, bool?)" />
		AddFriendStatus Add(long userId, string text = "", bool? follow = null);

		/// <inheritdoc cref="IFriendsCategoryAsync.AddAsync(long, string, bool?,long?,string)" />
		[Obsolete(ObsoleteText.CaptchaNeeded, true)]
		AddFriendStatus Add(long userId, string text = "", bool? follow = null, long? captchaSid = null, string captchaKey = null);

		/// <inheritdoc cref="IFriendsCategoryAsync.DeleteAsync" />
		FriendsDeleteResult Delete(long userId);

		/// <inheritdoc cref="IFriendsCategoryAsync.EditAsync" />
		bool Edit(long userId, IEnumerable<long> listIds);

		/// <inheritdoc cref="IFriendsCategoryAsync.GetRecentAsync" />
		ReadOnlyCollection<long> GetRecent(long? count = null);

		/// <inheritdoc cref="IFriendsCategoryAsync.GetRequestsAsync" />
		GetRequestsResult GetRequests(FriendsGetRequestsParams @params);

		/// <inheritdoc cref="IFriendsCategoryAsync.GetRequestsExtendedAsync" />
		VkCollection<FriendsGetRequestsResult> GetRequestsExtended(FriendsGetRequestsParams @params);

		/// <inheritdoc cref="IFriendsCategoryAsync.GetSuggestionsAsync" />
		VkCollection<User> GetSuggestions(FriendsFilter filter = null, long? count = null, long? offset = null, UsersFields fields = null,
										NameCase nameCase = null);

		/// <inheritdoc cref="IFriendsCategoryAsync.GetByPhonesAsync" />
		ReadOnlyCollection<User> GetByPhones(IEnumerable<string> phones, ProfileFields fields);

		/// <inheritdoc cref="IFriendsCategoryAsync.SearchAsync" />
		VkCollection<User> Search(FriendsSearchParams @params);
	}
}