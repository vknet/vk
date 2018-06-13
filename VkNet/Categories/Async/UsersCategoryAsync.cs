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
			return TypeHelper.TryInvokeMethodAsync(func: () => _vk.Users.Search(@params: @params));
		}

		/// <inheritdoc />
		public Task<bool> IsAppUserAsync(long? userId)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => _vk.Users.IsAppUser(userId: userId));
		}

		/// <inheritdoc />
		public Task<ReadOnlyCollection<User>> GetAsync(IEnumerable<long> userIds
															, ProfileFields fields = null
															, NameCase nameCase = null
															, bool skipAuthorization = false)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.Users.Get(userIds: userIds, fields: fields, nameCase: nameCase, skipAuthorization: skipAuthorization));
		}

		/// <inheritdoc />
		public Task<ReadOnlyCollection<User>> GetAsync(IEnumerable<string> screenNames
															, ProfileFields fields = null
															, NameCase nameCase = null
															, bool skipAuthorization = false)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.Users.Get(screenNames: screenNames, fields: fields, nameCase: nameCase, skipAuthorization: skipAuthorization));
		}

		/// <inheritdoc />
		public Task<VkCollection<Group>> GetSubscriptionsAsync(long? userId = null
																	, int? count = null
																	, int? offset = null
																	, GroupsFields fields = null
																	, bool skipAuthorization = false)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.Users.GetSubscriptions(userId: userId
							, count: count
							, offset: offset
							, fields: fields
							, skipAuthorization: skipAuthorization));
		}

		/// <inheritdoc />
		public Task<VkCollection<User>> GetFollowersAsync(long? userId = null
																, int? count = null
																, int? offset = null
																, ProfileFields fields = null
																, NameCase nameCase = null
																, bool skipAuthorization = false)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.Users.GetFollowers(userId: userId
							, count: count
							, offset: offset
							, fields: fields
							, nameCase: nameCase
							, skipAuthorization: skipAuthorization));
		}

		/// <inheritdoc />
		public Task<bool> ReportAsync(long userId, ReportType type, string comment = "")
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => _vk.Users.Report(userId: userId, type: type, comment: comment));
		}

		/// <inheritdoc />
		public Task<VkCollection<User>> GetNearbyAsync(UsersGetNearbyParams @params)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => _vk.Users.GetNearby(@params: @params));
		}
	}
}