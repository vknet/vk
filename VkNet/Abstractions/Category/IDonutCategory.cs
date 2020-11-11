using System.Collections.ObjectModel;
using VkNet.Enums.Filters;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Abstractions
{
	public interface IDonutCategory
	{
		bool IsDon(long ownerId);
		VkCollection<User> GetFriends(long ownerId, ulong offset, byte count, UsersFields fields);
		Subscription GetSubscription(long ownerId);
		SubscriptionsInfo GetSubscriptions(UsersFields fields, ulong offset, byte count);
	}
}
