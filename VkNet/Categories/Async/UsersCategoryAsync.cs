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
    public partial class UsersCategory
    {
        /// <inheritdoc />
        public async Task<VkCollection<User>> SearchAsync(UserSearchParams @params)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Users.Search(@params));
        }

        /// <inheritdoc />
        public async Task<bool> IsAppUserAsync(long? userId)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Users.IsAppUser(userId));
        }

        /// <inheritdoc />
        public async Task<ReadOnlyCollection<User>> GetAsync(IEnumerable<long> userIds, ProfileFields fields = null,
            NameCase nameCase = null, bool skipAuthorization = false)
        {
            return await TypeHelper.TryInvokeMethodAsync(() =>
                _vk.Users.Get(userIds, fields, nameCase, skipAuthorization));
        }

        /// <inheritdoc />
        public async Task<ReadOnlyCollection<User>> GetAsync(IEnumerable<string> screenNames,
            ProfileFields fields = null, NameCase nameCase = null, bool skipAuthorization = false)
        {
            return await TypeHelper.TryInvokeMethodAsync(() =>
                _vk.Users.Get(screenNames, fields, nameCase, skipAuthorization));
        }

        /// <inheritdoc />
        public async Task<VkCollection<Group>> GetSubscriptionsAsync(long? userId = null, int? count = null,
            int? offset = null, GroupsFields fields = null, bool skipAuthorization = false)
        {
            return await TypeHelper.TryInvokeMethodAsync(() =>
                _vk.Users.GetSubscriptions(userId, count, offset, fields, skipAuthorization));
        }

        /// <inheritdoc />
        public async Task<VkCollection<User>> GetFollowersAsync(long? userId = null, int? count = null,
            int? offset = null, ProfileFields fields = null, NameCase nameCase = null, bool skipAuthorization = false)
        {
            return await TypeHelper.TryInvokeMethodAsync(() =>
                _vk.Users.GetFollowers(userId, count, offset, fields, nameCase, skipAuthorization));
        }

        /// <inheritdoc />
        public async Task<bool> ReportAsync(long userId, ReportType type, string comment = "")
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Users.Report(userId, type, comment));
        }

        /// <inheritdoc />
        public async Task<VkCollection<User>> GetNearbyAsync(UsersGetNearbyParams @params)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Users.GetNearby(@params));
        }
    }
}