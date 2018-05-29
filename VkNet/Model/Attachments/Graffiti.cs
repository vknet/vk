using System;
using VkNet.Utils;

namespace VkNet.Model.Attachments
{
	/// <summary>
	/// Граффити.
	/// См. описание http://vk.com/dev/attachments_w
	/// </summary>
	[Serializable]
	public class Graffiti : MediaAttachment
	{
		/// <summary>
		/// Граффити.
		/// </summary>
		static Graffiti()
		{
			RegisterType(type: typeof(Graffiti), match: "graffiti");
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
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static Graffiti FromJson(VkResponse response)
		{
			var graffiti = new Graffiti
			{
					Id = response[key: "id"]
					, OwnerId = response[key: "owner_id"]
					, Photo200 = response[key: "photo_200"]
					, Photo586 = response[key: "photo_586"]
			};

			return graffiti;
		}

	#endregion
	}
}