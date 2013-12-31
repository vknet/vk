namespace VkToolkit.Model
{
    using System;

    using VkToolkit.Utils;

    /// <summary>
    /// Ссылка на Web-страницу.
    /// См. описание <see cref="http://vk.com/dev/attachments_w"/>. Раздел "Ссылка".
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

        /// <summary>
        /// Идентификатр wiki страницы с контентом для предпросмотра содержимого страницы, который может быть получен 
        /// используя метод <see cref="PagesCategory.Get"/>. Идентификатор возвращается в формате "owner_id_page_id". 
        /// </summary>
        public string PreviewPage { get; set; }

        #region Методы

        internal static Link FromJson(VkResponse response)
        {
            var link = new Link();

            link.Url = response["url"];
            link.Title = response["title"];
            link.Description = response["description"];
            link.Image = response["image_src"];
            link.PreviewPage = response["preview_page"];

            return link;
        }

        #endregion
    }
}