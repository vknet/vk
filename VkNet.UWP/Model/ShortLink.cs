using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using VkNet.Utils;

namespace VkNet.Model
{
    /// <summary>
    /// URL, сокращенный с помощью vk.cc
    /// </summary>
    [DataContract]
    public class ShortLink
    {
        /// <summary>
        /// Ключ для доступа к приватной статистике ссылки
        /// </summary>
        public string AccessKey { get; set; }

        /// <summary>
        /// Содержательная часть ссылки (после "vk.cc")
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Оригинальный URL
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Разобрать из json.
        /// </summary>
        /// <param name="response">Ответ сервера.</param>
        /// <returns></returns>
        public static ShortLink FromJson(VkResponse response)
        {
            var shortLink = new ShortLink
            {
                AccessKey = response["access_key"],
                Key = response["key"],
                Url = response["url"]
            };

            return shortLink;
        }
    }
}
