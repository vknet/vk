using System.Collections.Generic;
using VkNet.Abstractions.Category;
using VkNet.Enums.SafetyEnums;
using VkNet.Model;

namespace VkNet.Abstractions
{
	/// <inheritdoc cref="IOrdersCategoryAsync"/>
	public interface IOrdersCategory : IOrdersCategoryAsync
    {
		/// <inheritdoc cref="IOrdersCategoryAsync.CancelSubscriptionAsync"/>
        bool CancelSubscription(ulong userId, ulong subscriptionId, bool? pendingCancel = null);

		/// <inheritdoc cref="IOrdersCategoryAsync.ChangeStateAsync"/>
		OrderState ChangeState(ulong orderId, OrderStateAction action, ulong? appOrderId = null, bool? testMode = null);

		/// <inheritdoc cref="IOrdersCategoryAsync.GetAsync"/>
        IEnumerable<Order> Get(ulong? offset = null, ulong? count = null, bool? testMode = null);

		/// <inheritdoc cref="IOrdersCategoryAsync.GetAmountAsync"/>
        IEnumerable<VotesAmount> GetAmount(ulong userId, IEnumerable<string> votes);

		/// <inheritdoc cref="IOrdersCategoryAsync.GetByIdAsync"/>
        IEnumerable<Order> GetById(IEnumerable<ulong> orderIds = null, bool? testMode = null);

		/// <inheritdoc cref="IOrdersCategoryAsync.GetUserSubscriptionByIdAsync"/>
		SubscriptionItem GetUserSubscriptionById(ulong userId, ulong subscriptionId);

		/// <inheritdoc cref="IOrdersCategoryAsync.GetUserSubscriptionsAsync"/>
        IEnumerable<SubscriptionItem> GetUserSubscriptions(ulong userId);

		/// <inheritdoc cref="IOrdersCategoryAsync.UpdateSubscriptionAsync"/>
        bool UpdateSubscription(ulong userId, ulong subscriptionId, ulong price);
    }
}