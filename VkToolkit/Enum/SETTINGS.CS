using System.Collections.Generic;
using System.Linq;

namespace VkToolkit.Enum
{
    public sealed class Settings
    {
        private readonly string _name;
        private readonly int _value;
        private readonly IList<Settings> _scopes;

        public static readonly Settings Notify = new Settings(1, "notify");
        public static readonly Settings Friends = new Settings(2, "friends");
        public static readonly Settings Photos = new Settings(3, "photos");
        public static readonly Settings Audio = new Settings(4, "audio");
        public static readonly Settings Video = new Settings(5, "video");
        public static readonly Settings Docs = new Settings(6, "docs");
        public static readonly Settings Notes = new Settings(7, "notes");
        public static readonly Settings Pages = new Settings(8, "pages");
        public static readonly Settings Status = new Settings(9, "status");
        public static readonly Settings Wall = new Settings(10, "wall");
        public static readonly Settings Offers = new Settings(11, "offers");
        public static readonly Settings Questions = new Settings(12, "questions");
        public static readonly Settings Groups = new Settings(13, "groups");
        public static readonly Settings Messages = new Settings(14, "messages");
        public static readonly Settings Notifications = new Settings(15, "notifications");
        public static readonly Settings Stats = new Settings(16, "stats");
        public static readonly Settings Ads = new Settings(17, "ads");
        public static readonly Settings Offline = new Settings(18, "offline");
        public static readonly Settings All = Notify | Friends | Photos | Audio | Video
            | Docs | Notes | Pages | Status | Wall | Offers | Questions | Groups
            | Messages | Notifications | Stats | Ads | Offline;

        private Settings(int value, string name)
        {
            _name = name;
            _value = value;
        }

        private Settings(Settings s1, Settings s2)
        {
            _scopes = new List<Settings>();

            if (s1._scopes != null && s1._scopes.Count != 0)
            {
                foreach (var s in s1._scopes)
                {
                    if (!_scopes.Any(m => m._value == s._value))
                        _scopes.Add(s);
                }
            }
            else
            {
                if (!_scopes.Any(m => m._value == s1._value))
                    _scopes.Add(s1);
            }

            if (s2._scopes != null && s2._scopes.Count != 0)
            {
                foreach (var s in s2._scopes)
                {
                    if (!_scopes.Any(m => m._value == s._value))
                        _scopes.Add(s);
                }
            }
            else
            {
                if (!_scopes.Any(m => m._value == s2._value))
                    _scopes.Add(s2);
            }
        }

        public static Settings operator | (Settings s1, Settings s2)
        {
            return new Settings(s1, s2);
        }

        public override string ToString()
        {
            if (_scopes == null || _scopes.Count == 0)
                return _name;

            string output = "";
            for (int i = 0; i < _scopes.Count; i++)
            {
                output += _scopes[i]._name;
                if (i != _scopes.Count - 1)
                    output += ",";
            }

            return output;
        }
    }
}