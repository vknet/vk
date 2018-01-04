using System;
using Newtonsoft.Json;
using VkNet.Utils;
using VkNet.Utils.JsonConverter;

namespace VkNet.Model
{
    /// <summary>
    /// URL, сокращенный с помощью vk.cc.
    /// </summary>
    [Serializable]
    public class ShortLink
    {
        /// <summary>
        /// Время создания ссылки в Unixtime
        /// </summary>
        [JsonProperty("timestamp")]
        [JsonConverter(typeof(DateTimeJsonConverter))]
        public DateTime Timestamp { get; set; }
        /// <summary>
        /// Сокращенный URL.
        /// </summary>
        [JsonProperty("short_url")]
        public Uri ShortUrl { get; set; }

        /// <summary>
        /// Оригинальный URL.
        /// </summary>
        [JsonProperty("url")]
        public Uri Url { get; set; }

        /// <summary>
        /// Содержательная часть ссылки (после "vk.cc");
        /// </summary>
        [JsonProperty("Key")]
        public string Key { get; set; }

        /// <summary>
        /// Ключ для доступа к приватной статистике ссылки;
        /// </summary>
        [JsonProperty("access_key")]
        public string AccessKey { get; set; }
        
        /// <summary>
        /// Число переходов
        /// </summary>
        [JsonProperty("views")]
        public int Views { get; set; }

        /// <summary>
        /// Разобрать из json.
        /// </summary>
        /// <param name="response">Ответ сервера.</param>
        /// <returns></returns>
        public static ShortLink FromJson(VkResponse response)
        {
            return new ShortLink
            {
                Timestamp = response["timestamp"],
                ShortUrl = response["short_url"],
                Url = response["url"],
                Key = response["key"],
                AccessKey = response["access_key"],
                Views = response["views"]
            };
        }
    }
}