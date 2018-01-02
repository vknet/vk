using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace VkNet.Model
{
    using Utils;

    /// <summary>
    /// Ссылки в группе
    /// </summary>
    [Serializable]
    public class ExternalLink
    {
        /// <summary>
        /// Идентификатор ссылки.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Адрес ссылки.
        /// </summary>
        [JsonProperty("url")]
        public string Uri { get; set; }

        /// <summary>
        /// Название страницы, на которую ведет ссылка.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; } 

        /// <summary>
        /// Описание.
        /// </summary>
        [JsonProperty("desc")]
        public string Description { get; set; }

        /// <summary>
        /// Фото 50px.
        /// </summary>
        [JsonProperty("photo_50")]
        public string Photo50 { get; set; }

        /// <summary>
        /// Фото 100px.
        /// </summary>
        [JsonProperty("photo_100")]
        public string Photo100 { get; set; }
	    
	    /// <summary>
	    /// Возвращается 1, если можно редактировать название ссылки (для внешних ссылок)
	    /// </summary>
	    [JsonProperty("edit_title")]
	    public bool? EditTitle { get; set; }
	    
	    /// <summary>
	    /// Возвращается 1, если превью находится в процессе обработки.
	    /// </summary>
	    [JsonProperty("image_processing")]
	    public bool? ImageProcessing { get; set; }

		#region Методы
		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response">Ответ сервера.</param>
		/// <returns></returns>
		public static ExternalLink FromJson(VkResponse response)
        {
	        var contact = new ExternalLink
	        {
		        Id = response["id"],
		        Uri = response["url"],
		        Name = response["name"] ?? response["title"],
		        Description = response["desc"] ?? response["description"],
		        Photo50 = response["photo_50"],
		        Photo100 = response["photo_100"],
		        EditTitle = response["edit_title"],
		        ImageProcessing = response["image_processing"]
	        };

            return contact;
        }

        #endregion
    }
}