using Newtonsoft.Json;
using VkNet.Utils;

namespace VkNet.Model
{
    /// <summary>
    /// Результат запроса Friends.Delete
    /// </summary>
    public class FriendsDeleteResult
    {
        /// <summary>
        /// Удалось успешно удалить друга
        /// </summary>
        [JsonProperty("success")]
        public bool? Success { get; set; }
        
        /// <summary>
        /// Был удален друг
        /// </summary>
        [JsonProperty("friend_deleted")]
        public bool? FriendDeleted { get; set; }
        
        /// <summary>
        /// Отменена исходящая заявка
        /// </summary>
        [JsonProperty("out_request_deleted")]
        public bool? OutRequestDeleted { get; set; }
        
        /// <summary>
        /// Отклонена входящая заявка
        /// </summary>
        [JsonProperty("in_request_deleted")]
        public bool? InRequestDeleted { get; set; }
        
        /// <summary>
        /// Отклонена рекомендация друга
        /// </summary>
        [JsonProperty("suggestion_deleted")]
        public bool? SuggestionDeleted { get; set; }
        #region Методы
        /// <summary>
        /// Разобрать из json.
        /// </summary>
        /// <param name="response">Ответ сервера.</param>
        /// <returns></returns>
        public static FriendsDeleteResult FromJson(VkResponse response)
        {
            return new FriendsDeleteResult
            {
                Success = response["success"],
                FriendDeleted = response["friend_deleted"],
                OutRequestDeleted = response["out_request_deleted"],
                InRequestDeleted = response["in_request_deleted"],
                SuggestionDeleted = response["suggestion_deleted"]
            };
        }

        #endregion
    }
}