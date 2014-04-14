namespace VkNet.Enums
{
    using System.Collections.Generic;
    using System.Linq;

    using Utils;

    /// <summary>
    /// Права доступа приложений.
    /// См. описание <see href="http://vk.com/pages?oid=-1&amp;p=Права_доступа_приложений"/>.
    /// </summary>
    public sealed class Settings
    {
        private readonly string _name;

        private int _value;

        /// <summary>
        /// Объединенные права доступа.
        /// </summary>
        public int Value
        {
            get { return _scopes != null && _scopes.Any() ? _scopes.Sum(s => s.Value) : _value; }

            private set { _value = value; }
        }

        private readonly IList<Settings> _scopes;

        /// <summary>
        /// Пользователь разрешил отправлять ему уведомления.
        /// </summary>
        public static readonly Settings Notify = new Settings(1 << 0, "notify");

        /// <summary>
        /// Доступ к друзьям. 
        /// </summary>
        public static readonly Settings Friends = new Settings(1 << 1, "friends");

        /// <summary>
        /// Доступ к фотографиям. 
        /// </summary>
        public static readonly Settings Photos = new Settings(1 << 2, "photos");

        /// <summary>
        /// Доступ к аудиозаписям. 
        /// </summary>
        public static readonly Settings Audio = new Settings(1 << 3, "audio");

        /// <summary>
        /// Доступ к видеозаписям. 
        /// </summary>
        public static readonly Settings Video = new Settings(1 << 4, "video");

        /// <summary>
        /// Доступ к wiki-страницам. 
        /// </summary>
        public static readonly Settings Pages = new Settings(1 << 7, "pages");

        /// <summary>
        /// Добавление ссылки на приложение в меню слева.
        /// </summary>
        public static readonly Settings AddLinkToLeftMenu = new Settings(1 << 8, "");

        /// <summary>
        /// Доступ к статусу пользователя. 
        /// </summary>
        public static readonly Settings Status = new Settings(1 << 10, "status");

        /// <summary>
        /// Доступ заметкам пользователя. 
        /// </summary>
        public static readonly Settings Notes = new Settings(1 << 11, "notes");

        /// <summary>
        /// Доступ к расширенным методам работы с сообщениями. 
        /// </summary>
        public static readonly Settings Messages = new Settings(1 << 12, "messages");

        /// <summary>
        /// Доступ к обычным и расширенным методам работы со стеной.
        /// </summary>
        public static readonly Settings Wall = new Settings(1 << 13, "wall");

        /// <summary>
        /// Доступ к расширенным методам работы с рекламным API. 
        /// </summary>
        public static readonly Settings Ads = new Settings(1 << 15, "ads");

        /// <summary>
        /// Доступ к API в любое время со стороннего сервера. 
        /// </summary>
        public static readonly Settings Offline = new Settings(1 << 16, "offline");

        /// <summary>
        /// Доступ к документам.
        /// </summary>
        public static readonly Settings Documents = new Settings(1 << 17, "docs");

        /// <summary>
        /// Возможность осуществлять запросы к API без HTTPS.
        /// Внимание, данная возможность находится на этапе тестирования и может быть изменена. 
        /// </summary>
        //public static readonly Settings NoHttps = new Settings(1 << 16, "nohttps");

        /// <summary>
        /// Доступ к группам пользователя. 
        /// </summary>
        public static readonly Settings Groups = new Settings(1 << 18, "groups");

        /// <summary>
        /// Доступ к оповещениям об ответах пользователю. 
        /// </summary>
        public static readonly Settings Notifications = new Settings(1 << 19, "notifications");

        /// <summary>
        /// Доступ к статистике групп и приложений пользователя, администратором которых он является. 
        /// </summary>
        public static readonly Settings Statistic = new Settings(1 << 20, "stats");

        /// <summary>
        /// Доступ к email пользователя. Доступно только для сайтов.
        /// </summary>
        public static readonly Settings Email = new Settings(1 << 22, "email");

        /// <summary>
        /// Доступ ко всем возможным операциям (без Offline и NoHttps).
        /// </summary>
        public static readonly Settings All = Notify | Friends | Photos | Audio | Video | Documents | Notes | Pages | Status | Wall | Groups | Messages | Notifications
                                              | Statistic | Ads;

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
                    if (_scopes.All(m => m.Value != s.Value))
                        _scopes.Add(s);
                }
            }
            else
            {
                if (_scopes.All(m => m.Value != s1.Value))
                    _scopes.Add(s1);
            }

            if (s2._scopes != null && s2._scopes.Count != 0)
            {
                foreach (var s in s2._scopes)
                {
                    if (_scopes.All(m => m.Value != s.Value))
                        _scopes.Add(s);
                }
            }
            else
            {
                if (_scopes.All(m => m.Value != s2.Value))
                    _scopes.Add(s2);
            }
        }

        /// <summary>
        /// Оператор объединения прав доступа.
        /// </summary>
        /// <param name="left">Левое поле выражения объединения.</param>
        /// <param name="right">Правое поле выражения объединения.</param>
        /// <returns>Результат объединения.</returns>
        public static Settings operator |(Settings left, Settings right)
        {
            return new Settings(left, right);
        }

        /// <summary>
        /// Возвращает права доступа в виде строки.
        /// </summary>
        /// <returns>
        /// Строка с правами доступа, разделенными запятыми.
        /// </returns>
        public override string ToString()
        {
            if (_scopes == null || _scopes.Count == 0)
                return _name;

            return _scopes.Select(s => s._name).JoinNonEmpty();
        }
    }
}