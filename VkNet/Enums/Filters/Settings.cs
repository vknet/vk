using System;
using System.Collections.Generic;
using System.Linq;
using VkNet.Utils;

namespace VkNet.Enums.Filters
{
    /// <summary>
    /// Права доступа приложений.
    /// См. описание <see href="http://vk.com/pages?oid=-1&amp;p=Права_доступа_приложений"/>.
    /// </summary>
    public sealed class Settings
    {
        private static readonly Dictionary<string, ulong> MaskMap = new Dictionary<string, ulong>()
        {
            {"notify", 1},
            {"friends", 2},
            {"photos", 4},
            {"audio", 8},
            {"video", 16},
            {"pages", 128},
            {"addlinktoleftmenu", 256},
            {"status", 1024},
            {"notes", 2048},
            {"messages", 4096},
            {"wall", 8192},
            {"ads", 32768},
            {"offline", 65536},
            {"docs", 131072},
            {"groups", 262144},
            {"notifications", 524288},
            {"stats", 1048576},
            {"email", 4194304},
            {"market", 134217728}
        };

        private static readonly Dictionary<string, string> Alias = new Dictionary<string, string>()
        {
            {"all", string.Join(",", MaskMap.Keys.Where(x => x != "offline").OrderBy(x => x))}
        };

        private static Settings GetByName(string name)
        {
            var n = name.ToLower();

            if (MaskMap.ContainsKey(n))
            {
                return new Settings()
                {
                    Mask = MaskMap[n],
                    _settings = new List<string>() {n}
                };
            }

            if (!Alias.ContainsKey(n))
            {
                throw new ArgumentException($"Undefined access setting '{n}'");
            }

            var res = new Settings();
            return Alias[n].Split(',').Aggregate(res, (current, v) => current | GetByName(v));
        }

        /// <summary>
        /// Числовая маска выбранных прав доступа
        /// </summary>
        private ulong Mask { get; set; }

        private List<string> _settings;

        /// <summary>
        /// Список выбранных прав
        /// </summary>
        private IEnumerable<string> Selected => _settings ?? (_settings = new List<string>());

        /// <summary>
        /// Получить из json
        /// </summary>
        /// <param name="response">Ответ Vk</param>
        /// <returns></returns>
        public static Settings FromJson(VkResponse response)
        {
            var value = response.ToString();
            return FromJsonString(value);
        }

        /// <summary>
        /// Получить из json
        /// </summary>
        /// <param name="val">Json строка</param>
        /// <returns></returns>
        public static Settings FromJsonString(string val)
        {
            var vals = val.Split(',').Select(x => x.Trim());

            var res = new Settings();
            foreach (var v in vals)
            {
                if (MaskMap.ContainsKey(v.ToLower()))
                {
                    res = res | GetByName(v);
                }

                if (Alias.ContainsKey(v.ToLower()))
                {
                    res = res | GetByName(v);
                }
            }

            return res;
        }

        /// <summary>
        /// Преобразовать в строку
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Join(",", Selected.ToArray());
        }

        /// <summary>
        /// Преобразовать в числовую маску выбранные права доступа
        /// </summary>
        /// <returns></returns>
        public ulong ToUInt64()
        {
            return Mask;
        }

        /// <summary>
        /// Сравнение с другим набором прав
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            var other = obj as Settings;

            return Mask == other?.Mask;
        }

        /// <summary>
        /// Get Hash
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return Selected?.GetHashCode() ?? 0;
        }

        /// <summary>
        /// Пользователь разрешил отправлять ему уведомления.
        /// </summary>
        public static Settings Notify => GetByName("notify");

        /// <summary>
        /// Доступ к друзьям.
        /// </summary>
        public static Settings Friends => GetByName("friends");

        /// <summary>
        /// Доступ к фотографиям.
        /// </summary>
        public static Settings Photos => GetByName("photos");

        /// <summary>
        /// Доступ к аудио записям.
        /// </summary>
        public static Settings Audio => GetByName("audio");

        /// <summary>
        /// Доступ к видеозаписям.
        /// </summary>
        public static Settings Video => GetByName("video");

        /// <summary>
        /// Доступ к wiki-страницам.
        /// </summary>
        public static Settings Pages => GetByName("pages");

        /// <summary>
        /// Добавление ссылки на приложение в меню слева.
        /// </summary>
        public static Settings AddLinkToLeftMenu => GetByName("addLinkToLeftMenu");

        /// <summary>
        /// Доступ к статусу пользователя.
        /// </summary>
        public static Settings Status => GetByName("status");

        /// <summary>
        /// Доступ заметкам пользователя.
        /// </summary>
        public static Settings Notes => GetByName("notes");

        /// <summary>
        /// Доступ к расширенным методам работы с сообщениями.
        /// </summary>
        public static Settings Messages => GetByName("messages");

        /// <summary>
        /// Доступ к обычным и расширенным методам работы со стеной.
        /// </summary>
        public static Settings Wall => GetByName("wall");

        /// <summary>
        /// Доступ к расширенным методам работы с рекламным API.
        /// </summary>
        public static Settings Ads => GetByName("ads");

        /// <summary>
        /// Доступ к API в любое время со стороннего сервера.
        /// </summary>
        public static Settings Offline => GetByName("offline");

        /// <summary>
        /// Доступ к документам.
        /// </summary>
        public static Settings Documents => GetByName("docs");

        /// <summary>
        /// Доступ к группам пользователя.
        /// </summary>
        public static Settings Groups => GetByName("groups");

        /// <summary>
        /// Доступ к оповещениям об ответах пользователю.
        /// </summary>
        public static Settings Notifications => GetByName("notifications");

        /// <summary>
        /// Доступ к статистике групп и приложений пользователя, администратором которых он является.
        /// </summary>
        public static Settings Statistic => GetByName("stats");

        /// <summary>
        /// Доступ к email пользователя. Доступно только для сайтов.
        /// </summary>
        public static Settings Email => GetByName("email");

        /// <summary>
        /// Доступ к товарам. Доступно только для сайтов.
        /// </summary>
        public static Settings Market => GetByName("market");

        /// <summary>
        /// Доступ ко всем возможным операциям (без Off line и NoHttps).
        /// </summary>
        public static Settings All => GetByName("all");

        /// <summary>
        /// Объединяет наборы настройки
        /// </summary>
        /// <param name="a">Первый набор</param>
        /// <param name="b">Второй набор</param>
        /// <returns></returns>
        public static Settings operator |(Settings a, Settings b)
        {
            foreach (var s in b.Selected)
            {
                if (a.Selected.Contains(s))
                {
                    continue;
                }

                a.Mask += MaskMap[s];
                a._settings.Add(s);
            }

            return a;
        }
    }
}