using VkNet.Utils;

namespace VkNet.Model.Attachments
{
	/// <summary>
    /// Граффити.
    /// См. описание <see href="http://vk.com/dev/attachments_w"/>. Раздел "Граффити".
    /// </summary>
    public class Graffiti : MediaAttachment
    {
		static Graffiti()
		{
			RegisterType(typeof (Graffiti), "graffiti");
		}

        /// <summary>
        /// Адрес изображения для предпросмотра.
        /// </summary>
        public string Photo200 { get; set; }

        /// <summary>
        /// Адрес полноразмерного изображения. 
        /// </summary>
        public string Photo586 { get; set; }

        #region Методы

        internal static Graffiti FromJson(VkResponse response)
        {
            var graffiti = new Graffiti();

            graffiti.Id = response["id"];
            graffiti.OwnerId = response["owner_id"];
            graffiti.Photo200 = response["photo_200"];
            graffiti.Photo586 = response["photo_586"];

            return graffiti;
        }

        #endregion
    }
}