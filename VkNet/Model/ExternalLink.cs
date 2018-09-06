using System;
using Newtonsoft.Json;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Ссылки в группе
	/// </summary>
	[Serializable]
	public class ExternalLink
	{
		/// <summary>
		/// Идентификатор ссылки.
		/// </summary>
		[JsonProperty(propertyName: "id")]
		public string Id { get; set; }

		/// <summary>
		/// Адрес ссылки.
		/// </summary>
		[JsonProperty(propertyName: "url")]
		public string Uri { get; set; }

		/// <summary>
		/// Название страницы, на которую ведет ссылка.
		/// </summary>
		[JsonProperty(propertyName: "name")]
		public string Name { get; set; }

		/// <summary>
		/// Описание.
		/// </summary>
		[JsonProperty(propertyName: "desc")]
		public string Description { get; set; }

		/// <summary>
		/// Фото 50px.
		/// </summary>
		[JsonProperty(propertyName: "photo_50")]
		public string Photo50 { get; set; }

		/// <summary>
		/// Фото 100px.
		/// </summary>
		[JsonProperty(propertyName: "photo_100")]
		public string Photo100 { get; set; }

		/// <summary>
		/// Возвращается 1, если можно редактировать название ссылки (для внешних ссылок)
		/// </summary>
		[JsonProperty(propertyName: "edit_title")]
		public bool? EditTitle { get; set; }

		/// <summary>
		/// Возвращается 1, если превью находится в процессе обработки.
		/// </summary>
		[JsonProperty(propertyName: "image_processing")]
		public bool? ImageProcessing { get; set; }

	#region Методы

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static ExternalLink FromJson(VkResponse response)
		{
			var contact = new ExternalLink
			{
					Id = response[key: "id"]
					, Uri = response[key: "url"]
					, Name = response[key: "name"] ?? response[key: "title"]
					, Description = response[key: "desc"] ?? response[key: "description"]
					, Photo50 = response[key: "photo_50"]
					, Photo100 = response[key: "photo_100"]
					, EditTitle = response[key: "edit_title"]
					, ImageProcessing = response[key: "image_processing"]
			};

			return contact;
		}

	#endregion
	}
}