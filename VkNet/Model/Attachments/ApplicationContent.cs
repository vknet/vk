using System;
using VkNet.Utils;

namespace VkNet.Model.Attachments
{
    [Serializable]
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
		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response">Ответ сервера.</param>
		/// <returns></returns>
		internal static ApplicationContent FromJson(VkResponse response)
        {
	        var application = new ApplicationContent
	        {
		        Id = response["id"],
		        Name = response["name"],
		        Photo130 = response["photo_130"],
		        Photo604 = response["photo_604"]
	        };


	        return application;
        }

        #endregion
    }
}