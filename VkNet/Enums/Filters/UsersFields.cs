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
		public static readonly UsersFields Nickname = RegisterPossibleValue(1 << 0, "nickname");

		/// <summary>
		/// Для получения дополнительного поля <see cref="User.Domain"/>.
		/// </summary>
		public static readonly UsersFields Domain = RegisterPossibleValue(1 << 1, "domain");

		/// <summary>
		/// Для получения дополнительного поля <see cref="User.Sex"/>.
		/// </summary>
		public static readonly UsersFields Sex = RegisterPossibleValue(1 << 2, "sex");

		/// <summary>
		/// Для получения дополнительного поля <see cref="User.BirthDate"/>.
		/// </summary>
		public static readonly UsersFields BirthDate = RegisterPossibleValue(1 << 3, "bdate");

		/// <summary>
		/// Для получения дополнительного поля <see cref="User.City"/>.
		/// </summary>
		public static readonly UsersFields City = RegisterPossibleValue(1 << 4, "city");

		/// <summary>
		/// Для получения дополнительного поля <see cref="User.Country"/>.
		/// </summary>
		public static readonly UsersFields Country = RegisterPossibleValue(1 << 5, "country");

		/// <summary>
		/// Для получения дополнительного поля <see cref="User.Timezone"/>.
		/// </summary>
		public static readonly UsersFields Timezone = RegisterPossibleValue(1 << 6, "timezone");

		/// <summary>
		/// Для получения дополнительного поля <see cref="User.photo_50"/>.
		/// </summary>
		public static readonly UsersFields Photo50 = RegisterPossibleValue(1 << 7, "photo_50");

		/// <summary>
		/// Для получения дополнительного поля <see cref="User.photo_100"/>.
		/// </summary>
		public static readonly UsersFields Photo100 = RegisterPossibleValue(1 << 8, "photo_100");

		/// <summary>
		/// Для получения дополнительного поля <see cref="User.photo_200_orig"/>.
		/// </summary>
		public static readonly UsersFields Photo200Orig = RegisterPossibleValue(1 << 9, "photo_200_orig");

		/// <summary>
		/// Для получения дополнительного поля <see cref="User.HasMobile"/>.
		/// </summary>
		public static readonly UsersFields HasMobile = RegisterPossibleValue(1 << 10, "has_mobile");

		/// <summary>
		/// Для получения дополнительного поля <see cref="User.contacts"/>.
		/// </summary>
		public static readonly UsersFields Contacts = RegisterPossibleValue(1 << 11, "contacts");

		/// <summary>
		/// Для получения дополнительного поля <see cref="User.Education"/>.
		/// </summary>
		public static readonly UsersFields Education = RegisterPossibleValue(1 << 12, "education");

		/// <summary>
		/// Для получения дополнительного поля <see cref="User.Online"/>.
		/// </summary>
		public static readonly UsersFields Online = RegisterPossibleValue(1 << 13, "online");

		/// <summary>
		/// Для получения дополнительного поля <see cref="User.Relation"/>.
		/// </summary>
		public static readonly UsersFields Relation = RegisterPossibleValue(1 << 14, "relation");

		/// <summary>
		/// Для получения дополнительного поля <see cref="User.LastSeen"/>.
		/// </summary>
		public static readonly UsersFields LastSeen = RegisterPossibleValue(1 << 15, "last_seen");

		/// <summary>
		/// Для получения дополнительного поля <see cref="User.Status"/>.
		/// </summary>
		public static readonly UsersFields Status = RegisterPossibleValue(1 << 16, "status");

		/// <summary>
		/// Для получения дополнительного поля <see cref="User.CanWritePrivateMessage"/>.
		/// </summary>
		public static readonly UsersFields CanWritePrivateMessage = RegisterPossibleValue(1 << 17, "can_write_private_message");

		/// <summary>
		/// Для получения дополнительного поля <see cref="User.CanSeeAllPosts"/>.
		/// </summary>
		public static readonly UsersFields CanSeeAllPosts = RegisterPossibleValue(1 << 18, "can_see_all_posts");

		/// <summary>
		/// Для получения дополнительного поля <see cref="User.CanPost"/>.
		/// </summary>
		public static readonly UsersFields CanPost = RegisterPossibleValue(1 << 19, "can_post");

		/// <summary>
		/// Для получения дополнительного поля <see cref="User.Universities "/>.
		/// </summary>
		public static readonly UsersFields Universities = RegisterPossibleValue(1 << 20, "universities");


		/// <summary>
		/// Для получения всех дополнительных полей.
		/// </summary>
		public static readonly UsersFields All = Nickname | Domain | Sex | BirthDate | City | Country | Timezone | Photo50 
			| Photo100 | Photo200Orig | HasMobile | Contacts | Education | Online | Relation | LastSeen | Status | CanWritePrivateMessage 
			| CanSeeAllPosts | CanPost | Universities;

	}
}