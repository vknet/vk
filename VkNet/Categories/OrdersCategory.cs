using System.Collections.Generic;
using System.Collections.ObjectModel;
using VkNet.Abstractions;
using VkNet.Enums.StringEnums;
using VkNet.Model;

namespace VkNet.Categories;

/// <inheritdoc/>
public partial class OrdersCategory : IOrdersCategory
{
	/// <summary>
	/// API.
	/// </summary>
	private readonly IVkApiInvoke _vk;

	/// <summary>
	/// api vk.com
	/// </summary>
	/// <param name = "vk">
	/// Api vk.com
	/// </param>
	public OrdersCategory(IVkApiInvoke vk) => _vk = vk;

	/// <inheritdoc/>
	public bool CancelSubscription(ulong userId, ulong subscriptionId, bool? pendingCancel = null) => _vk.Call<bool>(
		"orders.cancelSubscription",
		new()
		{
			{
				"user_id", userId
			},
			{
				"subscription_id", subscriptionId
			},
			{
				"pending_cancel", pendingCancel
			}
		});

	/// <inheritdoc/>
	public OrderState ChangeState(ulong orderId, OrderStateAction action, ulong? appOrderId = null, bool? testMode = null) =>
		_vk.Call<OrderState>("orders.changeState",
			new()
			{
				{
					"order_id", orderId
				},
				{
					"action", action
				},
				{
					"app_order_id", appOrderId
				},
				{
					"test_mode", testMode
				}
			});

	/// <inheritdoc/>
	public IEnumerable<Order> Get(ulong? offset = null, ulong? count = null, bool? testMode = null) => _vk.Call<ReadOnlyCollection<Order>>(
		"orders.get",
		new()
		{
			{
				"offset", offset
			},
			{
				"count", count
			},
			{
				"test_mode", testMode
			}
		});

	/// <inheritdoc/>
	public IEnumerable<VotesAmount> GetAmount(ulong userId, IEnumerable<string> votes) => _vk.Call<ReadOnlyCollection<VotesAmount>>(
		"orders.getAmount",
		new()
		{
			{
				"user_id", userId
			},
			{
				"votes", votes
			}
		});

	/// <inheritdoc/>
	public IEnumerable<Order> GetById(IEnumerable<ulong> orderIds = null, bool? testMode = null) => _vk.Call<ReadOnlyCollection<Order>>(
		"orders.getById",
		new()
		{
			{
				"order_ids", orderIds
			},
			{
				"test_mode", testMode
			}
		});

	/// <inheritdoc/>
	public SubscriptionItem GetUserSubscriptionById(ulong userId, ulong subscriptionId) => _vk.Call<SubscriptionItem>(
		"orders.getUserSubscriptionById",
		new()
		{
			{
				"user_id", userId
			},
			{
				"subscription_id", subscriptionId
			}
		});

	/// <inheritdoc/>
	public IEnumerable<SubscriptionItem> GetUserSubscriptions(ulong userId) => _vk.Call<ReadOnlyCollection<SubscriptionItem>>(
		"orders.getUserSubscriptions", new()
		{
			{
				"user_id", userId
			}
		});

	/// <inheritdoc/>
	public bool UpdateSubscription(ulong userId, ulong subscriptionId, ulong price) => _vk.Call<bool>("orders.updateSubscription",
		new()
		{
			{
				"user_id", userId
			},
			{
				"subscription_id", subscriptionId
			},
			{
				"price", price
			}
		});
}