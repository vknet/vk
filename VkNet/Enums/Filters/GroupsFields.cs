namespace VkNet.Enums.Filters;

/// <summary>
/// Описание дополнительных полей сообщества, используемых в параметре fields
/// (например, в методе GroupsCategory.Get
/// См. описание http://vk.com/dev/groups.get
/// </summary>
public sealed class GroupsFields : MultivaluedFilter<GroupsFields>
{
	/// <summary>
	/// Для получения дополнительного поля Group.CityId
	/// </summary>
	public static readonly GroupsFields CityId = RegisterPossibleValue(1 << 0, "city");

	/// <summary>
	/// Для получения дополнительного поля Group.CountryId
	/// </summary>
	public static readonly GroupsFields CountryId = RegisterPossibleValue(1 << 1, "country");

	/// <summary>
	/// Для получения дополнительного поля Group.Place
	/// </summary>
	public static readonly GroupsFields Place = RegisterPossibleValue(1 << 2, "place");

	/// <summary>
	/// Для получения дополнительного поля Group.Description
	/// </summary>
	public static readonly GroupsFields Description = RegisterPossibleValue(1 << 3, "description");

	/// <summary>
	/// Для получения дополнительного поля Group.WikiPage
	/// </summary>
	public static readonly GroupsFields WikiPage = RegisterPossibleValue(1 << 4, "wiki_page");

	/// <summary>
	/// Для получения дополнительного поля Group.MembersCount
	/// </summary>
	public static readonly GroupsFields MembersCount = RegisterPossibleValue(1 << 5, "members_count");

	/// <summary>
	/// Для получения дополнительного поля Group.Counters
	/// </summary>
	public static readonly GroupsFields Counters = RegisterPossibleValue(1 << 6, "counters");

	/// <summary>
	/// Для получения дополнительного поля Group.StartDate
	/// </summary>
	public static readonly GroupsFields StartDate = RegisterPossibleValue(1 << 7, "start_date");

	/// <summary>
	/// Для получения дополнительного поля Group.EndDate
	/// </summary>
	public static readonly GroupsFields EndDate = RegisterPossibleValue(1 << 8, "finish_date");

	/// <summary>
	/// Для получения дополнительного поля Group.CanPost
	/// </summary>
	public static readonly GroupsFields CanPost = RegisterPossibleValue(1 << 9, "can_post");

	/// <summary>
	/// Для получения дополнительного поля Group.CanSeelAllPosts
	/// </summary>
	public static readonly GroupsFields CanSeeAllPosts = RegisterPossibleValue(1 << 10, "can_see_all_posts");

	/// <summary>
	/// Для получения дополнительного поля Group.CanUploadDocuments
	/// </summary>
	public static readonly GroupsFields CanUploadDocuments = RegisterPossibleValue(1 << 11, "can_upload_doc");

	/// <summary>
	/// Для получения дополнительного поля Group.CanCreateTopic
	/// </summary>
	public static readonly GroupsFields CanCreateTopic = RegisterPossibleValue(1 << 12, "can_create_topic");

	/// <summary>
	/// Для получения дополнительного поля Group.Activity
	/// </summary>
	public static readonly GroupsFields Activity = RegisterPossibleValue(1 << 13, "activity");

	/// <summary>
	/// Для получения дополнительного поля Group.Status
	/// </summary>
	public static readonly GroupsFields Status = RegisterPossibleValue(1 << 14, "status");

	/// <summary>
	/// Для получения дополнительного поля Group.Contacts
	/// </summary>
	public static readonly GroupsFields Contacts = RegisterPossibleValue(1 << 15, "contacts");

	/// <summary>
	/// Для получения дополнительного поля Group.Links
	/// </summary>
	public static readonly GroupsFields Links = RegisterPossibleValue(1 << 16, "links");

	/// <summary>
	/// Для получения дополнительного поля Group.FixedPostId
	/// </summary>
	public static readonly GroupsFields FixedPostId = RegisterPossibleValue(1 << 17, "fixed_post");

	/// <summary>
	/// Для получения дополнительного поля Group.IsVerified
	/// </summary>
	public static readonly GroupsFields IsVerified = RegisterPossibleValue(1 << 18, "verified");

	/// <summary>
	/// Для получения дополнительного поля Group.Site
	/// </summary>
	public static readonly GroupsFields Site = RegisterPossibleValue(1 << 19, "site");

	/// <summary>
	/// Для получения дополнительного поля Group.BanInfo
	/// </summary>
	public static readonly GroupsFields BanInfo = RegisterPossibleValue(1 << 20, "ban_info");

	/// <summary>
	/// Для получения всех дополнительных полей.
	/// </summary>
	public static readonly GroupsFields All = CityId
											|CountryId
											|Place
											|Description
											|WikiPage
											|MembersCount
											|Counters
											|StartDate
											|EndDate
											|CanPost
											|CanSeeAllPosts
											|CanCreateTopic
											|Activity
											|Status
											|Contacts
											|Links
											|FixedPostId
											|IsVerified
											|Site
											|BanInfo;

	/// <summary>
	/// Для получения всех дополнительных полей (оказалаось, что некоторые поля
	/// пропущены в документации).
	/// </summary>
	public static readonly GroupsFields AllUndocumented = All|CanUploadDocuments;
}