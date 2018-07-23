using System.Collections.Generic;
using System.Threading.Tasks;
using VkNet.Utils;

namespace VkNet.Categories
{
	/// <inheritdoc/>
    public partial class SecureCategory
    {
        /// <inheritdoc/>
        public async Task<object> AddAppEventAsync(ulong userId, ulong activityId, ulong? value = null)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => AddAppEvent(userId, activityId, value));
        }

        /// <inheritdoc/>
        public async Task<object> CheckTokenAsync(string token, string ip)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => CheckToken(token, ip));
        }

        /// <inheritdoc/>
        public async Task<object> GetAppBalanceAsync()
        {
            return await TypeHelper.TryInvokeMethodAsync(() => GetAppBalance());
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<object>> GetSmsHistoryAsync(ulong? userId = null, ulong? dateFrom = null, ulong? dateTo = null, ulong? limit = null)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => GetSMSHistory(userId, dateFrom, dateTo, limit));
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<object>> GetTransactionsHistoryAsync()
        {
            return await TypeHelper.TryInvokeMethodAsync(() => GetTransactionsHistory());
        }

        /// <inheritdoc/>
        public async Task<object> GetUserLevelAsync(IEnumerable<long> userIds)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => GetUserLevel(userIds));
        }

        /// <inheritdoc/>
        public async Task<object> SendNotificationAsync(string message, IEnumerable<ulong> userIds = null, ulong? userId = null)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => SendNotification(message, userIds, userId));
        }

        /// <inheritdoc/>
        public async Task<bool> SendSMSNotificationAsync(ulong userId, string message)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => SendSMSNotification(userId, message));
        }

        /// <inheritdoc/>
        public async Task<bool> SetCounterAsync(IEnumerable<string> counters, ulong? userId = null, long? counter = null, bool? increment = null)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => SetCounter(counters, userId, counter, increment));
        }

        /// <inheritdoc/>
        public async Task<bool> SetUserLevelAsync(IEnumerable<string> levels, ulong? userId = null, ulong? level = null)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => SetUserLevel(levels, userId, level));
        }
    }
}