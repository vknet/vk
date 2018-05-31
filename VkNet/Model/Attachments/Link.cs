using System;
using System.Diagnostics;
using VkNet.Utils;

namespace VkNet.Model.Attachments
{
	/// <summary>
	/// Ссылка на Web-страницу.
	/// См. описание http://vk.com/dev/attachments_w
	/// </summary>
	[DebuggerDisplay(value: "[{Title}] {Uri}")]
	[Serializable]
	public class Link : MediaAttachment
	{
		/// <summary>
		/// Граффити.
		/// </summary>
		static Link()
		{
			RegisterType(type: typeof(Link), match: "link");
		}

		/// <summary>
		/// Адрес ссылки.
		/// </summary>
		public Uri Uri { get; set; }

		/// <summary>
		/// Заголовок ссылки.
		/// </summary>
		public string Title { get; set; }

		/// <summary>
		/// Подпись ссылки (если имеется).
		/// </summary>
		public string Caption { get; set; }

		/// <summary>
		/// Описание ссылки.
		/// </summary>
		public string Description { get; set; }

		/// <summary>
		/// Фото (если имеется).
		/// </summary>
		public Photo Photo { get; set; }

		/// <summary>
		/// Продукт.
		/// </summary>
		public Market Product { get; set; }

		/// <summary>
		/// Кнопка.
		/// </summary>
		public LinkButton Button { get; set; }

		/// <summary>
		/// Идентификатр wiki страницы с контентом для предпросмотра содержимого страницы.
		/// Идентификатор возвращается в формате
		/// "owner_id_page_id".
		/// </summary>
		public string PreviewPage { get; set; }

		/// <summary>
		/// Адрес страницы для предпросмотра содержимого страницы.
		/// </summary>
		public Uri PreviewUrl { get; set; }

		/// <summary>
		/// Адрес превью изображения к ссылке (если имеется).
		/// </summary>
		public string Image { get; set; }

		/// <summary>
		/// Является ли ссылкой на внешний ресурс (если имеется).
		/// </summary>
		public bool? IsExternal { get; set; }

		/// <summary>
		/// Рейтинг.
		/// </summary>
		public Rating Rating { get; set; }

		/// <summary>
		/// Приложение.
		/// </summary>
		public Application Application { get; set; }

		/// <summary>
		/// Преобразовать к строке.
		/// </summary>
		/// <returns>
		/// Адрес ссылки.
		/// </returns>
		public override string ToString()
		{
			return Uri.ToString();
		}

	#region Методы

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static Link FromJson(VkResponse response)
		{
			var link = new Link
			{
					Id = response[key: "id"]
					, Uri = response[key: "url"]
					, Title = response[key: "title"]
					, Description = response[key: "description"] ?? response[key: "desc"]
					, Image = response[key: "image_src"]
					, PreviewPage = response[key: "preview_page"]
					, Caption = response[key: "caption"]
					, Photo = response[key: "photo"]
					, IsExternal = response[key: "is_external"]
					, Product = response[key: "product"]
					, Rating = response[key: "rating"]
					, Application = response[key: "application"]
					, Button = response[key: "button"]
					, PreviewUrl = response[key: "preview_url"]
			};

			return link;
		}

	#endregion
	}
}