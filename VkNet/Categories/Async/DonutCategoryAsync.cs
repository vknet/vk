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
								CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			IsDon(ownerId), token);

	/// <inheritdoc/>
	public Task<VkCollection<User>> GetFriendsAsync(long ownerId,
													ulong offset,
													byte count,
													UsersFields fields,
													CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetFriends(ownerId, offset, count, fields), token);

	/// <inheritdoc/>
	public Task<Subscription> GetSubscriptionAsync(long ownerId,
													CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetSubscription(ownerId), token);

	/// <inheritdoc/>
	public Task<SubscriptionsInfo> GetSubscriptionsAsync(UsersFields fields,
														ulong offset,
														byte count,
														CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetSubscriptions(fields, offset, count), token);
}