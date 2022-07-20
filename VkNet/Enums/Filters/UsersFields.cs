namespace VkNet.Enums.Filters
{
	/// <summary>
	/// Описание дополнительных полей сообщества, используемых в параметре fields
	/// (например, в методе GroupsCategory.Get
	/// См. описание http://vk.com/dev/groups.get
	/// </summary>
	public sealed class UsersFields : MultivaluedFilter<UsersFields>
	{
		/// <summary>
		/// Для получения дополнительного поля User.Nickname
		/// </summary>
		public static readonly UsersFields Nickname = RegisterPossibleValue(mask: 1L << 0, value: "nickname");

		/// <summary>
		/// Для получения дополнительного поля User.Domain
		/// </summary>
		public static readonly UsersFields Domain = RegisterPossibleValue(mask: 1L << 1, value: "domain");

		/// <summary>
		/// Для получения дополнительного поля User.Sex
		/// </summary>
		public static readonly UsersFields Sex = RegisterPossibleValue(mask: 1L << 2, value: "sex");

		/// <summary>
		/// Для получения дополнительного поля User.BirthDate
		/// </summary>
		public static readonly UsersFields BirthDate = RegisterPossibleValue(mask: 1L << 3, value: "bdate");

		/// <summary>
		/// Для получения дополнительного поля User.City
		/// </summary>
		public static readonly UsersFields City = RegisterPossibleValue(mask: 1L << 4, value: "city");

		/// <summary>
		/// Для получения дополнительного поля User.Country
		/// </summary>
		public static readonly UsersFields Country = RegisterPossibleValue(mask: 1L << 5, value: "country");

		/// <summary>
		/// Для получения дополнительного поля User.Timezone
		/// </summary>
		public static readonly UsersFields Timezone = RegisterPossibleValue(mask: 1L << 6, value: "timezone");

		/// <summary>
		/// Для получения дополнительного поля User.Photo50
		/// </summary>
		public static readonly UsersFields Photo50 = RegisterPossibleValue(mask: 1L << 7, value: "photo_50");

		/// <summary>
		/// Для получения дополнительного поля User.Photo100
		/// </summary>
		public static readonly UsersFields Photo100 = RegisterPossibleValue(mask: 1L << 8, value: "photo_100");

		/// <summary>
		/// Для получения дополнительного поля User.Photo200Orig
		/// </summary>
		public static readonly UsersFields Photo200Orig = RegisterPossibleValue(mask: 1L << 9, value: "photo_200_orig");

		/// <summary>
		/// Для получения дополнительного поля User.Photo200
		/// </summary>
		public static readonly UsersFields Photo200 = RegisterPossibleValue(mask: 1L << 24, value: "photo_200");

		/// <summary>
		/// Для получения дополнительного поля User.Photo400Orig
		/// </summary>
		public static readonly UsersFields Photo400Orig = RegisterPossibleValue(mask: 1L << 21, value: "photo_400_orig");

		/// <summary>
		/// Для получения дополнительного поля User.PhotoMax
		/// </summary>
		public static readonly UsersFields PhotoMax = RegisterPossibleValue(mask: 1L << 22, value: "photo_max");

		/// <summary>
		/// Для получения дополнительного поля User.PhotoMaxOrig
		/// </summary>
		public static readonly UsersFields PhotoMaxOrig = RegisterPossibleValue(mask: 1L << 23, value: "photo_max_orig");

		/// <summary>
		/// Для получения дополнительного поля User.HasMobile
		/// </summary>
		public static readonly UsersFields HasMobile = RegisterPossibleValue(mask: 1L << 10, value: "has_mobile");

		/// <summary>
		/// Для получения дополнительного поля User.contacts
		/// </summary>
		public static readonly UsersFields Contacts = RegisterPossibleValue(mask: 1L << 11, value: "contacts");

		/// <summary>
		/// Для получения дополнительного поля User.Education
		/// </summary>
		public static readonly UsersFields Education = RegisterPossibleValue(mask: 1L << 12, value: "education");

		/// <summary>
		/// Для получения дополнительного поля User.Online
		/// </summary>
		public static readonly UsersFields Online = RegisterPossibleValue(mask: 1L << 13, value: "online");

		/// <summary>
		/// Для получения дополнительного поля User.OnlineMobile
		/// </summary>
		public static readonly UsersFields OnlineMobile = RegisterPossibleValue(mask: 1L << 25, value: "online_mobile");

		/// <summary>
		/// Для получения дополнительного поля User.FriendLists
		/// </summary>
		public static readonly UsersFields FriendLists = RegisterPossibleValue(mask: 1L << 26, value: "lists");

		/// <summary>
		/// Для получения дополнительного поля User.Relation
		/// </summary>
		public static readonly UsersFields Relation = RegisterPossibleValue(mask: 1L << 14, value: "relation");

		/// <summary>
		/// Для получения дополнительного поля User.LastSeen
		/// </summary>
		public static readonly UsersFields LastSeen = RegisterPossibleValue(mask: 1L << 15, value: "last_seen");

		/// <summary>
		/// Для получения дополнительного поля User.Status
		/// </summary>
		public static readonly UsersFields Status = RegisterPossibleValue(mask: 1L << 16, value: "status");

		/// <summary>
		/// Для получения дополнительного поля User.CanWritePrivateMessage
		/// </summary>
		public static readonly UsersFields CanWritePrivateMessage =
			RegisterPossibleValue(mask: 1L << 17, value: "can_write_private_message");

		/// <summary>
		/// Для получения дополнительного поля User.CanSeeAllPosts
		/// </summary>
		public static readonly UsersFields CanSeeAllPosts = RegisterPossibleValue(mask: 1L << 18, value: "can_see_all_posts");

		/// <summary>
		/// Для получения дополнительного поля User.CanPost
		/// </summary>
		public static readonly UsersFields CanPost = RegisterPossibleValue(mask: 1L << 19, value: "can_post");

		/// <summary>
		/// Для получения дополнительного поля User.Universities
		/// </summary>
		public static readonly UsersFields Universities = RegisterPossibleValue(mask: 1L << 20, value: "universities");

		/// <summary>
		/// Для получения дополнительного поля User.Connections
		/// </summary>
		public static readonly UsersFields Connections = RegisterPossibleValue(mask: 1L << 27, value: "connections");

		/// <summary>
		/// Для получения дополнительного поля User.Site
		/// </summary>
		public static readonly UsersFields Site = RegisterPossibleValue(mask: 1L << 28, value: "site");

		/// <summary>
		/// Для получения дополнительного поля User.Schools
		/// </summary>
		public static readonly UsersFields Schools = RegisterPossibleValue(mask: 1L << 29, value: "schools");

		/// <summary>
		/// Для получения дополнительного поля User.CanSeeAudio
		/// </summary>
		public static readonly UsersFields CanSeeAudio = RegisterPossibleValue(mask: 1L << 30, value: "can_see_audio");

		/// <summary>
		/// Для получения дополнительного поля User.CommonCount
		/// </summary>
		public static readonly UsersFields CommonCount = RegisterPossibleValue(mask: 1L << 31, value: "common_count");

		/// <summary>
		/// Для получения дополнительного поля User.Relatives
		/// </summary>
		public static readonly UsersFields Relatives = RegisterPossibleValue(mask: 1L << 32, value: "relatives");

		/// <summary>
		/// Для получения дополнительного поля User.Counters
		/// </summary>
		public static readonly UsersFields Counters = RegisterPossibleValue(mask: 1L << 33, value: "counters");

		/// <summary>
		/// Для получения дополнительного поля User.CanAccessClosed
		/// </summary>
		public static readonly UsersFields CanAccessClosed = RegisterPossibleValue(mask: 1L << 34, value: "can_access_closed");

		/// <summary>
		/// Для получения дополнительного поля User.IsClosed
		/// </summary>
		public static readonly UsersFields IsClosed = RegisterPossibleValue(mask: 1L << 35, value: "is_closed");

		/// <summary>
		/// Для получения дополнительного поля User.FirstNameNom
		/// </summary>
		public static readonly UsersFields FirstNameNom = RegisterPossibleValue(mask: 1L << 36, value: "first_name_nom");

		/// <summary>
		/// Для получения дополнительного поля User.FirstNameGen
		/// </summary>
		public static readonly UsersFields FirstNameGen = RegisterPossibleValue(mask: 1L << 37, value: "first_name_gen");

		/// <summary>
		/// Для получения дополнительного поля User.FirstNameDat
		/// </summary>
		public static readonly UsersFields FirstNameDat = RegisterPossibleValue(mask: 1L << 38, value: "first_name_dat");

		/// <summary>
		/// Для получения дополнительного поля User.FirstNameAcc
		/// </summary>
		public static readonly UsersFields FirstNameAcc = RegisterPossibleValue(mask: 1L << 39, value: "first_name_acc");


		/// <summary>
		/// Для получения дополнительного поля User.FirstNameIns
		/// </summary>
		public static readonly UsersFields FirstNameIns = RegisterPossibleValue(mask: 1L << 40, value: "first_name_ins");

		/// <summary>
		/// Для получения дополнительного поля User.FirstNameAbl
		/// </summary>
		public static readonly UsersFields FirstNameAbl = RegisterPossibleValue(mask: 1L << 41, value: "first_name_abl");

		/// <summary>
		/// Для получения дополнительного поля User.LastNameNom
		/// </summary>
		public static readonly UsersFields LastNameNom = RegisterPossibleValue(mask: 1L << 42, value: "last_name_nom");

		/// <summary>
		/// Для получения дополнительного поля User.LastNameGen
		/// </summary>
		public static readonly UsersFields LastNameGen = RegisterPossibleValue(mask: 1L << 43, value: "last_name_gen");

		/// <summary>
		/// Для получения дополнительного поля User.LastNameDat
		/// </summary>
		public static readonly UsersFields LastNameDat = RegisterPossibleValue(mask: 1L << 44, value: "last_name_dat");

		/// <summary>
		/// Для получения дополнительного поля User.LastNameAcc
		/// </summary>
		public static readonly UsersFields LastNameAcc = RegisterPossibleValue(mask: 1L << 44, value: "last_name_acc");

		/// <summary>
		/// Для получения дополнительного поля User.LastNameIns
		/// </summary>
		public static readonly UsersFields LastNameIns = RegisterPossibleValue(mask: 1L << 44, value: "last_name_ins");

		/// <summary>
		/// Для получения дополнительного поля User.LastNameAbl
		/// </summary>
		public static readonly UsersFields LastNameAbl = RegisterPossibleValue(mask: 1L << 44, value: "last_name_abl");

		/// <summary>
		/// Для получения всех дополнительных полей.
		/// </summary>
		public static readonly UsersFields All = Nickname
												|Domain
												|Sex
												|BirthDate
												|City
												|Country
												|Timezone
												|Photo50
												|Photo100
												|Photo200Orig
												|HasMobile
												|Contacts
												|Education
												|Online
												|Relation
												|LastSeen
												|Status
												|CanWritePrivateMessage
												|CanSeeAllPosts
												|CanPost
												|Universities
												|OnlineMobile
												|FriendLists
												|Photo200
												|Photo400Orig
												|PhotoMax
												|PhotoMaxOrig
												|Connections
												|Site
												|Schools
												|CanSeeAudio
												|CommonCount
												|Relatives
												|Counters
												|FirstNameNom
												|FirstNameGen
												|FirstNameDat
												|FirstNameAcc
												|FirstNameIns
												|FirstNameAbl
												|LastNameNom
												|LastNameGen
												|LastNameDat
												|LastNameAcc
												|LastNameIns
												|LastNameAbl
												|IsClosed
												|CanAccessClosed;
	}
}