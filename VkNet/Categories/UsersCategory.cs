using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Net;
using JetBrains.Annotations;
using VkNet.Abstractions;
using VkNet.Enums.Filters;
using VkNet.Enums.SafetyEnums;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkNet.Categories
{
	/// <inheritdoc />
	public partial class UsersCategory : IUsersCategory
	{
		private readonly IVkApiInvoke _vk;

		/// <summary>
		/// Api vk.com
		/// </summary>
		/// <param name="vk"> </param>
		public UsersCategory(IVkApiInvoke vk)
		{
			_vk = vk;
		}

		/// <inheritdoc />
		[Pure]
		public VkCollection<User> Search(UserSearchParams @params)
		{
			return _vk.Call(methodName: "users.search", new VkParameters
			{
				{ "q", WebUtility.HtmlEncode(value: @params.Query) }
				, { "sort", @params.Sort }
				, { "offset", @params.Offset }
				, { "count", @params.Count }
				, { "fields", @params.Fields }
				, { "city", @params.City }
				, { "country", @params.Country }
				, { "hometown", WebUtility.HtmlEncode(value: @params.Hometown) }
				, { "university_country", @params.UniversityCountry }
				, { "university", @params.University }
				, { "university_year", @params.UniversityYear }
				, { "university_faculty", @params.UniversityFaculty }
				, { "university_chair", @params.UniversityChair }
				, { "sex", @params.Sex }
				, { "status", @params.Status }
				, { "age_from", @params.AgeFrom }
				, { "age_to", @params.AgeTo }
				, { "birth_day", @params.BirthDay }
				, { "birth_month", @params.BirthMonth }
				, { "birth_year", @params.BirthYear }
				, { "online", @params.Online }
				, { "has_photo", @params.HasPhoto }
				, { "school_country", @params.SchoolCountry }
				, { "school_city", @params.SchoolCity }
				, { "school_class", @params.SchoolClass }
				, { "school", @params.School }
				, { "school_year", @params.SchoolYear }
				, { "religion", WebUtility.HtmlEncode(value: @params.Religion) }
				, { "interests", WebUtility.HtmlEncode(value: @params.Interests) }
				, { "company", WebUtility.HtmlEncode(value: @params.Company) }
				, { "position", WebUtility.HtmlEncode(value: @params.Position) }
				, { "group_id", @params.GroupId }
				, { "from_list", @params.FromList }
			}).ToVkCollectionOf<User>(selector: r => r);
		}

		/// <inheritdoc />
		[Pure]
		public bool IsAppUser(long? userId)
		{
			var parameters = new VkParameters
			{
					{ "user_id", userId }
			};

			return _vk.Call(methodName: "users.isAppUser", parameters: parameters);
		}

		/// <inheritdoc />
		[Pure]
		public ReadOnlyCollection<User> Get(IEnumerable<long> userIds
											, ProfileFields fields = null
											, NameCase nameCase = null)
		{
			if (userIds == null)
			{
				throw new ArgumentNullException(paramName: nameof(userIds));
			}

			var parameters = new VkParameters
			{
					{ "fields", fields }
					, { "name_case", nameCase }
					, { "user_ids", userIds }
			};

			VkResponseArray response = _vk.Call(methodName: "users.get", parameters: parameters);

			return response.ToReadOnlyCollectionOf<User>(selector: x => x);
		}

		/// <inheritdoc />
		[Pure]
		[NotNull]
		[ContractAnnotation(contract: "screenNames:null => halt")]
		public ReadOnlyCollection<User> Get(IEnumerable<string> screenNames
											, ProfileFields fields = null
											, NameCase nameCase = null)
		{
			if (screenNames == null)
			{
				throw new ArgumentNullException(paramName: nameof(screenNames));
			}

			var parameters = new VkParameters
			{
					{ "user_ids", screenNames }
					, { "fields", fields }
					, { "name_case", nameCase }
			};

			VkResponseArray response = _vk.Call(methodName: "users.get", parameters: parameters);

			return response.ToReadOnlyCollectionOf<User>(selector: x => x);
		}

		/// <inheritdoc />
		[Pure]
		public VkCollection<Group> GetSubscriptions(long? userId = null
													, int? count = null
													, int? offset = null
													, GroupsFields fields = null)
		{
			VkErrors.ThrowIfNumberIsNegative(expr: () => userId);
			VkErrors.ThrowIfNumberIsNegative(expr: () => count);
			VkErrors.ThrowIfNumberIsNegative(expr: () => offset);

			var parameters = new VkParameters
			{
					{ "user_id", userId }
					, { "extended", true }
					, { "offset", offset }
					, { "count", count }
					, { "fields", fields }
			};

			return _vk.Call(methodName: "users.getSubscriptions", parameters: parameters)
					.ToVkCollectionOf<Group>(selector: x => x);
		}

		/// <inheritdoc />
		[Pure]
		public VkCollection<User> GetFollowers(long? userId = null
												, int? count = null
												, int? offset = null
												, ProfileFields fields = null
												, NameCase nameCase = null)
		{
			VkErrors.ThrowIfNumberIsNegative(expr: () => userId);
			VkErrors.ThrowIfNumberIsNegative(expr: () => count);
			VkErrors.ThrowIfNumberIsNegative(expr: () => offset);

			var parameters = new VkParameters
			{
					{ "user_id", userId }
					, { "offset", offset }
					, { "count", count }
					, { "fields", fields }
					, { "name_case", nameCase }
			};

			return _vk.Call(methodName: "users.getFollowers", parameters: parameters)
					.ToVkCollectionOf(selector: x => x.ContainsKey(key: "id") ? x : new User { Id = x });
		}

		/// <inheritdoc />
		public bool Report(long userId, ReportType type, string comment = "")
		{
			VkErrors.ThrowIfNumberIsNegative(expr: () => userId);

			var parameters = new VkParameters
			{
					{ "user_id", userId }
					, { "type", type }
					, { "comment", comment }
			};

			return _vk.Call(methodName: "users.report", parameters: parameters);
		}

		/// <inheritdoc />
		public VkCollection<User> GetNearby(UsersGetNearbyParams @params)
		{
			return _vk.Call(methodName: "users.getNearby", new VkParameters
			{
				{ "latitude", @params.Latitude.ToString(provider: CultureInfo.InvariantCulture) }
				, //Vk API не принимает дробные числа с запятой, нужна точка
				{ "longitude", @params.Longitude.ToString(provider: CultureInfo.InvariantCulture) }
				, { "accuracy", @params.Accuracy }
				, { "timeout", @params.Timeout }
				, { "radius", @params.Radius }
				, { "fields", @params.Fields }
				, { "name_case", @params.NameCase }
				, { "need_description", @params.NeedDescription }
			}).ToVkCollectionOf<User>(selector: x => x);
		}

		/// <inheritdoc cref="User" />
		[Pure]
		public User Get(long userId, ProfileFields fields = null, NameCase nameCase = null)
		{
			VkErrors.ThrowIfNumberIsNegative(expr: () => userId);
			var users = Get(userIds: new[] { userId }, fields: fields, nameCase: nameCase);

			return users.FirstOrDefault();
		}

		/// <inheritdoc cref="User" />
		public User Get([NotNull]
						string screenName
						, ProfileFields fields = null
						, NameCase nameCase = null)
		{
			VkErrors.ThrowIfNullOrEmpty(expr: () => screenName);

			var users = Get(screenNames: new[] { screenName }, fields: fields, nameCase: nameCase);

			return users.Count > 0 ? users[index: 0] : null;
		}
	}
}