using System.Runtime.Serialization;
using VkNet.Utils;

namespace VkNet.Model.Attachments
{
	/// <summary>
	/// Контент приложения.
	/// См. описание http://vk.com/dev/attachments_w
	/// </summary>
	[DataContract]
	public class ApplicationContent : MediaAttachment
	{
		/// <summary>
		/// Приложение.
		/// </summary>
		static ApplicationContent()
		{
			RegisterType(typeof(ApplicationContent), "app");
		}

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
		public static ApplicationContent FromJson(VkResponse response)
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