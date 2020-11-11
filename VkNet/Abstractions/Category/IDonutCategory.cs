using System.Collections.ObjectModel;
using VkNet.Enums.Filters;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Abstractions
{
	/// <inheritdoc cref="IDonutCategoryAsync"/>
	public interface IDonutCategory
	{
		/// <inheritdoc cref="IDonutCategoryAsync.IsDonAsync"/>
		bool IsDon(long ownerId);

		/// <inheritdoc cref="IDonutCategoryAsync.GetFriendsAsync"/>
		VkCollection<User> GetFriends(long ownerId, ulong offset, byte count, UsersFields fields);

		/// <inheritdoc cref="IDonutCategoryAsync.GetSubscriptionAsync"/>
		Subscription GetSubscription(long ownerId);

		/// <inheritdoc cref="IDonutCategoryAsync.GetSubscriptionsAsync"/>
		SubscriptionsInfo GetSubscriptions(UsersFields fields, ulong offset, byte count);
	}
}
