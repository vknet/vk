namespace VkToolkit.Enums
{
    using System.Collections.Generic;
    using System.Linq;

    using VkToolkit.Utils;

    public sealed class ProfileFields
    {
        private readonly string _name;

        private readonly int _value;

        private readonly IList<ProfileFields> _fields;

        //public static readonly ProfileFields None = new ProfileFields(0, "none");
        public static readonly ProfileFields Uid = new ProfileFields(1, "uid");

        public static readonly ProfileFields FirstName = new ProfileFields(2, "first_name");

        public static readonly ProfileFields LastName = new ProfileFields(3, "last_name");

        public static readonly ProfileFields Nickname = new ProfileFields(4, "nickname");

        public static readonly ProfileFields ScreenName = new ProfileFields(5, "screen_name");

        public static readonly ProfileFields Sex = new ProfileFields(6, "sex");

        public static readonly ProfileFields BirthDay = new ProfileFields(7, "bdate");

        public static readonly ProfileFields City = new ProfileFields(8, "city");

        public static readonly ProfileFields Country = new ProfileFields(9, "country");

        public static readonly ProfileFields Timezone = new ProfileFields(10, "timezone");

        public static readonly ProfileFields Photo50 = new ProfileFields(11, "photo_50");

        public static readonly ProfileFields Photo100 = new ProfileFields(12, "photo_100");

        public static readonly ProfileFields Photo200Orig = new ProfileFields(13, "photo_200_orig");

        public static readonly ProfileFields HasMobile = new ProfileFields(14, "has_mobile");

        public static readonly ProfileFields Contacts = new ProfileFields(15, "contacts");

        public static readonly ProfileFields Education = new ProfileFields(16, "education");

        public static readonly ProfileFields Online = new ProfileFields(17, "online");

        public static readonly ProfileFields Counters = new ProfileFields(18, "counters");

        public static readonly ProfileFields Relation = new ProfileFields(19, "relation");

        public static readonly ProfileFields LastSeen = new ProfileFields(20, "last_seen");

        public static readonly ProfileFields Status = new ProfileFields(21, "status");

        public static readonly ProfileFields CanWritePrivateMessage = new ProfileFields(22, "can_write_private_message");

        public static readonly ProfileFields CanSeeAllPosts = new ProfileFields(23, "can_see_all_posts");

        public static readonly ProfileFields CanSeeAudio = new ProfileFields(24, "can_see_audio");

        public static readonly ProfileFields CanPost = new ProfileFields(25, "can_post");

        public static readonly ProfileFields Universities = new ProfileFields(26, "universities");

        public static readonly ProfileFields Schools = new ProfileFields(27, "schools");

        public static readonly ProfileFields Verified = new ProfileFields(28, "verified");

        public static readonly ProfileFields Connections = new ProfileFields(29, "connections");

        public static readonly ProfileFields Site = new ProfileFields(30, "site");

        public static readonly ProfileFields Relatives = new ProfileFields(31, "relatives");

        public static readonly ProfileFields Activities = new ProfileFields(32, "activities");

        public static readonly ProfileFields Interests = new ProfileFields(33, "interests");

        public static readonly ProfileFields Music = new ProfileFields(34, "music");

        public static readonly ProfileFields Movies = new ProfileFields(35, "movies");

        public static readonly ProfileFields Tv = new ProfileFields(36, "tv");

        public static readonly ProfileFields Books = new ProfileFields(37, "books");

        public static readonly ProfileFields Games = new ProfileFields(38, "games");

        public static readonly ProfileFields Quotes = new ProfileFields(39, "quotes");

        public static readonly ProfileFields About = new ProfileFields(40, "about");

        public static readonly ProfileFields Lang = new ProfileFields(41, "lang");

        public static readonly ProfileFields Personal = new ProfileFields(42, "personal");

        public static readonly ProfileFields Photo400Orig = new ProfileFields(43, "photo_400_orig");

        public static readonly ProfileFields PhotoMax = new ProfileFields(44, "photo_max");

        public static readonly ProfileFields PhotoMaxOrig = new ProfileFields(45, "photo_max_orig");

        public static readonly ProfileFields All = Uid | FirstName | LastName | Nickname | ScreenName | Sex | BirthDay | City | Country | Timezone | Photo50 | Photo100
                                                   | Photo200Orig | HasMobile | Contacts | Education | Online | Counters | Relation | LastSeen | Status
                                                   | CanWritePrivateMessage | CanSeeAllPosts | CanSeeAudio | CanPost | Universities | Schools | Verified | Connections
                                                   | Site | Relatives | Activities | Interests | Music | Movies | Tv | Books | Games | Quotes | About | Lang | Personal
                                                   | Photo400Orig | PhotoMax | PhotoMaxOrig;

        private ProfileFields(int value, string name)
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