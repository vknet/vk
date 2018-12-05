﻿using System;
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
			RegisterType(typeof(Document), "doc");
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
		[JsonConverter(typeof(UnixDateTimeConverter))]
		public DateTime? Date { get; set; }

		/// <summary>
		/// тип документа
		/// </summary>
		[JsonProperty("type")]
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

		/// <inheritdoc />
		public override string ToString()
		{
			return string.IsNullOrWhiteSpace(AccessKey)
				? base.ToString()
				: $"{base.ToString()}_{AccessKey}";
		}

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

	#endregion
	}
}