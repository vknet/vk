using System.Collections.Generic;
using System.Linq;

namespace VkToolkit.Enum
{
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
        public static readonly ProfileFields Photo = new ProfileFields(11, "photo");
        public static readonly ProfileFields PhotoMedium = new ProfileFields(12, "photo_medium");
        public static readonly ProfileFields PhotoBig = new ProfileFields(13, "photo_big");
        public static readonly ProfileFields HasMobile= new ProfileFields(14, "has_mobile");
        public static readonly ProfileFields Rate = new ProfileFields(15, "rate");
        public static readonly ProfileFields Contacts = new ProfileFields(16, "contacts");
        public static readonly ProfileFields Education = new ProfileFields(17, "education");
        public static readonly ProfileFields Online = new ProfileFields(18, "online");
        public static readonly ProfileFields Counters = new ProfileFields(19, "counters");
        public static readonly ProfileFields All = Uid | FirstName | LastName | Nickname | ScreenName
            | Sex | BirthDay | City | Country | Timezone | Photo | PhotoMedium | PhotoBig | HasMobile
            | Rate | Contacts | Education | Online | Counters;

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
                    if (!_fields.Any(m => m._value == f._value))
                        _fields.Add(f);
                }
            }
            else
            {
                if (!_fields.Any(m => m._value == f1._value))
                    _fields.Add(f1);
            }
            

            if (f2._fields != null && f2._fields.Count != 0)
            {
                foreach (var f in f2._fields)
                {
                    if (!_fields.Any(m => m._value == f._value))
                        _fields.Add(f);
                }
            }
            else
            {
                if (!_fields.Any(m => m._value == f2._value))
                    _fields.Add(f2);
            }
        }

        public static ProfileFields operator | (ProfileFields f1, ProfileFields f2)
        {
            return new ProfileFields(f1, f2);
        }

        public override string ToString()
        {
            if (_fields == null || _fields.Count == 0)
                return _name;

            string output = "";
            for (int i = 0; i < _fields.Count; i++)
            {
                output += _fields[i]._name;
                if (i != _fields.Count - 1)
                    output += ",";
            }

            return output;
        }

    }
}