using System;
using VkNet.Utils;

namespace VkNet.Model.Attachments
{
	/// <summary>
    /// Ссылка на Web-страницу.
    /// См. описание <see href="http://vk.com/dev/attachments_w"/>. Раздел "Ссылка".
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
        /// Идентификатр wiki страницы с контентом для предпросмотра содержимого страницы. Идентификатор возвращается в формате "owner_id_page_id". 
        /// </summary>
        public string PreviewPage { get; set; }

		/// <summary>
		/// Идентификатор ссылки.
		/// </summary>
		public ulong Id { get; set; }


		/// <summary>
		/// Преобразовать к строке.
		/// </summary>
		/// <returns>
		/// Адрес ссылки.
		/// </returns>
		public override string ToString()
		{
			return Url.ToString();
		}

		#region Методы

        internal static Link FromJson(VkResponse response)
        {
	        var link = new Link
	        {
		        Id = response["id"],
		        Url = response["url"],
		        Title = response["title"],
		        Description = response["description"] ?? response["desc"],
		        Image = response["image_src"],
		        PreviewPage = response["preview_page"]
	        };


	        return link;
        }

        #endregion
    }
}