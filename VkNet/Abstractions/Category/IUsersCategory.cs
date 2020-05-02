using System.Collections.Generic;
using System.Collections.ObjectModel;
using JetBrains.Annotations;
using VkNet.Enums.Filters;
using VkNet.Enums.SafetyEnums;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkNet.Abstractions
{
	/// <inheritdoc cref="IUsersCategoryAsync"/>
	public interface IUsersCategory : IUsersCategoryAsync
	{
		/// <inheritdoc cref="IUsersCategoryAsync.SearchAsync"/>
		VkCollection<User> Search(UserSearchParams @params);

		/// <inheritdoc cref="IUsersCategoryAsync.IsAppUserAsync"/>
		bool IsAppUser(long? userId);

		/// <inheritdoc cref="IUsersCategoryAsync.GetAsync(long,ProfileFields,NameCase)"/>
		ReadOnlyCollection<User> Get([NotNull]
									IEnumerable<long> userIds
									, ProfileFields fields = null
									, NameCase nameCase = null);

		/// <inheritdoc cref="IUsersCategoryAsync.GetAsync(string,ProfileFields,NameCase)"/>
		ReadOnlyCollection<User> Get([NotNull]
									IEnumerable<string> screenNames
									, ProfileFields fields = null
									, NameCase nameCase = null);

		/// <inheritdoc cref="IUsersCategoryAsync.GetSubscriptionsAsync"/>
		VkCollection<Group> GetSubscriptions(long? userId = null
											, int? count = null
											, int? offset = null
											, GroupsFields fields = null);

		/// <inheritdoc cref="IUsersCategoryAsync.GetFollowersAsync"/>
		VkCollection<User> GetFollowers(long? userId = null
										, int? count = null
										, int? offset = null
										, ProfileFields fields = null
										, NameCase nameCase = null);

		/// <inheritdoc cref="IUsersCategoryAsync.ReportAsync"/>
		bool Report(long userId, ReportType type, string comment = "");

		/// <inheritdoc cref="IUsersCategoryAsync.GetNearbyAsync"/>
		VkCollection<User> GetNearby(UsersGetNearbyParams @params);
	}
}