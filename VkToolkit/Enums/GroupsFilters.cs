namespace VkToolkit.Enums
{
    using System.Collections.Generic;
    using System.Linq;

    using VkToolkit.Utils;

    public sealed class GroupsFilters
    {
        private readonly string _name;

        private readonly int _value;

        private readonly IList<GroupsFilters> _fields;

        public static readonly GroupsFilters Admin = new GroupsFilters(1, "admin");

        public static readonly GroupsFilters Groups = new GroupsFilters(2, "groups");

        public static readonly GroupsFilters Publics = new GroupsFilters(4, "publics");

        public static readonly GroupsFilters Events = new GroupsFilters(8, "events");

        public static readonly GroupsFilters All = Admin | Groups | Publics | Events;

        private GroupsFilters(int value, string name)
        {
            _value = value;
            _name = name;
        }

        private GroupsFilters(GroupsFilters f1, GroupsFilters f2)
        {
            _fields = new List<GroupsFilters>();

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

        public static GroupsFilters operator |(GroupsFilters f1, GroupsFilters f2)
        {
            return new GroupsFilters(f1, f2);
        }

        public override string ToString()
        {
            if (_fields == null || _fields.Count == 0)
                return _name;

            return _fields.Select(f => f._name).JoinNonEmpty();
        }
    }
}