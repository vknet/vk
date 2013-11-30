namespace VkToolkit.Model
{
    using System;

    using VkToolkit.Utils;

    /// <summary>
    /// Ссылка на Web-страницу.
    /// </summary>
    public class Link
    {
        /// <summary>
        /// Адрес ссылки.
        /// </summary>
        public Uri Url { get; set; }
        /// <summary>
        /// Заголовок ссылки.
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Описание ссылки.
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Адрес превью изображения к ссылке (если имеется).
        /// </summary>
        public string Image { get; set; }

        internal static Link FromJson(VkResponse response)
        {
            var link = new Link();

            link.Url = response["url"];
            link.Title = response["title"];
            link.Description = response["description"];
            link.Image = response["image_src"];

            return link;
        }
    }
}