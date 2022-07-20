using System;
using JetBrains.Annotations;
using Newtonsoft.Json;
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
		[Obsolete("Это свойство устарело, используйте Uri Url")]
		[JsonProperty("photo_200")]
		[CanBeNull]
		public string Photo200 { get; set; }


		/// <summary>
		/// Адрес полноразмерного изображения.
		/// </summary>
		[Obsolete("Это свойство устарело, используйте Uri Url")]
		[JsonProperty("photo_586")]
		[CanBeNull]
		public string Photo586 { get; set; }

		/// <summary>
		/// Адрес граффити, по которому его можно загрузить.
		/// </summary>
		[JsonProperty("url")]
		[CanBeNull]
		public Uri Url { get; set; }

		/// <summary>
		/// Ширина изображения в px.
		/// </summary>
		[JsonProperty("width")]
		public int? Width { get; set; }

		/// <summary>
		/// Высота изображения в px.
		/// </summary>
		[JsonProperty("height")]
		public int? Height { get; set; }

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
				Photo586 = response["photo_586"],
				Url = response["url"],
				Width = response["width"],
				Height = response["height"]
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