using System;
using VkNet.Utils;

namespace VkNet.Model.Attachments
{
	/// <summary>
	/// Контент приложения.
	/// </summary>
	/// <remarks>
	/// Это устаревший тип вложений. Он может быть возвращен лишь для записей, созданных раньше 2013 года.
	/// <a href="http://vk.com/dev/attachments_w" > Документация </a>
	/// </remarks>
	[Serializable]
	public class ApplicationContent : MediaAttachment
	{
		/// <inheritdoc />
		protected override string Alias => "app";

		/// <summary>
		/// Название приложения.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// URL изображения для предпросмотра.
		/// </summary>
		public string Photo130 { get; set; }

		/// <summary>
		/// URL полноразмерного изображения.
		/// </summary>
		public string Photo604 { get; set; }

	#region Методы

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static ApplicationContent FromJson(VkResponse response)
		{
			return new ApplicationContent
			{
				Id = response["id"],
				Name = response["name"],
				Photo130 = response["photo_130"],
				Photo604 = response["photo_604"]
			};
		}

		/// <summary>
		/// Преобразование класса <see cref="ApplicationContent" /> в <see cref="VkParameters" />
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns>Результат преобразования в <see cref="ApplicationContent" /></returns>
		public static implicit operator ApplicationContent(VkResponse response)
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