using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using VkNet.Utils;

namespace VkNet.Model.Attachments
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class PrettyCard
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("card_id")]
        public string CardId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("link_url_target")]
        public string LinkUrlTarget { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("link_url")]
        public string LinkUrl { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("button")]
        public Button Button { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("images")]
        public ReadOnlyCollection<Photo> Images { get; set; }
        
        /// <summary>
        /// Разобрать из json.
        /// </summary>
        /// <param name="response">Ответ сервера.</param>
        /// <returns></returns>
        public static PrettyCard FromJson(VkResponse response)
        {
            return new PrettyCard
            {
                CardId = response["card_id"],
                LinkUrlTarget = response["link_url_target"],
                LinkUrl = response["link_url"],
                Title = response["title"],
                Button = response["button"],
                Images = response["images"].ToReadOnlyCollectionOf<Photo>(x => x)
            };
        }

        /// <summary>
        /// Преобразовать из VkResponse
        /// </summary>
        /// <param name="response">Ответ.</param>
        /// <returns>
        /// Результат преобразования.
        /// </returns>
        public static implicit operator PrettyCard(VkResponse response)
        {
            return response != null && !response.HasToken()? null : FromJson(response);
        }
    }
}