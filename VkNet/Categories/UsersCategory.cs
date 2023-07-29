using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Net;
using JetBrains.Annotations;
using VkNet.Abstractions;
using VkNet.Enums.Filters;
using VkNet.Enums.StringEnums;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Categories;

/// <inheritdoc cref="IUsersCategory" />
public partial class UsersCategory : IUsersCategory
{
	private readonly IVkApiInvoke _vk;

	/// <summary>
	/// Инициализирует новый экземпляр класса <see cref="UsersCategory" />
	/// </summary>
	public UsersCategory(IVkApiInvoke vk) => _vk = vk;

	/// <inheritdoc />
	[Pure]
	public VkCollection<User> Search(UserSearchParams @params) => _vk.Call<VkCollection<User>>("users.search", new()
	{
		{
			"q", WebUtility.HtmlEncode(value: @params.Query)
		},
		{
			"sort", @params.Sort
		},
		{
			"offset", @params.Offset
		},
		{
			"count", @params.Count
		},
		{
			"fields", @params.Fields
		},
		{
			"city", @params.City
		},
		{
			"country", @params.Country
		},
		{
			"hometown", WebUtility.HtmlEncode(value: @params.Hometown)
		},
		{
			"university_country", @params.UniversityCountry
		},
		{
			"university", @params.University
		},
		{
			"university_year", @params.UniversityYear
		},
		{
			"university_faculty", @params.UniversityFaculty
		},
		{
			"university_chair", @params.UniversityChair
		},
		{
			"sex", @params.Sex
		},
		{
			"status", @params.Status
		},
		{
			"age_from", @params.AgeFrom
		},
		{
			"age_to", @params.AgeTo
		},
		{
			"birth_day", @params.BirthDay
		},
		{
			"birth_month", @params.BirthMonth
		},
		{
			"birth_year", @params.BirthYear
		},
		{
			"online", @params.Online
		},
		{
			"has_photo", @params.HasPhoto
		},
		{
			"school_country", @params.SchoolCountry
		},
		{
			"school_city", @params.SchoolCity
		},
		{
			"school_class", @params.SchoolClass
		},
		{
			"school", @params.School
		},
		{
			"school_year", @params.SchoolYear
		},
		{
			"religion", WebUtility.HtmlEncode(value: @params.Religion)
		},
		{
			"interests", WebUtility.HtmlEncode(value: @params.Interests)
		},
		{
			"company", WebUtility.HtmlEncode(value: @params.Company)
		},
		{
			"position", WebUtility.HtmlEncode(value: @params.Position)
		},
		{
			"group_id", @params.GroupId
		},
		{
			"from_list", @params.FromList
		}
	});

	/// <inheritdoc />
	[Pure]
	public bool IsAppUser(long? userId)
	{
		var parameters = new VkParameters
		{
			{
				"user_id", userId
			}
		};

		return _vk.Call<bool>("users.isAppUser", parameters);
	}

	/// <inheritdoc />
	[Pure]
	public ReadOnlyCollection<User> Get(IEnumerable<long> userIds
										, ProfileFields fields = null
										, NameCase? nameCase = null)
	{
		if (userIds is null)
		{
			throw new ArgumentNullException(paramName: nameof(userIds));
		}

		var parameters = new VkParameters
		{
			{
				"fields", fields
			},
			{
				"name_case", nameCase
			},
			{
				"user_ids", userIds
			}
		};

		return _vk.Call<ReadOnlyCollection<User>>("users.get", parameters);
	}

	/// <inheritdoc />
	[Pure]
	[NotNull]
	[ContractAnnotation(contract: "screenNames:null => halt")]
	public ReadOnlyCollection<User> Get(IEnumerable<string> screenNames
										, ProfileFields fields = null
										, NameCase? nameCase = null)
	{
		if (screenNames is null)
		{
			throw new ArgumentNullException(paramName: nameof(screenNames));
		}

		var parameters = new VkParameters
		{
			{
				"user_ids", screenNames
			},
			{
				"fields", fields
			},
			{
				"name_case", nameCase
			}
		};

		return _vk.Call<ReadOnlyCollection<User>>("users.get", parameters);
	}

	/// <inheritdoc cref="User" />
	[Pure]
	public User Get(long userId, ProfileFields fields = null, NameCase? nameCase = null)
	{
		VkErrors.ThrowIfNumberIsNegative(expr: () => userId);

		var users = Get(new[]
		{
			userId
		}, fields, nameCase);

		return users.FirstOrDefault();
	}

	/// <inheritdoc cref="User" />
	public User Get([NotNull] string screenName
					, ProfileFields fields = null
					, NameCase? nameCase = null)
	{
		VkErrors.ThrowIfNullOrEmpty(expr: () => screenName);

		var users = Get(new[]
		{
			screenName
		}, fields, nameCase);

		return users.Any()
			? users[index: 0]
			: null;
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
			{
				"user_id", userId
			},
			{
				"extended", true
			},
			{
				"offset", offset
			},
			{
				"count", count
			},
			{
				"fields", fields
			}
		};

		return _vk.Call<VkCollection<Group>>("users.getSubscriptions", parameters);
	}

	/// <inheritdoc />
	[Pure]
	public VkCollection<User> GetFollowers(long? userId = null
											, int? count = null
											, int? offset = null
											, ProfileFields fields = null
											, NameCase? nameCase = null)
	{
		VkErrors.ThrowIfNumberIsNegative(expr: () => userId);
		VkErrors.ThrowIfNumberIsNegative(expr: () => count);
		VkErrors.ThrowIfNumberIsNegative(expr: () => offset);

		var parameters = new VkParameters
		{
			{
				"user_id", userId
			},
			{
				"offset", offset
			},
			{
				"count", count
			},
			{
				"fields", fields
			},
			{
				"name_case", nameCase
			}
		};

		var response = _vk.Call("users.getFollowers", parameters);

		if (response["items"][0]
			.ContainsKey("id"))
		{
			return _vk.Call<VkCollection<User>>("users.getFollowers", parameters);
		}

		return _vk.Call("users.getFollowers", parameters)
			.ToVkCollectionOf(selector: x => new User
			{
				Id = (long) x
			});
	}

	/// <inheritdoc />
	public bool Report(long userId, ReportType type, string comment = "")
	{
		VkErrors.ThrowIfNumberIsNegative(expr: () => userId);

		var parameters = new VkParameters
		{
			{
				"user_id", userId
			},
			{
				"type", type
			},
			{
				"comment", comment
			}
		};

		return _vk.Call<bool>("users.report", parameters);
	}

	/// <inheritdoc />
	public VkCollection<User> GetNearby(UsersGetNearbyParams @params) => _vk.Call<VkCollection<User>>("users.getNearby", new()
	{
		{
			"latitude", @params.Latitude.ToString(provider: CultureInfo.InvariantCulture)
		}, //Vk API не принимает дробные числа с запятой, нужна точка
		{
			"longitude", @params.Longitude.ToString(provider: CultureInfo.InvariantCulture)
		},
		{
			"accuracy", @params.Accuracy
		},
		{
			"timeout", @params.Timeout
		},
		{
			"radius", @params.Radius
		},
		{
			"fields", @params.Fields
		},
		{
			"name_case", @params.NameCase
		},
		{
			"need_description", @params.NeedDescription
		}
	});
}