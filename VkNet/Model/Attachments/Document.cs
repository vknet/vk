using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using VkNet.Enums;
using VkNet.Utils;

namespace VkNet.Model.Attachments
{
	/// <summary>
	/// Информация о документе.
	/// См. описание http://vk.com/dev/doc
	/// </summary>
	[Serializable]
	public class Document : MediaAttachment
	{
		/// <inheritdoc />
		protected override string Alias => "doc";

		/// <summary>
		/// Название документа.
		/// </summary>
		public string Title { get; set; }

		/// <summary>
		/// Размер документа в байтах.
		/// </summary>
		public long? Size { get; set; }

		/// <summary>
		/// Расширение документа.
		/// </summary>
		public string Ext { get; set; }

		/// <summary>
		/// Адрес документа, по которому его можно загрузить.
		/// </summary>
		[JsonProperty("url")]
		public string Uri { get; set; }

		/// <summary>
		/// Дата добавления в формате unixtime.
		/// </summary>
		[JsonConverter(typeof(UnixDateTimeConverter))]
		public DateTime? Date { get; set; }

		/// <summary>
		/// Тип документа
		/// </summary>
		[JsonProperty("type")]
		public DocumentTypeEnum Type { get; set; }

		/// <summary>
		/// Информация для предварительного просмотра документа
		/// </summary>
		public DocumentPreview Preview { get; set; }

		/// <summary>
		/// Адрес изображения с размером 100x75px (если файл графический).
		/// </summary>
		public string Photo100 { get; set; }

		/// <summary>
		/// Адрес изображения с размером 130x100px (если файл графический).
		/// </summary>
		public string Photo130 { get; set; }

	#region Методы

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static Document FromJson(VkResponse response)
		{
			var document = new Document
			{
				Id = response["doc_id"] ?? response["did"] ?? response["id"],
				OwnerId = response["owner_id"],
				Title = response["title"],
				Size = response["size"],
				Ext = response["ext"],
				Uri = response["url"],
				Photo100 = response["photo_100"],
				Photo130 = response["photo_130"],
				AccessKey = response["access_key"],
				Date = response["date"],
				Preview = response["preview"],
				Type = response["type"]
			};

			return document;
		}

		/// <summary>
		/// Преобразование класса <see cref="Document" /> в <see cref="VkParameters" />
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns>Результат преобразования в <see cref="Document" /></returns>
		public static implicit operator Document(VkResponse response)
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