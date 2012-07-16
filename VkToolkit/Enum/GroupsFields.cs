using System.Collections.Generic;
using System.Linq;

namespace VkToolkit.Enum
{
    /// <summary>
    /// Описание полей, используемых в параметре fields в методах Groups.get и Groups.getById. 
    /// </summary>
    public class GroupsFields
    {
        private readonly string _name;
        private readonly int _value;
        private readonly IList<GroupsFields> _fields;

        public static readonly GroupsFields City        = new GroupsFields(1, "city");
        public static readonly GroupsFields Country     = new GroupsFields(2, "country");
        public static readonly GroupsFields Place       = new GroupsFields(4, "place");
        public static readonly GroupsFields Description = new GroupsFields(8, "description");
        public static readonly GroupsFields WikiPage    = new GroupsFields(16, "wiki_page");
        public static readonly GroupsFields StartDate   = new GroupsFields(32, "start_date");
        public static readonly GroupsFields EndDate     = new GroupsFields(62, "end_date");
        public static readonly GroupsFields All = City | Country | Place | Description | WikiPage | StartDate | EndDate;

        private GroupsFields(int value, string name)
        {
            _name = name;
            _value = value;
        }

        private GroupsFields(GroupsFields f1, GroupsFields f2)
        {
            _fields = new List<GroupsFields>();

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

        public static GroupsFields operator | (GroupsFields f1, GroupsFields f2)
        {
            return new GroupsFields(f1, f2);
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