using System.Collections.ObjectModel;
using Newtonsoft.Json;
using VkNet.Utils;
// ReSharper disable MemberCanBePrivate.Global

namespace VkNet.Model
{
    /// <summary>
    /// Friends Get Requests Result
    /// </summary>
    public class FriendsGetRequestsResult
    {
        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        [JsonProperty("user_id")]
        public long? UserId { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("mutual")]
        public VkCollection<long> Mutual { get; set; }
        
        /// <summary>
        /// Текст сообщения
        /// </summary>
        //[JsonProperty("message")]
        public string Message { get; set; }

        /// <summary>
        /// Разобрать из json.
        /// </summary>
        /// <param name="response">Ответ сервера.</param>
        /// <returns></returns>
        public static FriendsGetRequestsResult FromJson(VkResponse response)
        {
            return new FriendsGetRequestsResult
            {
                UserId = response["user_id"],
                Mutual = response["mutual"].ToVkCollectionOf<long>(x => x, "users"),
                Message = response["message"]
            };
        }
        
        /// <summary>
        /// Преобразовать из VkResponse
        /// </summary>
        /// <param name="response">Ответ.</param>
        /// <returns>
        /// Результат преобразования.
        /// </returns>
        public static implicit operator FriendsGetRequestsResult(VkResponse response)
        {
            return response.HasToken() ? FriendsGetRequestsResult.FromJson(response) : null;
        }
    }
}