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
        public async Task<VkCollection<User>> GetAsync(FriendsGetParams @params, bool skipAuthorization = false)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Friends.Get(@params, skipAuthorization));
        }

        /// <inheritdoc />
        public async Task<ReadOnlyCollection<long>> GetAppUsersAsync()
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Friends.GetAppUsers());
        }

        /// <inheritdoc />
        public async Task<FriendOnline> GetOnlineAsync(FriendsGetOnlineParams @params)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Friends.GetOnline(@params));
        }

        /// <inheritdoc />
        public async Task<ReadOnlyCollection<long>> GetMutualAsync(FriendsGetMutualParams @params)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Friends.GetMutual(@params));
        }

        /// <inheritdoc />
        public async Task<ReadOnlyCollection<AreFriendsResult>> AreFriendsAsync(IEnumerable<long> userIds,
            bool? needSign = null)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Friends.AreFriends(userIds, needSign));
        }

        /// <inheritdoc />
        public async Task<long> AddListAsync(string name, IEnumerable<long> userIds)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Friends.AddList(name, userIds));
        }

        /// <inheritdoc />
        public async Task<bool> DeleteListAsync(long listId)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Friends.DeleteList(listId));
        }

        /// <inheritdoc />
        public async Task<VkCollection<FriendList>> GetListsAsync(long? userId = null, bool? returnSystem = null)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Friends.GetLists(userId, returnSystem));
        }

        /// <inheritdoc />
        public async Task<bool> EditListAsync(long listId, string name = null, IEnumerable<long> userIds = null,
            IEnumerable<long> addUserIds = null,
            IEnumerable<long> deleteUserIds = null)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Friends.EditList(listId, name, userIds, addUserIds));
        }

        /// <inheritdoc />
        public async Task<bool> DeleteAllRequestsAsync()
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Friends.DeleteAllRequests());
        }

        /// <inheritdoc />
        public async Task<AddFriendStatus> AddAsync(long userId, string text = "", bool? follow = null,
            long? captchaSid = null, string captchaKey = null)
        {
            return await TypeHelper.TryInvokeMethodAsync(() =>
                _vk.Friends.Add(userId, text, follow, captchaSid, captchaKey));
        }

        /// <inheritdoc />
        public async Task<FriendsDeleteResult> DeleteAsync(long userId)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Friends.Delete(userId));
        }

        /// <inheritdoc />
        public async Task<bool> EditAsync(long userId, IEnumerable<long> listIds)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Friends.Edit(userId, listIds));
        }

        /// <inheritdoc />
        public async Task<ReadOnlyCollection<long>> GetRecentAsync(long? count = null)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Friends.GetRecent(count));
        }

        /// <inheritdoc />
        public async Task<GetRequestsResult> GetRequestsAsync(FriendsGetRequestsParams @params)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Friends.GetRequests(@params));
        }

        /// <inheritdoc />
        public async Task<VkCollection<FriendsGetRequestsResult>> GetRequestsExtendedAsync(
            FriendsGetRequestsParams @params)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Friends.GetRequestsExtended(@params));
        }

        /// <inheritdoc />
        public async Task<VkCollection<User>> GetSuggestionsAsync(FriendsFilter filter = null, long? count = null,
            long? offset = null,
            UsersFields fields = null, NameCase nameCase = null)
        {
            return await TypeHelper.TryInvokeMethodAsync(() =>
                _vk.Friends.GetSuggestions(filter, count, offset, fields, nameCase));
        }

        /// <inheritdoc />
        public async Task<ReadOnlyCollection<User>> GetByPhonesAsync(IEnumerable<string> phones, ProfileFields fields)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Friends.GetByPhones(phones, fields));
        }

        /// <inheritdoc />
        public async Task<VkCollection<User>> SearchAsync(FriendsSearchParams @params)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Friends.Search(@params));
        }
    }
}