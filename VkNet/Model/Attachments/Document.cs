using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
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
		static Document()
		{
			RegisterType(type: typeof(Document), match: "doc");
		}

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
		public string Uri { get; set; }

		/// <summary>
		/// Дата добавления в формате unixtime.
		/// </summary>
		[JsonConverter(converterType: typeof(UnixDateTimeConverter))]
		public DateTime? Date { get; set; }

		/// <summary>
		/// тип документа
		/// </summary>
		[JsonProperty(propertyName: "type")]
		public DocumentType Type { get; set; }

		/// <summary>
		/// Gets or sets the preview.
		/// </summary>
		public Previews Preview { get; set; }

		/// <summary>
		/// Адрес изображения с размером 100x75px (если файл графический).
		/// </summary>
		public string Photo100 { get; set; }

		/// <summary>
		/// Адрес изображения с размером 130x100px (если файл графический).
		/// </summary>
		public string Photo130 { get; set; }

		/// <summary>
		/// Ключ доступа к закрытым ресурсам
		/// </summary>
		public string AccessKey { get; set; }

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
					Id = response[key: "doc_id"] ?? response[key: "did"] ?? response[key: "id"]
					, OwnerId = response[key: "owner_id"]
					, Title = response[key: "title"]
					, Size = response[key: "size"]
					, Ext = response[key: "ext"]
					, Uri = response[key: "url"]
					, Photo100 = response[key: "photo_100"]
					, Photo130 = response[key: "photo_130"]
					, AccessKey = response[key: "access_key"]
					, Date = response[key: "date"]
					, Preview = response[key: "preview"]
					, Type = response[key: "type"]
			};

			return document;
		}

	#endregion
	}
}