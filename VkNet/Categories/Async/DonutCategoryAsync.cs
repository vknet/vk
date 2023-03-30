using System.Threading;
using System.Threading.Tasks;
using VkNet.Abstractions;
using VkNet.Enums.Filters;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Categories;

// <inheritdoc />
public partial class DonutCategory : IDonutCategoryAsync
{
	/// <inheritdoc/>
	public Task<bool> IsDonAsync(long ownerId,
								CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			IsDon(ownerId));

	/// <inheritdoc/>
	public Task<VkCollection<User>> GetFriendsAsync(long ownerId,
													ulong offset,
													byte count,
													UsersFields fields,
													CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetFriends(ownerId, offset, count, fields));

	/// <inheritdoc/>
	public Task<Subscription> GetSubscriptionAsync(long ownerId,
													CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetSubscription(ownerId));

	/// <inheritdoc/>
	public Task<SubscriptionsInfo> GetSubscriptionsAsync(UsersFields fields,
														ulong offset,
														byte count,
														CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetSubscriptions(fields, offset, count));
}