using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using VkNet.Utils;

namespace VkNet.Model
{
    /// <summary>
    /// Информация о чате.
    /// </summary>
    [Serializable]
    public class ChatPreviewField
    {
        /// <summary>
        /// Идентификатор создателя чата
        /// </summary>
        [JsonProperty("admin_id")]
        public long AdminId { get; set; }
        /// <summary>
        /// Массив идентификаторов участников чата
        /// </summary>
        [JsonProperty("members")]
        public IEnumerable<long> Members { get; set; }

        /// <summary>
        /// Название чата
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }
        
        /// <summary>
        /// Обложка чата
        /// </summary>
        [JsonProperty("photo")]
        public ChatPhoto Photo { get; set; }
        
        /// <summary>
        /// Идентификатор чата для текущего пользователя
        /// </summary>
        [JsonProperty("local_id")]
        public int LocalId { get; set; }
        
        #region Методы

        /// <summary>
        /// Разобрать из json.
        /// </summary>
        /// <param name="response">Ответ сервера.</param>
        /// <returns></returns>
        public static ChatPreviewField FromJson(VkResponse response)
        {
            return new ChatPreviewField
            {
                AdminId = response["admin_id"],
                Members = response["members"].ToReadOnlyCollectionOf<long>(x => x),
                Title = response["title"],
                Photo = response["photo"],
                LocalId = response["local_id"]
            };
        }

        #endregion
    }
}