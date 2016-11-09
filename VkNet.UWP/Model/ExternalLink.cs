using System.Runtime.Serialization;

namespace VkNet.Model
{
    using System;
    using Utils;

    /// <summary>
    /// Ссылки в группе
    /// </summary>
    [DataContract]
    public class ExternalLink
    {
        /// <summary>
        /// Идентификатор ссылки.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Адрес ссылки.
        /// </summary>
        public string Uri { get; set; }

        /// <summary>
        /// Название страницы, на которую ведет ссылка.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Описание.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Фото 50px.
        /// </summary>
        public string Photo50 { get; set; }

        /// <summary>
        /// Фото 100px.
        /// </summary>
        public string Photo100 { get; set; }

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
		        Photo100 = response["photo_100"]
	        };

            return contact;
        }

        #endregion
    }
}