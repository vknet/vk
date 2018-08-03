using System.Collections.Generic;
using VkNet.Abstractions;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Categories
{
	/// <inheritdoc/>
    public partial class OrdersCategory : IOrdersCategory
    {
        /// <summary>
        /// API.
        /// </summary>
        private readonly IVkApiInvoke _vk;
        /// <inheritdoc/>
        /// <param name = "api">
        /// Api vk.com
        /// </param>
        public OrdersCategory(IVkApiInvoke api)
        {
            _vk = api;
        }

        /// <inheritdoc/>
        public bool CancelSubscription(ulong userId, ulong subscriptionId, bool? pendingCancel = null)
        {
            return _vk.Call<bool>("orders.cancelSubscription", new VkParameters{{"user_id", userId}, {"subscription_id", subscriptionId}, {"pending_cancel", pendingCancel}});
        }

        /// <inheritdoc/>
        public object ChangeState(ulong orderId, string action, ulong? appOrderId = null, bool? testMode = null)
        {
            return _vk.Call<object>("orders.changeState", new VkParameters{{"order_id", orderId}, {"action", action}, {"app_order_id", appOrderId}, {"test_mode", testMode}});
        }

        /// <inheritdoc/>
        public IEnumerable<object> Get(ulong? offset = null, ulong? count = null, bool? testMode = null)
        {
            return _vk.Call<IEnumerable<object>>("orders.get", new VkParameters{{"offset", offset}, {"count", count}, {"test_mode", testMode}});
        }

        /// <inheritdoc/>
        public IEnumerable<VotesAmount> GetAmount(ulong userId, IEnumerable<string> votes)
        {
            return _vk.Call<IEnumerable<VotesAmount>>("orders.getAmount", new VkParameters{{"user_id", userId}, {"votes", votes}});
        }

        /// <inheritdoc/>
        public IEnumerable<object> GetById(ulong? orderId = null, IEnumerable<ulong> orderIds = null, bool? testMode = null)
        {
            return _vk.Call<IEnumerable<object>>("orders.getById", new VkParameters{{"order_id", orderId}, {"order_ids", orderIds}, {"test_mode", testMode}});
        }

        /// <inheritdoc/>
        public SubscriptionItem GetUserSubscriptionById(ulong userId, ulong subscriptionId)
        {
            return _vk.Call<SubscriptionItem>("orders.getUserSubscriptionById", new VkParameters{{"user_id", userId}, {"subscription_id", subscriptionId}});
        }

        /// <inheritdoc/>
        public IEnumerable<SubscriptionItem> GetUserSubscriptions(ulong userId)
        {
            return _vk.Call<IEnumerable<SubscriptionItem>>("orders.getUserSubscriptions", new VkParameters{{"user_id", userId}});
        }

        /// <inheritdoc/>
        public bool UpdateSubscription(ulong userId, ulong subscriptionId, ulong price)
        {
            return _vk.Call<bool>("orders.updateSubscription", new VkParameters{{"user_id", userId}, {"subscription_id", subscriptionId}, {"price", price}});
        }
    }
}