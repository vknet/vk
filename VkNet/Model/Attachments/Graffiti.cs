using System;
using VkNet.Utils;

namespace VkNet.Model.Attachments
{
	/// <summary>
	/// Граффити.
	/// См. описание <see href="http://vk.com/dev/attachments_w"/>. Раздел "Граффити".
	/// </summary>
	[Serializable]
	public class Graffiti : MediaAttachment
    {
		/// <summary>
		/// Граффити.
		/// </summary>
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

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response">Ответ сервера.</param>
		/// <returns></returns>
		internal static Graffiti FromJson(VkResponse response)
        {
	        var graffiti = new Graffiti
	        {
		        Id = response["id"],
		        OwnerId = response["owner_id"],
		        Photo200 = response["photo_200"],
		        Photo586 = response["photo_586"]
	        };

	        return graffiti;
        }

        #endregion
    }
}