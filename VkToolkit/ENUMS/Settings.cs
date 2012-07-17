using System.Collections.Generic;
using System.Linq;

namespace VkToolkit.Enums
{
    public sealed class Settings
    {
        private readonly string _name;
        private int _value;
        public int Value
        { 
            get
            {
                return _scopes != null && _scopes.Any()
                           ? _scopes.Sum(s => s.Value)
                           : _value;
            } 
            
            private set { _value = value; }
        }
        private readonly IList<Settings> _scopes;

        public static readonly Settings Notify      = new Settings(1, "notify");
        public static readonly Settings Friends     = new Settings(2, "friends");
        public static readonly Settings Photos      = new Settings(4, "photos");
        public static readonly Settings Audio       = new Settings(8, "audio");
        public static readonly Settings Video       = new Settings(16, "video");
        public static readonly Settings Offers      = new Settings(32, "offers");
        public static readonly Settings Questions   = new Settings(64, "questions");
        public static readonly Settings Pages       = new Settings(128, "pages");
        public static readonly Settings AddLinkToLeftMenu = new Settings(256, "");
        public static readonly Settings AddLinkToWallPost = new Settings(512, "");
        public static readonly Settings Status      = new Settings(1024, "status");
        public static readonly Settings Notes       = new Settings(2048, "notes");
        public static readonly Settings Messages    = new Settings(4096, "messages");
        public static readonly Settings Wall        = new Settings(8192, "wall");
        public static readonly Settings Ads         = new Settings(32768, "ads");
        public static readonly Settings Docs        = new Settings(131072, "docs");
        public static readonly Settings Groups      = new Settings(262144, "groups");
        public static readonly Settings Notifications = new Settings(524288, "notifications");
        public static readonly Settings Statistic       = new Settings(1048576, "stats");
        
        public static readonly Settings All = Notify | Friends | Photos | Audio | Video
            | Docs | Notes | Pages | Status | Wall | Offers | Questions | Groups
            | Messages | Notifications | Statistic | Ads;

        private Settings(int value, string name)
        {
            _name = name;
            Value = value;
        }

        private Settings(Settings s1, Settings s2)
        {
            _scopes = new List<Settings>();

            if (s1._scopes != null && s1._scopes.Count != 0)
            {
                foreach (var s in s1._scopes)
                {
                    if (!_scopes.Any(m => m.Value == s.Value))
                        _scopes.Add(s);
                }
            }
            else
            {
                if (!_scopes.Any(m => m.Value == s1.Value))
                    _scopes.Add(s1);
            }

            if (s2._scopes != null && s2._scopes.Count != 0)
            {
                foreach (var s in s2._scopes)
                {
                    if (!_scopes.Any(m => m.Value == s.Value))
                        _scopes.Add(s);
                }
            }
            else
            {
                if (!_scopes.Any(m => m.Value == s2.Value))
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
                if (string.IsNullOrEmpty(_scopes[i]._name)) continue;
                    
                output += _scopes[i]._name;
                if (i != _scopes.Count - 1)
                    output += ",";
            }

            return output;
        }
    }
}