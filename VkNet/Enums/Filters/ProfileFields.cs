namespace VkNet.Enums.Filters
{
	/// <summary>
	/// Требуемые для получения поля профиля.
	/// См. описание
	/// <see href="http://vk.com/pages?oid=-1&amp;p=Описание_полей_параметра_fields" />
	/// .
	/// </summary>
	public sealed class ProfileFields : MultivaluedFilter<ProfileFields>
	{
		/// <summary>
		/// Для получения поля User.Id
		/// </summary>
		public static readonly ProfileFields Uid = RegisterPossibleValue(value: "user_id");

		/// <summary>
		/// Для получения поля User.FirstName
		/// </summary>
		public static readonly ProfileFields FirstName = RegisterPossibleValue(value: "first_name");

		/// <summary>
		/// Для получения поля User.LastName
		/// </summary>
		public static readonly ProfileFields LastName = RegisterPossibleValue(value: "last_name");

		/// <summary>
		/// Для получения поля User.Sex
		/// </summary>
		public static readonly ProfileFields Sex = RegisterPossibleValue(value: "sex");

		/// <summary>
		/// Для получения поля User.BirthDate
		/// </summary>
		public static readonly ProfileFields BirthDate = RegisterPossibleValue(value: "bdate");

		/// <summary>
		/// Для получения поля User.City
		/// </summary>
		public static readonly ProfileFields City = RegisterPossibleValue(value: "city");

		/// <summary>
		/// Для получения поля User.Country
		/// </summary>
		public static readonly ProfileFields Country = RegisterPossibleValue(value: "country");

		/// <summary>
		/// Для получения поля Previews.Photo50
		/// </summary>
		public static readonly ProfileFields Photo50 = RegisterPossibleValue(value: "photo_50");

		/// <summary>
		/// Для получения поля Previews.Photo100
		/// </summary>
		public static readonly ProfileFields Photo100 = RegisterPossibleValue(value: "photo_100");

		/// <summary>
		/// Для получения поля Previews.Photo200
		/// </summary>
		public static readonly ProfileFields Photo200 = RegisterPossibleValue(value: "photo_200");

		/// <summary>
		/// Для получения поля Previews.Photo200
		/// </summary>
		public static readonly ProfileFields Photo200Orig = RegisterPossibleValue(value: "photo_200_orig");

		/// <summary>
		/// Для получения поля Previews.Photo400
		/// </summary>
		public static readonly ProfileFields Photo400Orig = RegisterPossibleValue(value: "photo_400_orig");

		/// <summary>
		/// Для получения поля Previews.PhotoMax
		/// </summary>
		public static readonly ProfileFields PhotoMax = RegisterPossibleValue(value: "photo_max");

		/// <summary>
		/// Для получения поля Previews.PhotoMax
		/// </summary>
		public static readonly ProfileFields PhotoMaxOrig = RegisterPossibleValue(value: "photo_max_orig");

		/// <summary>
		/// Для получения поля User.Online
		/// </summary>
		public static readonly ProfileFields Online = RegisterPossibleValue(value: "online");

		/// <summary>
		/// Для получения поля User.FriendLists
		/// </summary>
		public static readonly ProfileFields FriendLists = RegisterPossibleValue(value: "lists");

		/// <summary>
		/// Для получения поля User.Domain
		/// </summary>
		public static readonly ProfileFields Domain = RegisterPossibleValue(value: "domain");

		/// <summary>
		/// Для получения поля User.HasMobile
		/// </summary>
		public static readonly ProfileFields HasMobile = RegisterPossibleValue(value: "has_mobile");

		/// <summary>
		/// Для получения полей User.MobilePhone
		/// </summary>
		public static readonly ProfileFields Contacts = RegisterPossibleValue(value: "contacts");

		/// <summary>
		/// Для получения поля User.Connections
		/// </summary>
		public static readonly ProfileFields Connections = RegisterPossibleValue(value: "connections");

		/// <summary>
		/// Для получения поля User.Site
		/// </summary>
		public static readonly ProfileFields Site = RegisterPossibleValue(value: "site");

		/// <summary>
		/// Для получения поля User.Education
		/// </summary>
		public static readonly ProfileFields Education = RegisterPossibleValue(value: "education");

		/// <summary>
		/// Для получения поля User.Universities
		/// </summary>
		public static readonly ProfileFields Universities = RegisterPossibleValue(value: "universities");

		/// <summary>
		/// Для получения поля User.Schools
		/// </summary>
		public static readonly ProfileFields Schools = RegisterPossibleValue(value: "schools");

		/// <summary>
		/// Для получения поля User.CanPost
		/// </summary>
		public static readonly ProfileFields CanPost = RegisterPossibleValue(value: "can_post");

		/// <summary>
		/// Для получения поля User.CanSeeAllPosts
		/// </summary>
		public static readonly ProfileFields CanSeeAllPosts = RegisterPossibleValue(value: "can_see_all_posts");

		/// <summary>
		/// Для получения поля User.CanSeeAudio
		/// </summary>
		public static readonly ProfileFields CanSeeAudio = RegisterPossibleValue(value: "can_see_audio");

		/// <summary>
		/// Для получения поля User.CanWritePrivateMessage
		/// </summary>
		public static readonly ProfileFields CanWritePrivateMessage = RegisterPossibleValue(value: "can_write_private_message");

		/// <summary>
		/// Для получения поля User.Status
		/// </summary>
		public static readonly ProfileFields Status = RegisterPossibleValue(value: "status");

		/// <summary>
		/// Для получения поля User.LastSeen
		/// </summary>
		public static readonly ProfileFields LastSeen = RegisterPossibleValue(value: "last_seen");

		/// <summary>
		/// Для получения поля User.CommonCount
		/// </summary>
		public static readonly ProfileFields CommonCount = RegisterPossibleValue(value: "common_count");

		/// <summary>
		/// Для получения поля User.Relation
		/// </summary>
		public static readonly ProfileFields Relation = RegisterPossibleValue(value: "relation");

		/// <summary>
		/// Для получения поля User.Relatives
		/// </summary>
		public static readonly ProfileFields Relatives = RegisterPossibleValue(value: "relatives");

		/// <summary>
		/// Для получения поля User.Counters
		/// </summary>
		public static readonly ProfileFields Counters = RegisterPossibleValue(value: "counters");

		/// <summary>
		/// Для получения поля User.Nickname
		/// </summary>
		public static readonly ProfileFields Nickname = RegisterPossibleValue(value: "nickname");

		/// <summary>
		/// Для получения поля User.Timezone
		/// </summary>
		public static readonly ProfileFields Timezone = RegisterPossibleValue(value: "timezone");

		/// <summary>
		/// Для получения поля User.Language
		/// </summary>
		public static readonly ProfileFields Language = RegisterPossibleValue(value: "lang");

		/// <summary>
		/// Для получения поля User.OnlineMobile
		/// </summary>
		public static readonly ProfileFields OnlineMobile = RegisterPossibleValue(value: "online_mobile");

		/// <summary>
		/// Для получения поля User.OnlineApp
		/// </summary>
		public static readonly ProfileFields OnlineApp = RegisterPossibleValue(value: "online_app");

		/// <summary>
		/// Для получения поля User.RelationPartner
		/// </summary>
		public static readonly ProfileFields RelationPartner = RegisterPossibleValue(value: "relation_partner");

		/// <summary>
		/// Для получения поля User.StandInLife
		/// </summary>
		public static readonly ProfileFields StandInLife = RegisterPossibleValue(value: "personal");

		/// <summary>
		/// Для получения поля User.Interests
		/// </summary>
		public static readonly ProfileFields Interests = RegisterPossibleValue(value: "interests");

		/// <summary>
		/// Для получения поля User.Music
		/// </summary>
		public static readonly ProfileFields Music = RegisterPossibleValue(value: "music");

		/// <summary>
		/// Для получения поля User.Activities
		/// </summary>
		public static readonly ProfileFields Activities = RegisterPossibleValue(value: "activities");

		/// <summary>
		/// Для получения поля User.Movies
		/// </summary>
		public static readonly ProfileFields Movies = RegisterPossibleValue(value: "movies");

		/// <summary>
		/// Для получения поля User.Tv
		/// </summary>
		public static readonly ProfileFields Tv = RegisterPossibleValue(value: "tv");

		/// <summary>
		/// Для получения поля User.Books
		/// </summary>
		public static readonly ProfileFields Books = RegisterPossibleValue(value: "books");

		/// <summary>
		/// Для получения поля User.Games
		/// </summary>
		public static readonly ProfileFields Games = RegisterPossibleValue(value: "games");

		/// <summary>
		/// Для получения поля User.About
		/// </summary>
		public static readonly ProfileFields About = RegisterPossibleValue(value: "about");

		/// <summary>
		/// Для получения поля User.Quotes
		/// </summary>
		public static readonly ProfileFields Quotes = RegisterPossibleValue(value: "quotes");

		/// <summary>
		/// Для получения поля User.InvitedBy
		/// </summary>
		public static readonly ProfileFields InvitedBy = RegisterPossibleValue(value: "invited_by");

		/// <summary>
		/// Для получения поля User.BlacklistedByMe
		/// </summary>
		public static readonly ProfileFields BlacklistedByMe = RegisterPossibleValue(value: "blacklisted_by_me");

		/// <summary>
		/// Для получения поля User.Blacklisted
		/// </summary>
		public static readonly ProfileFields Blacklisted = RegisterPossibleValue(value: "blacklisted");

		/// <summary>
		/// Для получения поля User.Military
		/// </summary>
		public static readonly ProfileFields Military = RegisterPossibleValue(value: "military");

		/// <summary>
		/// Для получения поля User.Career
		/// </summary>
		public static readonly ProfileFields Career = RegisterPossibleValue(value: "career");

		/// <summary>
		/// Для получения поля User.FriendStatus
		/// </summary>
		public static readonly ProfileFields FriendStatus = RegisterPossibleValue(value: "friend_status");

		/// <summary>
		/// Для получения поля User.IsFriend
		/// </summary>
		public static readonly ProfileFields IsFriend = RegisterPossibleValue(value: "is_friend");

		/// <summary>
		/// Для получения поля User.ScreenName
		/// </summary>
		public static readonly ProfileFields ScreenName = RegisterPossibleValue(value: "screen_name");

		/// <summary>
		/// Для получения поля User.IsHiddenFromFeed
		/// </summary>
		public static readonly ProfileFields IsHiddenFromFeed = RegisterPossibleValue(value: "is_hidden_from_feed");

		/// <summary>
		/// Для получения поля User.IsFavorite
		/// </summary>
		public static readonly ProfileFields IsFavorite = RegisterPossibleValue(value: "is_favorite");

		/// <summary>
		/// Для получения поля User.CanSendFriendRequest
		/// </summary>
		public static readonly ProfileFields CanSendFriendRequest = RegisterPossibleValue(value: "can_send_friend_request");

		/// <summary>
		/// Для получения поля User.WallComments
		/// </summary>
		public static readonly ProfileFields WallComments = RegisterPossibleValue(value: "wall_comments");

		/// <summary>
		/// Для получения поля User.Verified
		/// </summary>
		public static readonly ProfileFields Verified = RegisterPossibleValue(value: "verified");

		/// <summary>
		/// Для получения поля User.FollowersCount
		/// </summary>
		public static readonly ProfileFields FollowersCount = RegisterPossibleValue(value: "followers_count");

		/// <summary>
		/// Для получения поля User.CropPhoto
		/// </summary>
		public static readonly ProfileFields CropPhoto = RegisterPossibleValue(value: "crop_photo");

		/// <summary>
		/// Для получения поля User.Exports
		/// </summary>
		public static readonly ProfileFields Exports = RegisterPossibleValue(value: "exports");

		/// <summary>
		/// Для получения поля User.MaidenName
		/// </summary>
		public static readonly ProfileFields MaidenName = RegisterPossibleValue(value: "maiden_name");

		/// <summary>
		/// Для получения поля User.PhotoId
		/// </summary>
		public static readonly ProfileFields PhotoId = RegisterPossibleValue(value: "photo_id");

		/// <summary>
		/// Для получения всех документированных полей.
		/// </summary>
		public static readonly ProfileFields All = Uid
													|FirstName
													|LastName
													|Sex
													|BirthDate
													|City
													|Country
													|Photo50
													|Photo100
													|Photo200
													|Photo200Orig
													|Photo400Orig
													|PhotoMax
													|PhotoMaxOrig
													|Online
													|FriendLists
													|Domain
													|HasMobile
													|Contacts
													|Connections
													|Site
													|Education
													|Universities
													|Schools
													|CanPost
													|CanSeeAllPosts
													|CanSeeAudio
													|CanWritePrivateMessage
													|Status
													|LastSeen
													|CommonCount
													|Relation
													|Relatives
													|Counters
													|Nickname
													|Timezone
													|Language
													|OnlineMobile
													|OnlineApp
													|RelationPartner
													|StandInLife
													|Interests
													|Music
													|Activities
													|Movies
													|Tv
													|Books
													|Games
													|About
													|Quotes
													|InvitedBy
													|BlacklistedByMe
													|Blacklisted
													|Military
													|Career
													|FriendStatus
													|IsFriend
													|ScreenName
													|IsHiddenFromFeed
													|IsFavorite
													|CanSendFriendRequest
													|WallComments
													|Verified
													|FollowersCount
													|CropPhoto
													|Exports
													|MaidenName
													|PhotoId;
	}
}