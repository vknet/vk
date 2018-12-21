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
		/// <inheritdoc />
		protected override string Alias => "graffiti";

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
			return new Graffiti
			{
				Id = response["id"],
				OwnerId = response["owner_id"],
				Photo200 = response["photo_200"],
				Photo586 = response["photo_586"]
			};
		}

		/// <summary>
		/// Преобразование класса <see cref="Graffiti" /> в <see cref="VkParameters" />
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns>Результат преобразования в <see cref="Graffiti" /></returns>
		public static implicit operator Graffiti(VkResponse response)
		{
			if (response == null)
			{
				return null;
			}

			return response.HasToken()
				? FromJson(response)
				: null;
		}

	#endregion
	}
}