namespace VkNet.Model
{
    using System;
    using Utils;

    [Serializable]
    /// <summary>
    /// Ссылки в группе
    /// </summary>
    public class ExternalLink
    {
        /// <summary>
        /// Идентификатор ссылки.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Адрес ссылки.
        /// </summary>
        public string Url { get; set; }

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

        internal static ExternalLink FromJson(VkResponse response)
        {
            var contact = new ExternalLink();

            contact.Id = response["id"];
            contact.Url = response["url"];
            contact.Name = response["name"];
            contact.Description = response["desc"];
            contact.Photo50 = response["photo_50"];
            contact.Photo100 = response["photo_100"]; ;

            return contact;
        }

        #endregion
    }
}