namespace VkNet.Enums
{
    using System.Collections.Generic;
    using System.Linq;

    using Categories;
    using Model;
    using Utils;

    /// <summary>
    /// Описание дополнительных полей сообщества, используемых в параметре fields (например, в методе <see cref="GroupsCategory.Get"/>).
    /// См. описание <see cref="http://vk.com/dev/groups.get"/>.
    /// </summary>
    public sealed class GroupsFields
    {
        /// <summary>
        /// Имя поля.
        /// </summary>
        private readonly string _name;

        /// <summary>
        /// Флаговое значение поля.
        /// </summary>
        private readonly int _value;

        /// <summary>
        /// Список полей.
        /// </summary>
        private readonly IList<GroupsFields> _fields;

        /// <summary>
        /// Для получения дополнительного поля <see cref="Group.CityId"/>.
        /// </summary>
        public static readonly GroupsFields CityId = new GroupsFields(1 << 0, "city");

        /// <summary>
        /// Для получения дополнительного поля <see cref="Group.CountryId"/>.
        /// </summary>
        public static readonly GroupsFields CountryId = new GroupsFields(1 << 1, "country");

        /// <summary>
        /// Для получения дополнительного поля <see cref="Group.Place"/>.
        /// </summary>
        public static readonly GroupsFields Place = new GroupsFields(1 << 2, "place");

        /// <summary>
        /// Для получения дополнительного поля <see cref="Group.Description"/>.
        /// </summary>
        public static readonly GroupsFields Description = new GroupsFields(1 << 3, "description");

        /// <summary>
        /// Для получения дополнительного поля <see cref="Group.WikiPage"/>.
        /// </summary>
        public static readonly GroupsFields WikiPage = new GroupsFields(1 << 4, "wiki_page");

        /// <summary>
        /// Для получения дополнительного поля <see cref="Group.MembersCount"/>.
        /// </summary>
        public static readonly GroupsFields MembersCount = new GroupsFields(1 << 5, "members_count");

        /// <summary>
        /// Для получения дополнительного поля <see cref="Group.Counters"/>.
        /// </summary>
        public static readonly GroupsFields Counters = new GroupsFields(1 << 6, "counters");

        /// <summary>
        /// Для получения дополнительного поля <see cref="Group.StartDate"/>.
        /// </summary>
        public static readonly GroupsFields StartDate = new GroupsFields(1 << 7, "start_date");

        /// <summary>
        /// Для получения дополнительного поля <see cref="Group.EndDate"/>.
        /// </summary>
        public static readonly GroupsFields EndDate = new GroupsFields(1 << 8, "end_date");

        /// <summary>
        /// Для получения дополнительного поля <see cref="Group.CanPost"/>.
        /// </summary>
        public static readonly GroupsFields CanPost = new GroupsFields(1 << 9, "can_post");

        /// <summary>
        /// Для получения дополнительного поля <see cref="Group.CanSeelAllPosts"/>.
        /// </summary>
        public static readonly GroupsFields CanSeelAllPosts = new GroupsFields(1 << 10, "can_see_all_posts");

        /// <summary>
        /// Для получения дополнительного поля <see cref="Group.CanUploadDocuments"/>.
        /// </summary>
        public static readonly GroupsFields CanUploadDocuments = new GroupsFields(1 << 11, "can_upload_doc");

        /// <summary>
        /// Для получения дополнительного поля <see cref="Group.CanCreateTopic"/>.
        /// </summary>
        public static readonly GroupsFields CanCreateTopic = new GroupsFields(1 << 12, "can_create_topic");

        /// <summary>
        /// Для получения дополнительного поля <see cref="Group.Activity"/>.
        /// </summary>
        public static readonly GroupsFields Activity = new GroupsFields(1 << 13, "activity");

        /// <summary>
        /// Для получения дополнительного поля <see cref="Group.Status"/>.
        /// </summary>
        public static readonly GroupsFields Status = new GroupsFields(1 << 14, "status");

        /// <summary>
        /// Для получения дополнительного поля <see cref="Group.Contacts"/>.
        /// </summary>
        public static readonly GroupsFields Contacts = new GroupsFields(1 << 15, "contacts");

        /// <summary>
        /// Для получения дополнительного поля <see cref="Group.Links"/>.
        /// </summary>
        public static readonly GroupsFields Links = new GroupsFields(1 << 16, "links");

        /// <summary>
        /// Для получения дополнительного поля <see cref="Group.FixedPostId"/>.
        /// </summary>
        public static readonly GroupsFields FixedPostId = new GroupsFields(1 << 17, "fixed_post");

        /// <summary>
        /// Для получения дополнительного поля <see cref="Group.IsVerified"/>.
        /// </summary>
        public static readonly GroupsFields IsVerified = new GroupsFields(1 << 18, "verified");

        /// <summary>
        /// Для получения дополнительного поля <see cref="Group.Site"/>.
        /// </summary>
        public static readonly GroupsFields Site = new GroupsFields(1 << 19, "site");
        
        /// <summary>
        /// Для получения всех дополнительных полей.
        /// </summary>
        public static readonly GroupsFields All = CityId | CountryId | Place | Description | WikiPage | MembersCount | Counters |
            StartDate | EndDate | CanPost | CanSeelAllPosts | CanCreateTopic | Activity | Status | Contacts | Links | FixedPostId | 
            IsVerified | Site;

        /// <summary>
        /// Для получения всех дополнительных полей (оказалаось, что некоторые поля пропущены в документации).
        /// </summary>
        public static readonly GroupsFields AllUndocumented = All | CanUploadDocuments;

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

        public static GroupsFields operator |(GroupsFields f1, GroupsFields f2)
        {
            return new GroupsFields(f1, f2);
        }

        public override string ToString()
        {
            if (_fields == null || _fields.Count == 0)
                return _name;

            return _fields.Select(f => f._name).JoinNonEmpty();
        }
    }
}