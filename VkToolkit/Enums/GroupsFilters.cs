namespace VkToolkit.Enums
{
    using System.Collections.Generic;
    using System.Linq;

    using VkToolkit.Utils;

    /// <summary>
    /// Фильтры сообществ пользователя.
    /// </summary>
    public sealed class GroupsFilters
    {
        /// <summary>
        /// Строковое значение фильтра.
        /// </summary>
        private readonly string _name;

        /// <summary>
        /// Числовое значение фильтра.
        /// </summary>
        private readonly int _value;

        /// <summary>
        /// Выбранные фильтры.
        /// </summary>
        private readonly IList<GroupsFilters> _fields;

        /// <summary>
        /// Вернуть все сообщества, в которых пользователь является администратором.
        /// </summary>
        public static readonly GroupsFilters Administrator = new GroupsFilters(1 << 0, "admin");

        /// <summary>
        /// Вернуть все сообщества, в которых пользователь является администратором или редактором.
        /// </summary>
        public static readonly GroupsFilters Editor = new GroupsFilters(1 << 1, "editor");

        /// <summary>
        /// Вернуть все сообщества, в которых пользователь является администратором, редактором или модератором.
        /// </summary>
        public static readonly GroupsFilters Moderator = new GroupsFilters(1 << 2, "moder");

        /// <summary>
        /// Вернуть все группы, в которые входит пользователь.
        /// </summary>
        public static readonly GroupsFilters Groups = new GroupsFilters(1 << 3, "groups");

        /// <summary>
        /// Вернуть все публичные страницы пользователя ???
        /// </summary>
        public static readonly GroupsFilters Publics = new GroupsFilters(1 << 4, "publics");

        /// <summary>
        /// Вернуть все события, в которых участвует пользователь является.
        /// </summary>
        public static readonly GroupsFilters Events = new GroupsFilters(1 << 5, "events");

        public static readonly GroupsFilters All = Administrator | Editor | Moderator | Groups | Publics | Events;

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