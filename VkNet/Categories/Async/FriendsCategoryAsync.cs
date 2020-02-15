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

namespace VkNet.Categories
{
	/// <inheritdoc />
	public partial class FriendsCategory
	{
		/// <inheritdoc />
		public Task<VkCollection<User>> GetAsync(FriendsGetParams @params, bool skipAuthorization = false)
		{
			return TypeHelper.TryInvokeMethodAsync(() =>
				Get(@params, skipAuthorization));
		}

		/// <inheritdoc />
		public Task<ReadOnlyCollection<long>> GetAppUsersAsync()
		{
			return TypeHelper.TryInvokeMethodAsync(GetAppUsers);
		}

		/// <inheritdoc />
		public Task<FriendOnline> GetOnlineAsync(FriendsGetOnlineParams @params)
		{
			return TypeHelper.TryInvokeMethodAsync(() => GetOnline(@params));
		}

		/// <inheritdoc />
		public Task<ReadOnlyCollection<MutualFriend>> GetMutualAsync(FriendsGetMutualParams @params)
		{
			return TypeHelper.TryInvokeMethodAsync(() => GetMutual(@params));
		}

		/// <inheritdoc />
		public Task<ReadOnlyCollection<AreFriendsResult>> AreFriendsAsync(IEnumerable<long> userIds, bool? needSign = null)
		{
			return TypeHelper.TryInvokeMethodAsync(() => AreFriends(userIds, needSign));
		}

		/// <inheritdoc />
		public Task<long> AddListAsync(string name, IEnumerable<long> userIds)
		{
			return TypeHelper.TryInvokeMethodAsync(() => AddList(name, userIds));
		}

		/// <inheritdoc />
		public Task<bool> DeleteListAsync(long listId)
		{
			return TypeHelper.TryInvokeMethodAsync(() => DeleteList(listId));
		}

		/// <inheritdoc />
		public Task<VkCollection<FriendList>> GetListsAsync(long? userId = null, bool? returnSystem = null)
		{
			return TypeHelper.TryInvokeMethodAsync(() => GetLists(userId, returnSystem));
		}

		/// <inheritdoc />
		public Task<bool> EditListAsync(long listId, string name = null, IEnumerable<long> userIds = null,
										IEnumerable<long> addUserIds = null, IEnumerable<long> deleteUserIds = null)
		{
			return TypeHelper.TryInvokeMethodAsync(() =>
				EditList(listId, name, userIds, addUserIds));
		}

		/// <inheritdoc />
		public Task<bool> DeleteAllRequestsAsync()
		{
			return TypeHelper.TryInvokeMethodAsync(DeleteAllRequests);
		}

		/// <inheritdoc />
		public Task<AddFriendStatus> AddAsync(long userId, string text = "", bool? follow = null)
		{
			return TypeHelper.TryInvokeMethodAsync(() => Add(userId, text, follow));
		}

		/// <inheritdoc />
		[Obsolete(ObsoleteText.CaptchaNeeded, true)]
		public Task<AddFriendStatus> AddAsync(long userId, string text = "", bool? follow = null, long? captchaSid = null,
											string captchaKey = null)
		{
			return TypeHelper.TryInvokeMethodAsync(() =>
				Add(userId, text, follow, captchaSid, captchaKey));
		}

		/// <inheritdoc />
		public Task<FriendsDeleteResult> DeleteAsync(long userId)
		{
			return TypeHelper.TryInvokeMethodAsync(() => Delete(userId));
		}

		/// <inheritdoc />
		public Task<bool> EditAsync(long userId, IEnumerable<long> listIds)
		{
			return TypeHelper.TryInvokeMethodAsync(() => Edit(userId, listIds));
		}

		/// <inheritdoc />
		public Task<ReadOnlyCollection<long>> GetRecentAsync(long? count = null)
		{
			return TypeHelper.TryInvokeMethodAsync(() => GetRecent(count));
		}

		/// <inheritdoc />
		public Task<GetRequestsResult> GetRequestsAsync(FriendsGetRequestsParams @params)
		{
			return TypeHelper.TryInvokeMethodAsync(() => GetRequests(@params));
		}

		/// <inheritdoc />
		public Task<VkCollection<FriendsGetRequestsResult>> GetRequestsExtendedAsync(FriendsGetRequestsParams @params)
		{
			return TypeHelper.TryInvokeMethodAsync(() => GetRequestsExtended(@params));
		}

		/// <inheritdoc />
		public Task<VkCollection<User>> GetSuggestionsAsync(FriendsFilter filter = null, long? count = null, long? offset = null,
															UsersFields fields = null, NameCase nameCase = null)
		{
			return TypeHelper.TryInvokeMethodAsync(() =>
				GetSuggestions(filter, count, offset, fields, nameCase));
		}

		/// <inheritdoc />
		public Task<ReadOnlyCollection<User>> GetByPhonesAsync(IEnumerable<string> phones, ProfileFields fields)
		{
			return TypeHelper.TryInvokeMethodAsync(() => GetByPhones(phones, fields));
		}

		/// <inheritdoc />
		public Task<VkCollection<User>> SearchAsync(FriendsSearchParams @params)
		{
			return TypeHelper.TryInvokeMethodAsync(() => Search(@params));
		}
	}
}