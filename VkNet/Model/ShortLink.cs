using System;
using VkNet.Utils;

namespace VkNet.Model
{
    /// <summary>
    /// URL, сокращенный с помощью vk.cc.
    /// </summary>
    public class ShortLink
    {
        /// <summary>
        /// Сокращенный URL.
        /// </summary>
        public Uri ShortUrl { get; set; }

        /// <summary>
        /// Оригинальный URL.
        /// </summary>
        public Uri Url { get; set; }

        /// <summary>
        /// Содержательная часть ссылки (после "vk.cc");
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Ключ для доступа к приватной статистике ссылки;
        /// </summary>
        public string AccessKey { get; set; }

        /// <summary>
        /// Разобрать из json.
        /// </summary>
        /// <param name="response">Ответ сервера.</param>
        /// <returns></returns>
        public static ShortLink FromJson(VkResponse response)
        {
            return new ShortLink
            {
                ShortUrl = response["short_url"],
                Url = response["url"],
                Key = response["key"],
                AccessKey = response["access_key"]
            };
        }
    }
}