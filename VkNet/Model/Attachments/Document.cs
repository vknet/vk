using VkNet.Utils;

namespace VkNet.Model.Attachments
{
	/// <summary>
    /// Информация о документе.
    /// См. описание <see href="http://vk.com/dev/doc"/>.
    /// </summary>
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

        #region Методы

        internal static Document FromJson(VkResponse response)
        {
            var document = new Document();

            document.Id = response["did"];
            document.OwnerId = response["owner_id"];
            document.Title = response["title"];
            document.Size = response["size"];
            document.Ext = response["ext"];
            document.Url = response["url"];
            document.Photo100 = response["photo_100"];
            document.Photo130 = response["photo_130"];

            return document;
        }

        #endregion
    }
}