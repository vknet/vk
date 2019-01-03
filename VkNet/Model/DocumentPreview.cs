using System;
using Newtonsoft.Json;
using VkNet.Utils;

namespace VkNet.Model.Attachments
{
	/// <summary>
	/// Информация для предварительного просмотра документа
	/// </summary>
	[Serializable]
	public class DocumentPreview
	{
		/// <summary>
		/// Изображения для предпросмотра.
		/// </summary>
		[JsonProperty("photo")]
		public Photo Photo { get; set; }

		/// <summary>
		/// Данные о граффити
		/// </summary>
		[JsonProperty("graffiti")]
		public Graffiti Graffiti { get; set; }

		/// <summary>
		/// Данные об аудиосообщении.
		/// </summary>
		[JsonProperty("audio_message")]
		public AudioMessage AudioMessage { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static DocumentPreview FromJson(VkResponse response)
		{
			return new DocumentPreview
			{
				Photo = response["photo"],
				Graffiti = response["graffiti"],
				AudioMessage = response["audio_message"]
			};
		}

		/// <summary>
		/// Преобразование класса <see cref="Document" /> в <see cref="VkParameters" />
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns>Результат преобразования в <see cref="Document" /></returns>
		public static implicit operator DocumentPreview(VkResponse response)
		{
			if (response == null)
			{
				return null;
			}

			return response.HasToken()
				? FromJson(response)
				: null;
		}
	}
}