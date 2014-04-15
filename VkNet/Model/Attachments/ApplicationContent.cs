using VkNet.Utils;

namespace VkNet.Model.Attachments
{
	/// <summary>
    /// Контент приложения.
    /// См. описание <see href="http://vk.com/dev/attachments_w"/>. Раздел "Контент приложения".
    /// </summary>
    public class ApplicationContent
    {
        /// <summary>
        /// Идентификатор приложения, разместившего запись на стене.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Название приложения.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Адрес изображения для предпросмотра.
        /// </summary>
        public string Photo130 { get; set; }

        /// <summary>
        /// Адрес полноразмерного изображения. 
        /// </summary>
        public string Photo604 { get; set; }

        #region Методы

        internal static ApplicationContent FromJson(VkResponse response)
        {
            var application = new ApplicationContent();

            application.Id = response["id"];
            application.Name = response["name"];
            application.Photo130 = response["photo_130"];
            application.Photo604 = response["photo_604"];

            return application;
        }

        #endregion
    }
}