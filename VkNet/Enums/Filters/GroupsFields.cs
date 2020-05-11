namespace VkNet.Enums.Filters
{
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
		public static readonly GroupsFields CityId = RegisterPossibleValue(mask: 1 << 0, value: "city");

		/// <summary>
		/// Для получения дополнительного поля Group.CountryId
		/// </summary>
		public static readonly GroupsFields CountryId = RegisterPossibleValue(mask: 1 << 1, value: "country");

		/// <summary>
		/// Для получения дополнительного поля Group.Place
		/// </summary>
		public static readonly GroupsFields Place = RegisterPossibleValue(mask: 1 << 2, value: "place");

		/// <summary>
		/// Для получения дополнительного поля Group.Description
		/// </summary>
		public static readonly GroupsFields Description = RegisterPossibleValue(mask: 1 << 3, value: "description");

		/// <summary>
		/// Для получения дополнительного поля Group.WikiPage
		/// </summary>
		public static readonly GroupsFields WikiPage = RegisterPossibleValue(mask: 1 << 4, value: "wiki_page");

		/// <summary>
		/// Для получения дополнительного поля Group.MembersCount
		/// </summary>
		public static readonly GroupsFields MembersCount = RegisterPossibleValue(mask: 1 << 5, value: "members_count");

		/// <summary>
		/// Для получения дополнительного поля Group.Counters
		/// </summary>
		public static readonly GroupsFields Counters = RegisterPossibleValue(mask: 1 << 6, value: "counters");

		/// <summary>
		/// Для получения дополнительного поля Group.StartDate
		/// </summary>
		public static readonly GroupsFields StartDate = RegisterPossibleValue(mask: 1 << 7, value: "start_date");

		/// <summary>
		/// Для получения дополнительного поля Group.EndDate
		/// </summary>
		public static readonly GroupsFields EndDate = RegisterPossibleValue(mask: 1 << 8, value: "finish_date");

		/// <summary>
		/// Для получения дополнительного поля Group.CanPost
		/// </summary>
		public static readonly GroupsFields CanPost = RegisterPossibleValue(mask: 1 << 9, value: "can_post");

		/// <summary>
		/// Для получения дополнительного поля Group.CanSeelAllPosts
		/// </summary>
		public static readonly GroupsFields CanSeelAllPosts = RegisterPossibleValue(mask: 1 << 10, value: "can_see_all_posts");

		/// <summary>
		/// Для получения дополнительного поля Group.CanUploadDocuments
		/// </summary>
		public static readonly GroupsFields CanUploadDocuments = RegisterPossibleValue(mask: 1 << 11, value: "can_upload_doc");

		/// <summary>
		/// Для получения дополнительного поля Group.CanCreateTopic
		/// </summary>
		public static readonly GroupsFields CanCreateTopic = RegisterPossibleValue(mask: 1 << 12, value: "can_create_topic");

		/// <summary>
		/// Для получения дополнительного поля Group.Activity
		/// </summary>
		public static readonly GroupsFields Activity = RegisterPossibleValue(mask: 1 << 13, value: "activity");

		/// <summary>
		/// Для получения дополнительного поля Group.Status
		/// </summary>
		public static readonly GroupsFields Status = RegisterPossibleValue(mask: 1 << 14, value: "status");

		/// <summary>
		/// Для получения дополнительного поля Group.Contacts
		/// </summary>
		public static readonly GroupsFields Contacts = RegisterPossibleValue(mask: 1 << 15, value: "contacts");

		/// <summary>
		/// Для получения дополнительного поля Group.Links
		/// </summary>
		public static readonly GroupsFields Links = RegisterPossibleValue(mask: 1 << 16, value: "links");

		/// <summary>
		/// Для получения дополнительного поля Group.FixedPostId
		/// </summary>
		public static readonly GroupsFields FixedPostId = RegisterPossibleValue(mask: 1 << 17, value: "fixed_post");

		/// <summary>
		/// Для получения дополнительного поля Group.IsVerified
		/// </summary>
		public static readonly GroupsFields IsVerified = RegisterPossibleValue(mask: 1 << 18, value: "verified");

		/// <summary>
		/// Для получения дополнительного поля Group.Site
		/// </summary>
		public static readonly GroupsFields Site = RegisterPossibleValue(mask: 1 << 19, value: "site");

		/// <summary>
		/// Для получения дополнительного поля Group.BanInfo
		/// </summary>
		public static readonly GroupsFields BanInfo = RegisterPossibleValue(mask: 1 << 20, value: "ban_info");

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
												|CanSeelAllPosts
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
}