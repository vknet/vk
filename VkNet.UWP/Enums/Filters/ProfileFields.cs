using VkNet.Model;

namespace VkNet.Enums.Filters
{
    /// <summary>
    /// Требуемые для получения поля профиля.
    /// См. описание <see href="http://vk.com/pages?oid=-1&amp;p=Описание_полей_параметра_fields"/>.
    /// </summary>
    public sealed class ProfileFields : MultivaluedFilter<ProfileFields>
    {
        /// <summary>
        /// Для получения поля User.Id
        /// </summary>
        public static readonly ProfileFields Uid = RegisterPossibleValue(1L << 0, "user_id");

        /// <summary>
        /// Для получения поля User.FirstName
        /// </summary>
        public static readonly ProfileFields FirstName = RegisterPossibleValue(1L << 1, "first_name");

        /// <summary>
        /// Для получения поля User.LastName
        /// </summary>
        public static readonly ProfileFields LastName = RegisterPossibleValue(1L << 2, "last_name");

        /// <summary>
        /// Для получения поля User.Sex
        /// </summary>
        public static readonly ProfileFields Sex = RegisterPossibleValue(1L << 3, "sex");

        /// <summary>
        /// Для получения поля User.BirthDate
        /// </summary>
        public static readonly ProfileFields BirthDate = RegisterPossibleValue(1L << 4, "bdate");

        /// <summary>
        /// Для получения поля User.City
        /// </summary>
        public static readonly ProfileFields City = RegisterPossibleValue(1L << 5, "city");

        /// <summary>
        /// Для получения поля User.Country
        /// </summary>
        public static readonly ProfileFields Country = RegisterPossibleValue(1L << 6, "country");

        /// <summary>
        /// Для получения поля Previews.Photo50
        /// </summary>
        public static readonly ProfileFields Photo50 = RegisterPossibleValue(1L << 7, "photo_50");

        /// <summary>
        /// Для получения поля Previews.Photo100
        /// </summary>
        public static readonly ProfileFields Photo100 = RegisterPossibleValue(1L << 8, "photo_100");

        /// <summary>
        /// Для получения поля Previews.Photo200
        /// </summary>
        public static readonly ProfileFields Photo200 = RegisterPossibleValue(1L << 9, "photo_200");

        /// <summary>
        /// Для получения поля Previews.Photo200
        /// </summary>
        public static readonly ProfileFields Photo200Orig = RegisterPossibleValue(1L << 10, "photo_200_orig");

        /// <summary>
        /// Для получения поля Previews.Photo400
        /// </summary>
        public static readonly ProfileFields Photo400Orig = RegisterPossibleValue(1L << 11, "photo_400_orig");

        /// <summary>
        /// Для получения поля Previews.PhotoMax
        /// </summary>
        public static readonly ProfileFields PhotoMax = RegisterPossibleValue(1L << 12, "photo_max");

        /// <summary>
        /// Для получения поля Previews.PhotoMax
        /// </summary>
        public static readonly ProfileFields PhotoMaxOrig = RegisterPossibleValue(1L << 13, "photo_max_orig");

        /// <summary>
        /// Для получения поля User.Online
        /// </summary>
        public static readonly ProfileFields Online = RegisterPossibleValue(1L << 14, "online");

        /// <summary>
        /// Для получения поля User.FriendLists
        /// </summary>
        public static readonly ProfileFields FriendLists = RegisterPossibleValue(1L << 15, "lists");

        /// <summary>
        /// Для получения поля User.Domain
        /// </summary>
        public static readonly ProfileFields Domain = RegisterPossibleValue(1L << 16, "domain");

        /// <summary>
        /// Для получения поля User.HasMobile
        /// </summary>
        public static readonly ProfileFields HasMobile = RegisterPossibleValue(1L << 17, "has_mobile");

        /// <summary>
        /// Для получения полей User.MobilePhone
        /// </summary>
        public static readonly ProfileFields Contacts = RegisterPossibleValue(1L << 18, "contacts");

        /// <summary>
        /// Для получения поля User.Connections
        /// </summary>
        public static readonly ProfileFields Connections = RegisterPossibleValue(1L << 19, "connections");

        /// <summary>
        /// Для получения поля User.Site
        /// </summary>
        public static readonly ProfileFields Site = RegisterPossibleValue(1L << 20, "site");

        /// <summary>
        /// Для получения поля User.Education
        /// </summary>
        public static readonly ProfileFields Education = RegisterPossibleValue(1L << 21, "education");

        /// <summary>
        /// Для получения поля User.Universities
        /// </summary>
        public static readonly ProfileFields Universities = RegisterPossibleValue(1L << 22, "universities");

        /// <summary>
        /// Для получения поля User.Schools
        /// </summary>
        public static readonly ProfileFields Schools = RegisterPossibleValue(1L << 23, "schools");

        /// <summary>
        /// Для получения поля User.CanPost
        /// </summary>
        public static readonly ProfileFields CanPost = RegisterPossibleValue(1L << 24, "can_post");

        /// <summary>
        /// Для получения поля User.CanSeeAllPosts
        /// </summary>
        public static readonly ProfileFields CanSeeAllPosts = RegisterPossibleValue(1L << 25, "can_see_all_posts");

        /// <summary>
        /// Для получения поля User.CanSeeAudio
        /// </summary>
        public static readonly ProfileFields CanSeeAudio = RegisterPossibleValue(1L << 26, "can_see_audio");

        /// <summary>
        /// Для получения поля User.CanWritePrivateMessage
        /// </summary>
        public static readonly ProfileFields CanWritePrivateMessage = RegisterPossibleValue(1L << 27, "can_write_private_message");

        /// <summary>
        /// Для получения поля User.Status
        /// </summary>
        public static readonly ProfileFields Status = RegisterPossibleValue(1L << 28, "status");

        /// <summary>
        /// Для получения поля User.LastSeen
        /// </summary>
        public static readonly ProfileFields LastSeen = RegisterPossibleValue(1L << 29, "last_seen");

        /// <summary>
        /// Для получения поля User.CommonCount
        /// </summary>
        public static readonly ProfileFields CommonCount = RegisterPossibleValue(1L << 30, "common_count");

        /// <summary>
        /// Для получения поля User.Relation
        /// </summary>
        public static readonly ProfileFields Relation = RegisterPossibleValue(1L << 31, "relation");

        /// <summary>
        /// Для получения поля User.Relatives
        /// </summary>
        public static readonly ProfileFields Relatives = RegisterPossibleValue(1L << 32, "relatives");

        /// <summary>
        /// Для получения поля User.Counters
        /// </summary>
        public static readonly ProfileFields Counters = RegisterPossibleValue(1L << 33, "counters");

        /// <summary>
        /// Для получения поля User.Nickname
        /// </summary>
        public static readonly ProfileFields Nickname = RegisterPossibleValue(1L << 34, "nickname");

        /// <summary>
        /// Для получения поля User.Timezone
        /// </summary>
        public static readonly ProfileFields Timezone = RegisterPossibleValue(1L << 35, "timezone");

        /// <summary>
        /// Для получения поля User.Language
        /// </summary>
        public static readonly ProfileFields Language = RegisterPossibleValue(1L << 36, "lang");

        /// <summary>
        /// Для получения поля User.OnlineMobile
        /// </summary>
        public static readonly ProfileFields OnlineMobile = RegisterPossibleValue(1L << 37, "online_mobile");

        /// <summary>
        /// Для получения поля User.OnlineApp
        /// </summary>
        public static readonly ProfileFields OnlineApp = RegisterPossibleValue(1L << 38, "online_app");

        /// <summary>
        /// Для получения поля User.RelationPartner
        /// </summary>
        public static readonly ProfileFields RelationPartner = RegisterPossibleValue(1L << 39, "relation_partner");

        /// <summary>
        /// Для получения поля User.StandInLife
        /// </summary>
        public static readonly ProfileFields StandInLife = RegisterPossibleValue(1L << 40, "personal");

        /// <summary>
        /// Для получения поля User.Interests
        /// </summary>
        public static readonly ProfileFields Interests = RegisterPossibleValue(1L << 41, "interests");

        /// <summary>
        /// Для получения поля User.Music
        /// </summary>
        public static readonly ProfileFields Music = RegisterPossibleValue(1L << 42, "music");

        /// <summary>
        /// Для получения поля User.Activities
        /// </summary>
        public static readonly ProfileFields Activities = RegisterPossibleValue(1L << 43, "activities");

        /// <summary>
        /// Для получения поля User.Movies
        /// </summary>
        public static readonly ProfileFields Movies = RegisterPossibleValue(1L << 44, "movies");

        /// <summary>
        /// Для получения поля User.Tv
        /// </summary>
        public static readonly ProfileFields Tv = RegisterPossibleValue(1L << 45, "tv");

        /// <summary>
        /// Для получения поля User.Books
        /// </summary>
        public static readonly ProfileFields Books = RegisterPossibleValue(1L << 46, "books");

        /// <summary>
        /// Для получения поля User.Games
        /// </summary>
        public static readonly ProfileFields Games = RegisterPossibleValue(1L << 47, "games");

        /// <summary>
        /// Для получения поля User.About
        /// </summary>
        public static readonly ProfileFields About = RegisterPossibleValue(1L << 48, "about");

        /// <summary>
        /// Для получения поля User.Quotes
        /// </summary>
        public static readonly ProfileFields Quotes = RegisterPossibleValue(1L << 49, "quotes");

        /// <summary>
        /// Для получения поля User.InvitedBy
        /// </summary>
        public static readonly ProfileFields InvitedBy = RegisterPossibleValue(1L << 50, "invited_by");

        /// <summary>
        /// Для получения поля User.BlacklistedByMe
        /// </summary>
        public static readonly ProfileFields BlacklistedByMe = RegisterPossibleValue(1L << 51, "blacklisted_by_me");

        /// <summary>
        /// Для получения поля User.Blacklisted
        /// </summary>
        public static readonly ProfileFields Blacklisted = RegisterPossibleValue(1L << 52, "blacklisted");

        /// <summary>
        /// Для получения поля User.Military
        /// </summary>
        public static readonly ProfileFields Military = RegisterPossibleValue(1L << 53, "military");

        /// <summary>
        /// Для получения поля User.Career
        /// </summary>
        public static readonly ProfileFields Career = RegisterPossibleValue(1L << 54, "career");

        /// <summary>
        /// Для получения поля User.FriendStatus
        /// </summary>
        public static readonly ProfileFields FriendStatus = RegisterPossibleValue(1L << 55, "friend_status");

        /// <summary>
        /// Для получения поля User.IsFriend
        /// </summary>
        public static readonly ProfileFields IsFriend = RegisterPossibleValue(1L << 56, "is_friend");

        /// <summary>
        /// Для получения поля User.ScreenName
        /// </summary>
        public static readonly ProfileFields ScreenName = RegisterPossibleValue(1L << 57, "screen_name");

        /// <summary>
        /// Для получения поля User.IsHiddenFromFeed
        /// </summary>
        public static readonly ProfileFields IsHiddenFromFeed = RegisterPossibleValue(1L << 58, "is_hidden_from_feed");

        /// <summary>
        /// Для получения поля User.IsFavorite
        /// </summary>
        public static readonly ProfileFields IsFavorite = RegisterPossibleValue(1L << 59, "is_favorite");

        /// <summary>
        /// Для получения поля User.CanSendFriendRequest
        /// </summary>
        public static readonly ProfileFields CanSendFriendRequest = RegisterPossibleValue(1L << 60, "can_send_friend_request");

        /// <summary>
        /// Для получения поля User.WallComments
        /// </summary>
        public static readonly ProfileFields WallComments = RegisterPossibleValue(1L << 61, "wall_comments");

        /// <summary>
        /// Для получения поля User.Verified
        /// </summary>
        public static readonly ProfileFields Verified = RegisterPossibleValue(1L << 62, "verified");

        /// <summary>
        /// Для получения поля User.FollowersCount
        /// </summary>
        public static readonly ProfileFields FollowersCount = RegisterPossibleValue(1UL << 63, "followers_count");

        /// <summary>
        /// Для получения всех документированных полей.
        /// </summary>
        public static readonly ProfileFields All = Uid | FirstName | LastName | Sex | BirthDate | City | Country | Photo50 | Photo100 |
            Photo200 | Photo200Orig | Photo400Orig | PhotoMax | PhotoMaxOrig | Online | FriendLists | Domain | HasMobile | Contacts |
            Connections | Site | Education | Universities | Schools | CanPost | CanSeeAllPosts | CanSeeAudio | CanWritePrivateMessage |
            Status | LastSeen | CommonCount | Relation | Relatives | Counters | Nickname | Timezone | Verified | WallComments | CanSendFriendRequest |
            IsFavorite | IsHiddenFromFeed | ScreenName | IsFriend | FriendStatus | Career | Military | Blacklisted | BlacklistedByMe | FollowersCount;

        /// <summary>
        /// Для получения всех полей, вколючая недокументированные.
        /// </summary>
        public static readonly ProfileFields AllUndocumented = All | Language | OnlineMobile | OnlineApp | RelationPartner |
            StandInLife | Interests | Music | Activities | Movies | Tv | Books | Games | About | Quotes | InvitedBy;

    }
}