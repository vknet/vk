using Newtonsoft.Json;
using VkNet.Utils;

namespace VkNet.Model
{
    /// <summary>
    /// Версия страницы
    /// </summary>
    public class PageVersion
    {
        /// <summary>
        /// идентификатор версии страницы;
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// длина версии страницы в байтах;
        /// </summary>
        [JsonProperty("length")]
        public string Length { get; set; }

        /// <summary>
        /// дата редактирования страницы;
        /// </summary>
        [JsonProperty("edited")]
        public string Edited { get; set; }

        /// <summary>
        /// идентификатор редактора;
        /// </summary>
        [JsonProperty("editor_id")]
        public string EditorId { get; set; }

        /// <summary>
        /// имя редактора.
        /// </summary>
        [JsonProperty("editor_name")]
        public string EditorName { get; set; }
        
        #region Методы

        /// <summary>
        /// Разобрать из json.
        /// </summary>
        /// <param name="response">Ответ сервера.</param>
        /// <returns></returns>
        public static PageVersion FromJson(VkResponse response)
        {
            return new PageVersion
            {
                Id = response["id"],
                Length = response["length"],
                Edited = response["edited"],
                EditorId = response["editor_id"],
                EditorName = response["editor_name"]
            };
        }

        #endregion
    }
}