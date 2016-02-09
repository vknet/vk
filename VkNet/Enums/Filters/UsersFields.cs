using VkNet.Categories;
using VkNet.Model;

namespace VkNet.Enums.Filters
{
	/// <summary>
	/// Описание дополнительных полей сообщества, используемых в параметре fields (например, в методе <see cref="GroupsCategory.Get"/>).
	/// См. описание <see href="http://vk.com/dev/groups.get"/>.
	/// </summary>
	public sealed class UsersFields : MultivaluedFilter<UsersFields>
	{
		/// <summary>
		/// Для получения дополнительного поля <see cref="User.Nickname"/>.
		/// </summary>
		public static readonly UsersFields Nickname = RegisterPossibleValue(1L << 0, "nickname");

		/// <summary>
		/// Для получения дополнительного поля <see cref="User.Domain"/>.
		/// </summary>
		public static readonly UsersFields Domain = RegisterPossibleValue(1L << 1, "domain");

		/// <summary>
		/// Для получения дополнительного поля <see cref="User.Sex"/>.
		/// </summary>
		public static readonly UsersFields Sex = RegisterPossibleValue(1L << 2, "sex");

		/// <summary>
		/// Для получения дополнительного поля <see cref="User.BirthDate"/>.
		/// </summary>
		public static readonly UsersFields BirthDate = RegisterPossibleValue(1L << 3, "bdate");

		/// <summary>
		/// Для получения дополнительного поля <see cref="User.City"/>.
		/// </summary>
		public static readonly UsersFields City = RegisterPossibleValue(1L << 4, "city");

		/// <summary>
		/// Для получения дополнительного поля <see cref="User.Country"/>.
		/// </summary>
		public static readonly UsersFields Country = RegisterPossibleValue(1L << 5, "country");

		/// <summary>
		/// Для получения дополнительного поля <see cref="User.Timezone"/>.
		/// </summary>
		public static readonly UsersFields Timezone = RegisterPossibleValue(1L << 6, "timezone");

		/// <summary>
		/// Для получения дополнительного поля <see cref="User.Photo50"/>.
		/// </summary>
		public static readonly UsersFields Photo50 = RegisterPossibleValue(1L << 7, "photo_50");

		/// <summary>
		/// Для получения дополнительного поля <see cref="User.Photo100"/>.
		/// </summary>
		public static readonly UsersFields Photo100 = RegisterPossibleValue(1L << 8, "photo_100");

		/// <summary>
		/// Для получения дополнительного поля <see cref="User.Photo200Orig"/>.
		/// </summary>
		public static readonly UsersFields Photo200Orig = RegisterPossibleValue(1L << 9, "photo_200_orig");

		/// <summary>
		/// Для получения дополнительного поля <see cref="User.Photo200"/>.
		/// </summary>
		public static readonly UsersFields Photo200 = RegisterPossibleValue(1L << 24, "photo_200");

		/// <summary>
		/// Для получения дополнительного поля <see cref="User.Photo400Orig"/>.
		/// </summary>
		public static readonly UsersFields Photo400Orig = RegisterPossibleValue(1L << 21, "photo_400_orig");

		/// <summary>
		/// Для получения дополнительного поля <see cref="User.PhotoMax"/>.
		/// </summary>
		public static readonly UsersFields PhotoMax = RegisterPossibleValue(1L << 22, "photo_max");

		/// <summary>
		/// Для получения дополнительного поля <see cref="User.PhotoMaxOrig"/>.
		/// </summary>
		public static readonly UsersFields PhotoMaxOrig = RegisterPossibleValue(1L << 23, "photo_max_orig");

		/// <summary>
		/// Для получения дополнительного поля <see cref="User.HasMobile"/>.
		/// </summary>
		public static readonly UsersFields HasMobile = RegisterPossibleValue(1L << 10, "has_mobile");

		/// <summary>
		/// Для получения дополнительного поля <see cref="User.contacts"/>.
		/// </summary>
		public static readonly UsersFields Contacts = RegisterPossibleValue(1L << 11, "contacts");

		/// <summary>
		/// Для получения дополнительного поля <see cref="User.Education"/>.
		/// </summary>
		public static readonly UsersFields Education = RegisterPossibleValue(1L << 12, "education");

		/// <summary>
		/// Для получения дополнительного поля <see cref="User.Online"/>.
		/// </summary>
		public static readonly UsersFields Online = RegisterPossibleValue(1L << 13, "online");

		/// <summary>
		/// Для получения дополнительного поля <see cref="User.OnlineMobile"/>.
		/// </summary>
		public static readonly UsersFields OnlineMobile = RegisterPossibleValue(1L << 25, "online_mobile");

		/// <summary>
		/// Для получения дополнительного поля <see cref="User.FriendLists"/>.
		/// </summary>
		public static readonly UsersFields FriendLists = RegisterPossibleValue(1L << 26, "lists");

		/// <summary>
		/// Для получения дополнительного поля <see cref="User.Relation"/>.
		/// </summary>
		public static readonly UsersFields Relation = RegisterPossibleValue(1L << 14, "relation");

		/// <summary>
		/// Для получения дополнительного поля <see cref="User.LastSeen"/>.
		/// </summary>
		public static readonly UsersFields LastSeen = RegisterPossibleValue(1L << 15, "last_seen");

		/// <summary>
		/// Для получения дополнительного поля <see cref="User.Status"/>.
		/// </summary>
		public static readonly UsersFields Status = RegisterPossibleValue(1L << 16, "status");

		/// <summary>
		/// Для получения дополнительного поля <see cref="User.CanWritePrivateMessage"/>.
		/// </summary>
		public static readonly UsersFields CanWritePrivateMessage = RegisterPossibleValue(1L << 17, "can_write_private_message");

		/// <summary>
		/// Для получения дополнительного поля <see cref="User.CanSeeAllPosts"/>.
		/// </summary>
		public static readonly UsersFields CanSeeAllPosts = RegisterPossibleValue(1L << 18, "can_see_all_posts");

		/// <summary>
		/// Для получения дополнительного поля <see cref="User.CanPost"/>.
		/// </summary>
		public static readonly UsersFields CanPost = RegisterPossibleValue(1L << 19, "can_post");

		/// <summary>
		/// Для получения дополнительного поля <see cref="User.Universities "/>.
		/// </summary>
		public static readonly UsersFields Universities = RegisterPossibleValue(1L << 20, "universities");

		/// <summary>
		/// Для получения дополнительного поля <see cref="User.Connections "/>.
		/// </summary>
		public static readonly UsersFields Connections = RegisterPossibleValue(1L << 27, "connections");

		/// <summary>
		/// Для получения дополнительного поля <see cref="User.Site "/>.
		/// </summary>
		public static readonly UsersFields Site = RegisterPossibleValue(1L << 28, "site");

		/// <summary>
		/// Для получения дополнительного поля <see cref="User.Schools "/>.
		/// </summary>
		public static readonly UsersFields Schools = RegisterPossibleValue(1L << 29, "schools");

		/// <summary>
		/// Для получения дополнительного поля <see cref="User.CanSeeAudio "/>.
		/// </summary>
		public static readonly UsersFields CanSeeAudio = RegisterPossibleValue(1L << 30, "can_see_audio");


		/// <summary>
		/// Для получения дополнительного поля <see cref="User.CommonCount "/>.
		/// </summary>
		public static readonly UsersFields CommonCount = RegisterPossibleValue(1L << 31, "common_count");

		/// <summary>
		/// Для получения дополнительного поля <see cref="User.Relatives "/>.
		/// </summary>
		public static readonly UsersFields Relatives = RegisterPossibleValue(1L << 32, "relatives");

		/// <summary>
		/// Для получения дополнительного поля <see cref="User.Counters "/>.
		/// </summary>
		public static readonly UsersFields Counters = RegisterPossibleValue(1L << 33, "counters");


		/// <summary>
		/// Для получения всех дополнительных полей.
		/// </summary>
		public static readonly UsersFields All = Nickname | Domain | Sex | BirthDate | City | Country | Timezone | Photo50
			| Photo100 | Photo200Orig | HasMobile | Contacts | Education | Online | Relation | LastSeen | Status | CanWritePrivateMessage
			| CanSeeAllPosts | CanPost | Universities | OnlineMobile | FriendLists | Photo200 | Photo400Orig | PhotoMax | PhotoMaxOrig
			| Connections | Site | Schools | CanSeeAudio | CommonCount | Relatives | Counters;

	}
}