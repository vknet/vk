using System;
using VkNet.Utils;

namespace VkNet.Model.Attachments
{
	/// <summary>
	/// Информация о документе.
	/// См. описание <see href="http://vk.com/dev/doc"/>.
	/// </summary>
	[Serializable]
	public class Document : MediaAttachment
    {
		static Document()
		{
			RegisterType(typeof (Document), "doc");
		}

		/// <summary>
        /// Название документа.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Размер документа в байтах.
        /// </summary>
        public long? Size { get; set; }

        /// <summary>
        /// Расширение документа.
        /// </summary>
        public string Ext { get; set; }

        /// <summary>
        /// Адрес документа, по которому его можно загрузить.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Адрес изображения с размером 100x75px (если файл графический).
        /// </summary>
        public string Photo100 { get; set; }

        /// <summary>
        /// Адрес изображения с размером 130x100px (если файл графический).
        /// </summary>
        public string Photo130 { get; set; }

        /// <summary>
        /// Ключ доступа к закрытым ресурсам
        /// </summary>
        public string AccessKey { get; set; }

		/// <summary>
		/// Дата добавления в формате unixtime.
		/// </summary>
		public DateTime? Date { get; set; }


        /// <summary>
        /// Gets or sets the preview.
        /// </summary>
        public Previews Preview { get; set; }

        #region Методы
        /// <summary>
        /// Разобрать из json.
        /// </summary>
        /// <param name="response">Ответ сервера.</param>
        /// <returns></returns>
        internal static Document FromJson(VkResponse response)
        {
	        var document = new Document
	        {
		        Id = response["doc_id"] ?? response["did"] ?? response["id"],
		        OwnerId = response["owner_id"],
		        Title = response["title"],
		        Size = response["size"],
		        Ext = response["ext"],
		        Url = response["url"],
		        Photo100 = response["photo_100"],
		        Photo130 = response["photo_130"],
		        AccessKey = response["access_key"],
				Date = response["date"],
                Preview = response["preview"]
            };

	        return document;
        }

        #endregion
    }
}