using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using VkNet.Enums.Filters;
using VkNet.Enums.SafetyEnums;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkNet.Categories
{
	/// <inheritdoc />
	public partial class UsersCategory
	{
		/// <inheritdoc />
		public Task<VkCollection<User>> SearchAsync(UserSearchParams @params)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>Search(@params: @params));
		}

		/// <inheritdoc />
		public Task<bool> IsAppUserAsync(long? userId)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>IsAppUser(userId: userId));
		}

		/// <inheritdoc />
		public Task<ReadOnlyCollection<User>> GetAsync(IEnumerable<long> userIds
															, ProfileFields fields = null
															, NameCase nameCase = null)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>
					Get(userIds: userIds, fields: fields, nameCase: nameCase));
		}

		/// <inheritdoc />
		public Task<ReadOnlyCollection<User>> GetAsync(IEnumerable<string> screenNames
															, ProfileFields fields = null
															, NameCase nameCase = null)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>
					Get(screenNames: screenNames, fields: fields, nameCase: nameCase));
		}

		/// <inheritdoc />
		public Task<VkCollection<Group>> GetSubscriptionsAsync(long? userId = null
																	, int? count = null
																	, int? offset = null
																	, GroupsFields fields = null)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>
					GetSubscriptions(userId: userId
							, count: count
							, offset: offset
							, fields: fields));
		}

		/// <inheritdoc />
		public Task<VkCollection<User>> GetFollowersAsync(long? userId = null
																, int? count = null
																, int? offset = null
																, ProfileFields fields = null
																, NameCase nameCase = null)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>
					GetFollowers(userId: userId
							, count: count
							, offset: offset
							, fields: fields
							, nameCase: nameCase));
		}

		/// <inheritdoc />
		public Task<bool> ReportAsync(long userId, ReportType type, string comment = "")
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>Report(userId: userId, type: type, comment: comment));
		}

		/// <inheritdoc />
		public Task<VkCollection<User>> GetNearbyAsync(UsersGetNearbyParams @params)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>GetNearby(@params: @params));
		}
	}
}