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
		public static readonly ProfileFields Uid = RegisterPossibleValue("user_id");

		/// <summary>
		/// Для получения поля User.FirstName
		/// </summary>
		public static readonly ProfileFields FirstName = RegisterPossibleValue("first_name");

		/// <summary>
		/// Для получения поля User.LastName
		/// </summary>
		public static readonly ProfileFields LastName = RegisterPossibleValue("last_name");

		/// <summary>
		/// Для получения поля User.Sex
		/// </summary>
		public static readonly ProfileFields Sex = RegisterPossibleValue("sex");

		/// <summary>
		/// Для получения поля User.BirthDate
		/// </summary>
		public static readonly ProfileFields BirthDate = RegisterPossibleValue("bdate");

		/// <summary>
		/// Для получения поля User.City
		/// </summary>
		public static readonly ProfileFields City = RegisterPossibleValue("city");

		/// <summary>
		/// Для получения поля User.Country
		/// </summary>
		public static readonly ProfileFields Country = RegisterPossibleValue("country");

		/// <summary>
		/// Для получения поля Previews.Photo50
		/// </summary>
		public static readonly ProfileFields Photo50 = RegisterPossibleValue("photo_50");

		/// <summary>
		/// Для получения поля Previews.Photo100
		/// </summary>
		public static readonly ProfileFields Photo100 = RegisterPossibleValue("photo_100");

		/// <summary>
		/// Для получения поля Previews.Photo200
		/// </summary>
		public static readonly ProfileFields Photo200 = RegisterPossibleValue("photo_200");

		/// <summary>
		/// Для получения поля Previews.Photo200
		/// </summary>
		public static readonly ProfileFields Photo200Orig = RegisterPossibleValue("photo_200_orig");

		/// <summary>
		/// Для получения поля Previews.Photo400
		/// </summary>
		public static readonly ProfileFields Photo400Orig = RegisterPossibleValue("photo_400_orig");

		/// <summary>
		/// Для получения поля Previews.PhotoMax
		/// </summary>
		public static readonly ProfileFields PhotoMax = RegisterPossibleValue("photo_max");

		/// <summary>
		/// Для получения поля Previews.PhotoMax
		/// </summary>
		public static readonly ProfileFields PhotoMaxOrig = RegisterPossibleValue("photo_max_orig");

		/// <summary>
		/// Для получения поля User.Online
		/// </summary>
		public static readonly ProfileFields Online = RegisterPossibleValue("online");

		/// <summary>
		/// Для получения поля User.FriendLists
		/// </summary>
		public static readonly ProfileFields FriendLists = RegisterPossibleValue("lists");

		/// <summary>
		/// Для получения поля User.Domain
		/// </summary>
		public static readonly ProfileFields Domain = RegisterPossibleValue("domain");

		/// <summary>
		/// Для получения поля User.HasMobile
		/// </summary>
		public static readonly ProfileFields HasMobile = RegisterPossibleValue("has_mobile");

		/// <summary>
		/// Для получения полей User.MobilePhone
		/// </summary>
		public static readonly ProfileFields Contacts = RegisterPossibleValue("contacts");

		/// <summary>
		/// Для получения поля User.Connections
		/// </summary>
		public static readonly ProfileFields Connections = RegisterPossibleValue("connections");

		/// <summary>
		/// Для получения поля User.Site
		/// </summary>
		public static readonly ProfileFields Site = RegisterPossibleValue("site");

		/// <summary>
		/// Для получения поля User.Education
		/// </summary>
		public static readonly ProfileFields Education = RegisterPossibleValue("education");

		/// <summary>
		/// Для получения поля User.Universities
		/// </summary>
		public static readonly ProfileFields Universities = RegisterPossibleValue("universities");

		/// <summary>
		/// Для получения поля User.Schools
		/// </summary>
		public static readonly ProfileFields Schools = RegisterPossibleValue("schools");

		/// <summary>
		/// Для получения поля User.CanPost
		/// </summary>
		public static readonly ProfileFields CanPost = RegisterPossibleValue("can_post");

		/// <summary>
		/// Для получения поля User.CanSeeAllPosts
		/// </summary>
		public static readonly ProfileFields CanSeeAllPosts = RegisterPossibleValue("can_see_all_posts");

		/// <summary>
		/// Для получения поля User.CanSeeAudio
		/// </summary>
		public static readonly ProfileFields CanSeeAudio = RegisterPossibleValue("can_see_audio");

		/// <summary>
		/// Для получения поля User.CanWritePrivateMessage
		/// </summary>
		public static readonly ProfileFields CanWritePrivateMessage = RegisterPossibleValue("can_write_private_message");

		/// <summary>
		/// Для получения поля User.Status
		/// </summary>
		public static readonly ProfileFields Status = RegisterPossibleValue("status");

		/// <summary>
		/// Для получения поля User.LastSeen
		/// </summary>
		public static readonly ProfileFields LastSeen = RegisterPossibleValue("last_seen");

		/// <summary>
		/// Для получения поля User.CommonCount
		/// </summary>
		public static readonly ProfileFields CommonCount = RegisterPossibleValue("common_count");

		/// <summary>
		/// Для получения поля User.Relation
		/// </summary>
		public static readonly ProfileFields Relation = RegisterPossibleValue("relation");

		/// <summary>
		/// Для получения поля User.Relatives
		/// </summary>
		public static readonly ProfileFields Relatives = RegisterPossibleValue("relatives");

		/// <summary>
		/// Для получения поля User.Counters
		/// </summary>
		public static readonly ProfileFields Counters = RegisterPossibleValue("counters");

		/// <summary>
		/// Для получения поля User.Nickname
		/// </summary>
		public static readonly ProfileFields Nickname = RegisterPossibleValue("nickname");

		/// <summary>
		/// Для получения поля User.Timezone
		/// </summary>
		public static readonly ProfileFields Timezone = RegisterPossibleValue("timezone");

		/// <summary>
		/// Для получения поля User.Language
		/// </summary>
		public static readonly ProfileFields Language = RegisterPossibleValue("lang");

		/// <summary>
		/// Для получения поля User.OnlineMobile
		/// </summary>
		public static readonly ProfileFields OnlineMobile = RegisterPossibleValue("online_mobile");

		/// <summary>
		/// Для получения поля User.OnlineApp
		/// </summary>
		public static readonly ProfileFields OnlineApp = RegisterPossibleValue("online_app");

		/// <summary>
		/// Для получения поля User.RelationPartner
		/// </summary>
		public static readonly ProfileFields RelationPartner = RegisterPossibleValue("relation_partner");

		/// <summary>
		/// Для получения поля User.StandInLife
		/// </summary>
		public static readonly ProfileFields StandInLife = RegisterPossibleValue("personal");

		/// <summary>
		/// Для получения поля User.Interests
		/// </summary>
		public static readonly ProfileFields Interests = RegisterPossibleValue("interests");

		/// <summary>
		/// Для получения поля User.Music
		/// </summary>
		public static readonly ProfileFields Music = RegisterPossibleValue("music");

		/// <summary>
		/// Для получения поля User.Activities
		/// </summary>
		public static readonly ProfileFields Activities = RegisterPossibleValue("activities");

		/// <summary>
		/// Для получения поля User.Movies
		/// </summary>
		public static readonly ProfileFields Movies = RegisterPossibleValue("movies");

		/// <summary>
		/// Для получения поля User.Tv
		/// </summary>
		public static readonly ProfileFields Tv = RegisterPossibleValue("tv");

		/// <summary>
		/// Для получения поля User.Books
		/// </summary>
		public static readonly ProfileFields Books = RegisterPossibleValue("books");

		/// <summary>
		/// Для получения поля User.Games
		/// </summary>
		public static readonly ProfileFields Games = RegisterPossibleValue("games");

		/// <summary>
		/// Для получения поля User.About
		/// </summary>
		public static readonly ProfileFields About = RegisterPossibleValue("about");

		/// <summary>
		/// Для получения поля User.Quotes
		/// </summary>
		public static readonly ProfileFields Quotes = RegisterPossibleValue("quotes");

		/// <summary>
		/// Для получения поля User.InvitedBy
		/// </summary>
		public static readonly ProfileFields InvitedBy = RegisterPossibleValue("invited_by");

		/// <summary>
		/// Для получения поля User.BlacklistedByMe
		/// </summary>
		public static readonly ProfileFields BlacklistedByMe = RegisterPossibleValue("blacklisted_by_me");

		/// <summary>
		/// Для получения поля User.Blacklisted
		/// </summary>
		public static readonly ProfileFields Blacklisted = RegisterPossibleValue("blacklisted");

		/// <summary>
		/// Для получения поля User.Military
		/// </summary>
		public static readonly ProfileFields Military = RegisterPossibleValue("military");

		/// <summary>
		/// Для получения поля User.Career
		/// </summary>
		public static readonly ProfileFields Career = RegisterPossibleValue("career");

		/// <summary>
		/// Для получения поля User.FriendStatus
		/// </summary>
		public static readonly ProfileFields FriendStatus = RegisterPossibleValue("friend_status");

		/// <summary>
		/// Для получения поля User.IsFriend
		/// </summary>
		public static readonly ProfileFields IsFriend = RegisterPossibleValue("is_friend");

		/// <summary>
		/// Для получения поля User.ScreenName
		/// </summary>
		public static readonly ProfileFields ScreenName = RegisterPossibleValue("screen_name");

		/// <summary>
		/// Для получения поля User.IsHiddenFromFeed
		/// </summary>
		public static readonly ProfileFields IsHiddenFromFeed = RegisterPossibleValue("is_hidden_from_feed");

		/// <summary>
		/// Для получения поля User.IsFavorite
		/// </summary>
		public static readonly ProfileFields IsFavorite = RegisterPossibleValue("is_favorite");

		/// <summary>
		/// Для получения поля User.CanSendFriendRequest
		/// </summary>
		public static readonly ProfileFields CanSendFriendRequest = RegisterPossibleValue("can_send_friend_request");

		/// <summary>
		/// Для получения поля User.WallComments
		/// </summary>
		public static readonly ProfileFields WallComments = RegisterPossibleValue("wall_comments");

		/// <summary>
		/// Для получения поля User.Verified
		/// </summary>
		public static readonly ProfileFields Verified = RegisterPossibleValue("verified");

		/// <summary>
		/// Для получения поля User.FollowersCount
		/// </summary>
		public static readonly ProfileFields FollowersCount = RegisterPossibleValue("followers_count");

		/// <summary>
		/// Для получения поля User.CropPhoto
		/// </summary>
		public static readonly ProfileFields CropPhoto = RegisterPossibleValue("crop_photo");

		/// <summary>
		/// Для получения поля User.Exports
		/// </summary>
		public static readonly ProfileFields Exports = RegisterPossibleValue("exports");

		/// <summary>
		/// Для получения поля User.MaidenName
		/// </summary>
		public static readonly ProfileFields MaidenName = RegisterPossibleValue("maiden_name");

		/// <summary>
		/// Для получения поля User.PhotoId
		/// </summary>
		public static readonly ProfileFields PhotoId = RegisterPossibleValue("photo_id");

		/// <summary>
		/// Для получения поля User.HomeTown
		/// </summary>
		public static readonly ProfileFields HomeTown = RegisterPossibleValue("home_town");

		/// <summary>
		/// Для получения поля User.Occupation
		/// </summary>
		public static readonly ProfileFields Occupation = RegisterPossibleValue("occupation");

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
													|PhotoId
													|HomeTown
													|Occupation;
	}
}