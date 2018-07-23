using System.Collections.Generic;
using System.Threading.Tasks;
using VkNet.Utils;

namespace VkNet.Categories
{
	/// <inheritdoc/>
    public partial class OrdersCategory
    {
        /// <inheritdoc/>
        public async Task<bool> CancelSubscriptionAsync(ulong userId, ulong subscriptionId, bool? pendingCancel = null)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => CancelSubscription(userId, subscriptionId, pendingCancel));
        }

        /// <inheritdoc/>
        public async Task<object> ChangeStateAsync(ulong orderId, string action, ulong? appOrderId = null, bool? testMode = null)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => ChangeState(orderId, action, appOrderId, testMode));
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<object>> GetAsync(ulong? offset = null, ulong? count = null, bool? testMode = null)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => Get(offset, count, testMode));
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<object>> GetAmountAsync(ulong userId, IEnumerable<string> votes)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => GetAmount(userId, votes));
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<object>> GetByIdAsync(ulong? orderId = null, IEnumerable<ulong> orderIds = null, bool? testMode = null)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => GetById(orderId, orderIds, testMode));
        }

        /// <inheritdoc/>
        public async Task<object> GetUserSubscriptionByIdAsync(ulong userId, ulong subscriptionId)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => GetUserSubscriptionById(userId, subscriptionId));
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<object>> GetUserSubscriptionsAsync(ulong userId)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => GetUserSubscriptions(userId));
        }

        /// <inheritdoc/>
        public async Task<bool> UpdateSubscriptionAsync(ulong userId, ulong subscriptionId, ulong price)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => UpdateSubscription(userId, subscriptionId, price));
        }
    }
}