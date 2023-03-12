using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using VkNet.Enums.Filters;
using VkNet.Enums.SafetyEnums;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkNet.Categories;

/// <inheritdoc />
public partial class UsersCategory
{
	/// <inheritdoc />
	public Task<VkCollection<User>> SearchAsync(UserSearchParams @params) =>
		TypeHelper.TryInvokeMethodAsync(func: () => Search(@params: @params));

	/// <inheritdoc />
	public Task<bool> IsAppUserAsync(long? userId) => TypeHelper.TryInvokeMethodAsync(func: () => IsAppUser(userId: userId));

	/// <inheritdoc />
	public Task<ReadOnlyCollection<User>> GetAsync(IEnumerable<long> userIds
													, ProfileFields fields = null
													, NameCase? nameCase = null) => TypeHelper.TryInvokeMethodAsync(func: () =>
		Get(userIds, fields, nameCase));

	/// <inheritdoc />
	public Task<ReadOnlyCollection<User>> GetAsync(IEnumerable<string> screenNames
													, ProfileFields fields = null
													, NameCase? nameCase = null) => TypeHelper.TryInvokeMethodAsync(func: () =>
		Get(screenNames, fields, nameCase));

	/// <inheritdoc />
	public Task<VkCollection<Group>> GetSubscriptionsAsync(long? userId = null
															, int? count = null
															, int? offset = null
															, GroupsFields fields = null) => TypeHelper.TryInvokeMethodAsync(func: () =>
		GetSubscriptions(userId
			, count
			, offset
			, fields));

	/// <inheritdoc />
	public Task<VkCollection<User>> GetFollowersAsync(long? userId = null
													, int? count = null
													, int? offset = null
													, ProfileFields fields = null
													, NameCase? nameCase = null) => TypeHelper.TryInvokeMethodAsync(func: () =>
		GetFollowers(userId
			, count
			, offset
			, fields
			, nameCase));

	/// <inheritdoc />
	public Task<bool> ReportAsync(long userId, ReportType type, string comment = "") =>
		TypeHelper.TryInvokeMethodAsync(func: () => Report(userId, type, comment));

	/// <inheritdoc />
	public Task<VkCollection<User>> GetNearbyAsync(UsersGetNearbyParams @params) =>
		TypeHelper.TryInvokeMethodAsync(func: () => GetNearby(@params: @params));
}