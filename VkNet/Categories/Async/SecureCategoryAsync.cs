using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using VkNet.Utils;

namespace VkNet.Categories
{
	/// <inheritdoc/>
    public partial class SecureCategory
    {
        /// <inheritdoc/>
        public Task<object> AddAppEventAsync(ulong userId, ulong activityId, ulong? value = null)
        {
            return TypeHelper.TryInvokeMethodAsync(() => AddAppEvent(userId, activityId, value));
        }

        /// <inheritdoc/>
        public Task<object> CheckTokenAsync(string token, string ip)
        {
            return TypeHelper.TryInvokeMethodAsync(() => CheckToken(token, ip));
        }

        /// <inheritdoc/>
        public Task<object> GetAppBalanceAsync()
        {
            return TypeHelper.TryInvokeMethodAsync(() => GetAppBalance());
        }

        /// <inheritdoc/>
        public Task<IEnumerable<object>> GetSmsHistoryAsync(ulong? userId = null, ulong? dateFrom = null, ulong? dateTo = null, ulong? limit = null)
        {
            return TypeHelper.TryInvokeMethodAsync(() => GetSmsHistory(userId, dateFrom, dateTo, limit));
        }

        /// <inheritdoc/>
        public Task<IEnumerable<object>> GetTransactionsHistoryAsync()
        {
            return TypeHelper.TryInvokeMethodAsync(() => GetTransactionsHistory());
        }

        /// <inheritdoc/>
        public Task<object> GetUserLevelAsync(IEnumerable<long> userIds)
        {
            return TypeHelper.TryInvokeMethodAsync(() => GetUserLevel(userIds));
        }

        /// <inheritdoc/>
        public Task<ReadOnlyCollection<ulong>> SendNotificationAsync(string message, IEnumerable<ulong> userIds = null)
        {
            return TypeHelper.TryInvokeMethodAsync(() => SendNotification(message, userIds));
        }

        /// <inheritdoc/>
        public Task<bool> SendSmsNotificationAsync(ulong userId, string message)
        {
            return TypeHelper.TryInvokeMethodAsync(() => SendSmsNotification(userId, message));
        }

        /// <inheritdoc/>
        public Task<bool> SetCounterAsync(IEnumerable<string> counters, ulong? userId = null, long? counter = null, bool? increment = null)
        {
            return TypeHelper.TryInvokeMethodAsync(() => SetCounter(counters, userId, counter, increment));
        }

        /// <inheritdoc/>
        public Task<bool> SetUserLevelAsync(IEnumerable<string> levels, ulong? userId = null, ulong? level = null)
        {
            return TypeHelper.TryInvokeMethodAsync(() => SetUserLevel(levels, userId, level));
        }
    }
}