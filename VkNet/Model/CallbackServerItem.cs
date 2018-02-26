using System;
using Newtonsoft.Json;
using VkNet.Enums.SafetyEnums;
using VkNet.Utils;

namespace VkNet.Model
{
    /// <summary>
    /// Данные о сервере
    /// </summary>
    [Serializable]
    public class CallbackServerItem
    {
        /// <summary>
        /// Идентификатор сервера
        /// </summary>
        [JsonProperty("id")]
        public long Id { get; set; }
        
        /// <summary>
        /// Название сервера
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }
        
        /// <summary>
        /// Идентификатор пользователя, который добавил сервер (может содержать 0)
        /// </summary>
        [JsonProperty("creator_id")]
        public long CreatorId { get; set; }
        
        /// <summary>
        /// URL сервера
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }
        
        /// <summary>
        /// Секретный ключ
        /// </summary>
        [JsonProperty("secret_key")]
        public string SecretKey { get; set; }
        
        /// <summary>
        /// Статус сервера
        /// </summary>
        [JsonProperty("status")]
        public CallbackServerStatus Status { get; set; }
        
        /// <summary>
        /// Разобрать из json.
        /// </summary>
        /// <param name="response">Ответ сервера.</param>
        /// <returns></returns>
        public static CallbackServerItem FromJson(VkResponse response)
        {
            return new CallbackServerItem
            {
                Id = response["id"],
                Title = response["title"],
                CreatorId = response["creator_id"],
                Url = response["url"],
                SecretKey = response["secret_key"],
                Status = response["status"]
            };
        }
    }
}