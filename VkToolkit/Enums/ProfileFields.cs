namespace VkToolkit.Enums
{
    using System.Collections.Generic;
    using System.Linq;

    using VkToolkit.Model;
    using VkToolkit.Utils;

    /// <summary>
    /// Требуемые для получения поля профиля.
    /// См. описание <see cref="http://vk.com/pages?oid=-1&p=%D0%9E%D0%BF%D0%B8%D1%81%D0%B0%D0%BD%D0%B8%D0%B5_%D0%BF%D0%BE%D0%BB%D0%B5%D0%B9_%D0%BF%D0%B0%D1%80%D0%B0%D0%BC%D0%B5%D1%82%D1%80%D0%B0_fields"/>.
    /// </summary>
    public sealed class ProfileFields
    {
        /// <summary>
        /// Имя поля.
        /// </summary>
        private readonly string _name;

        /// <summary>
        /// Флаговое значение поля.
        /// </summary>
        private readonly long _value;

        /// <summary>
        /// Список полей.
        /// </summary>
        private readonly IList<ProfileFields> _fields;

        /// <summary>
        /// Для получения поля <see cref="User.Id"/>. Это поле возвращается всегда, поэтому его можно не указывать.
        /// </summary>
        public static readonly ProfileFields Uid = new ProfileFields(1L << 0, "uid");

        /// <summary>
        /// Для получения поля <see cref="User.FirstName"/>. Это поле возвращается всегда, поэтому его можно не указывать.
        /// </summary>
        public static readonly ProfileFields FirstName = new ProfileFields(1L << 1, "first_name");

        /// <summary>
        /// Для получения поля <see cref="User.LastName"/>. Это поле возвращается всегда, поэтому его можно не указывать.
        /// </summary>
        public static readonly ProfileFields LastName = new ProfileFields(1L << 2, "last_name");

        /// <summary>
        /// Для получения поля <see cref="User.Sex"/>. 
        /// </summary>
        public static readonly ProfileFields Sex = new ProfileFields(1L << 3, "sex");

        /// <summary>
        /// Для получения поля <see cref="User.BirthDate"/>. 
        /// </summary>
        public static readonly ProfileFields BirthDate = new ProfileFields(1L << 4, "bdate");

        /// <summary>
        /// Для получения поля <see cref="User.City"/>. 
        /// </summary>
        public static readonly ProfileFields City = new ProfileFields(1L << 5, "city");

        /// <summary>
        /// Для получения поля <see cref="User.Country"/>. 
        /// </summary>
        public static readonly ProfileFields Country = new ProfileFields(1L << 6, "country");

        /// <summary>
        /// Для получения поля <see cref="Previews.Photo50"/>. 
        /// </summary>
        public static readonly ProfileFields Photo50 = new ProfileFields(1L << 7, "photo_50");

        /// <summary>
        /// Для получения поля <see cref="Previews.Photo100"/>. 
        /// </summary>
        public static readonly ProfileFields Photo100 = new ProfileFields(1L << 8, "photo_100");

        /// <summary>
        /// Для получения поля <see cref="Previews.Photo200"/>. 
        /// </summary>
        public static readonly ProfileFields Photo200 = new ProfileFields(1L << 9, "photo_200");

        /// <summary>
        /// Для получения поля <see cref="Previews.Photo200"/>. 
        /// </summary>
        public static readonly ProfileFields Photo200Orig = new ProfileFields(1L << 10, "photo_200_orig");

        /// <summary>
        /// Для получения поля <see cref="Previews.Photo400"/>. 
        /// </summary>
        public static readonly ProfileFields Photo400Orig = new ProfileFields(1L << 11, "photo_400_orig");

        /// <summary>
        /// Для получения поля <see cref="Previews.PhotoMax"/>. 
        /// </summary>
        public static readonly ProfileFields PhotoMax = new ProfileFields(1L << 12, "photo_max");

        /// <summary>
        /// Для получения поля <see cref="Previews.PhotoMax"/>. 
        /// </summary>
        public static readonly ProfileFields PhotoMaxOrig = new ProfileFields(1L << 13, "photo_max_orig");

        /// <summary>
        /// Для получения поля <see cref="User.Online"/>. 
        /// </summary>
        public static readonly ProfileFields Online = new ProfileFields(1L << 14, "online");

        /// <summary>
        /// Для получения поля <see cref="User.FriendLists"/>. 
        /// </summary>
        public static readonly ProfileFields FriendLists = new ProfileFields(1L << 15, "lists");

        /// <summary>
        /// Для получения поля <see cref="User.Domain"/>. 
        /// </summary>
        public static readonly ProfileFields Domain = new ProfileFields(1L << 16, "screen_name");

        /// <summary>
        /// Для получения поля <see cref="User.HasMobile"/>. 
        /// </summary>
        public static readonly ProfileFields HasMobile = new ProfileFields(1L << 17, "has_mobile");

        /// <summary>
        /// Для получения полей <see cref="User.MobilePhone"/> и <see cref="User.HomePhone"/>. 
        /// </summary>
        public static readonly ProfileFields Contacts = new ProfileFields(1L << 18, "contacts");

        /// <summary>
        /// Для получения поля <see cref="User.Connections"/>. 
        /// </summary>
        public static readonly ProfileFields Connections = new ProfileFields(1L << 19, "connections");

        /// <summary>
        /// Для получения поля <see cref="User.Site"/>. 
        /// </summary>
        public static readonly ProfileFields Site = new ProfileFields(1L << 20, "site");

        /// <summary>
        /// Для получения поля <see cref="User.Education"/>. 
        /// </summary>
        public static readonly ProfileFields Education = new ProfileFields(1L << 21, "education");

        /// <summary>
        /// Для получения поля <see cref="User.Universities"/>. 
        /// </summary>
        public static readonly ProfileFields Universities = new ProfileFields(1L << 22, "universities");

        /// <summary>
        /// Для получения поля <see cref="User.Schools"/>. 
        /// </summary>
        public static readonly ProfileFields Schools = new ProfileFields(1L << 23, "schools");

        /// <summary>
        /// Для получения поля <see cref="User.CanPost"/>. 
        /// </summary>
        public static readonly ProfileFields CanPost = new ProfileFields(1L << 24, "can_post");

        /// <summary>
        /// Для получения поля <see cref="User.CanSeeAllPosts"/>. 
        /// </summary>
        public static readonly ProfileFields CanSeeAllPosts = new ProfileFields(1L << 25, "can_see_all_posts");

        /// <summary>
        /// Для получения поля <see cref="User.CanSeeAudio"/>. 
        /// </summary>
        public static readonly ProfileFields CanSeeAudio = new ProfileFields(1L << 26, "can_see_audio");

        /// <summary>
        /// Для получения поля <see cref="User.CanWritePrivateMessage"/>. 
        /// </summary>
        public static readonly ProfileFields CanWritePrivateMessage = new ProfileFields(1L << 27, "can_write_private_message");

        /// <summary>
        /// Для получения поля <see cref="User.Status"/>. 
        /// </summary>
        public static readonly ProfileFields Status = new ProfileFields(1L << 28, "status");

        /// <summary>
        /// Для получения поля <see cref="User.LastSeen"/>. 
        /// </summary>
        public static readonly ProfileFields LastSeen = new ProfileFields(1L << 29, "last_seen");

        /// <summary>
        /// Для получения поля <see cref="User.CommonCount"/>. 
        /// </summary>
        public static readonly ProfileFields CommonCount = new ProfileFields(1L << 30, "common_count");

        /// <summary>
        /// Для получения поля <see cref="User.Relation"/>. 
        /// </summary>
        public static readonly ProfileFields Relation = new ProfileFields(1L << 31, "relation");

        /// <summary>
        /// Для получения поля <see cref="User.Relatives"/>. 
        /// </summary>
        public static readonly ProfileFields Relatives = new ProfileFields(1L << 32, "relatives");

        /// <summary>
        /// Для получения поля <see cref="User.Counters"/>. 
        /// </summary>
        public static readonly ProfileFields Counters = new ProfileFields(1L << 33, "counters");

        /// <summary>
        /// Для получения поля <see cref="User.Nickname"/>. 
        /// </summary>
        public static readonly ProfileFields Nickname = new ProfileFields(1L << 34, "nickname");

        /// <summary>
        /// Для получения поля <see cref="User.Timezone"/>. 
        /// </summary>
        public static readonly ProfileFields Timezone = new ProfileFields(1L << 35, "timezone");

        /// <summary>
        /// Для получения поля <see cref="User.Language"/>. 
        /// </summary>
        public static readonly ProfileFields Language = new ProfileFields(1L << 36, "lang");

        /// <summary>
        /// Для получения поля <see cref="User.OnlineMobile"/>. 
        /// </summary>
        public static readonly ProfileFields OnlineMobile = new ProfileFields(1L << 37, "online_mobile");

        /// <summary>
        /// Для получения поля <see cref="User.OnlineApp"/>. 
        /// </summary>
        public static readonly ProfileFields OnlineApp = new ProfileFields(1L << 38, "online_app");

        /// <summary>
        /// Для получения поля <see cref="User.RelationPartner"/>. 
        /// </summary>
        public static readonly ProfileFields RelationPartner = new ProfileFields(1L << 39, "relation_partner");

        /// <summary>
        /// Для получения поля <see cref="User.StandInLife"/>. 
        /// </summary>
        public static readonly ProfileFields StandInLife = new ProfileFields(1L << 40, "personal");

        /// <summary>
        /// Для получения поля <see cref="User.Interests"/>. 
        /// </summary>
        public static readonly ProfileFields Interests = new ProfileFields(1L << 41, "interests");

        /// <summary>
        /// Для получения поля <see cref="User.Music"/>. 
        /// </summary>
        public static readonly ProfileFields Music = new ProfileFields(1L << 42, "music");

        /// <summary>
        /// Для получения поля <see cref="User.Activities"/>. 
        /// </summary>
        public static readonly ProfileFields Activities = new ProfileFields(1L << 43, "activities");

        /// <summary>
        /// Для получения поля <see cref="User.Movies"/>. 
        /// </summary>
        public static readonly ProfileFields Movies = new ProfileFields(1L << 44, "movies");

        /// <summary>
        /// Для получения поля <see cref="User.Tv"/>. 
        /// </summary>
        public static readonly ProfileFields Tv = new ProfileFields(1L << 45, "tv");

        /// <summary>
        /// Для получения поля <see cref="User.Books"/>. 
        /// </summary>
        public static readonly ProfileFields Books = new ProfileFields(1L << 46, "books");

        /// <summary>
        /// Для получения поля <see cref="User.Games"/>. 
        /// </summary>
        public static readonly ProfileFields Games = new ProfileFields(1L << 47, "games");

        /// <summary>
        /// Для получения поля <see cref="User.About"/>. 
        /// </summary>
        public static readonly ProfileFields About = new ProfileFields(1L << 48, "about");

        /// <summary>
        /// Для получения поля <see cref="User.Quotes"/>. 
        /// </summary>
        public static readonly ProfileFields Quotes = new ProfileFields(1L << 49, "quotes");

        /// <summary>
        /// Для получения поля <see cref="User.InvitedBy"/>. 
        /// </summary>        
        public static readonly ProfileFields InvitedBy = new ProfileFields(1L << 50, "invited_by");

        /// <summary>
        /// Для получения всех документированных полей.
        /// </summary>
        public static readonly ProfileFields All = Uid | FirstName | LastName | Sex | BirthDate | City | Country | Photo50 | Photo100 |
            Photo200 | Photo200Orig | Photo400Orig | PhotoMax | PhotoMaxOrig | Online | FriendLists | Domain | HasMobile | Contacts |
            Connections | Site | Education | Universities | Schools | CanPost | CanSeeAllPosts | CanSeeAudio | CanWritePrivateMessage | 
            Status | LastSeen | CommonCount | Relation | Relatives | Counters | Nickname | Timezone;

        /// <summary>
        /// Для получения всех полей, вколючая недокументированные.
        /// </summary>
        public static readonly ProfileFields AllUndocumented = All | Language | OnlineMobile | OnlineApp | RelationPartner | 
            StandInLife | Interests | Music | Activities | Movies | Tv | Books | Games | About | Quotes | InvitedBy;

        private ProfileFields(long value, string name)
        {
            _value = value;
            _name = name;
        }

        private ProfileFields(ProfileFields f1, ProfileFields f2)
        {
            _fields = new List<ProfileFields>();

            if (f1._fields != null && f1._fields.Count != 0)
            {
                foreach (var f in f1._fields)
                {
                    if (_fields.All(m => m._value != f._value))
                        _fields.Add(f);
                }
            }
            else
            {
                if (_fields.All(m => m._value != f1._value))
                    _fields.Add(f1);
            }

            if (f2._fields != null && f2._fields.Count != 0)
            {
                foreach (var f in f2._fields)
                {
                    if (_fields.All(m => m._value != f._value))
                        _fields.Add(f);
                }
            }
            else
            {
                if (_fields.All(m => m._value != f2._value))
                    _fields.Add(f2);
            }
        }

        public static ProfileFields operator |(ProfileFields f1, ProfileFields f2)
        {
            return new ProfileFields(f1, f2);
        }

        public override string ToString()
        {
            if (_fields == null || _fields.Count == 0)
                return _name;

            return _fields.Select(f => f._name).JoinNonEmpty();
        }
    }
}