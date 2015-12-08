using System;
using System.Diagnostics;
using VkNet.Utils;

namespace VkNet.Model.Attachments
{

	/// <summary>
	/// Ссылка на Web-страницу.
	/// См. описание <see href="http://vk.com/dev/attachments_w"/>. Раздел "Ссылка".
	/// </summary>
	[DebuggerDisplay("[{Title}] {Url}")]
	[Serializable]
	public class Link : MediaAttachment
	{
		/// <summary>
		/// Граффити.
		/// </summary>
		static Link()
		{
			RegisterType(typeof(Link), "link");
		}
		/// <summary>
		/// Адрес ссылки.
		/// </summary>
		public Uri Url { get; set; }

		/// <summary>
		/// Заголовок ссылки.
		/// </summary>
		public string Title { get; set; }

		/// <summary>
		/// Описание ссылки.
		/// </summary>
		public string Description { get; set; }

		/// <summary>
		/// Адрес превью изображения к ссылке (если имеется).
		/// </summary>
		public string Image { get; set; }

		/// <summary>
		/// Идентификатр wiki страницы с контентом для предпросмотра содержимого страницы. Идентификатор возвращается в формате "owner_id_page_id".
		/// </summary>
		public string PreviewPage { get; set; }

		/// <summary>
		/// Подпись ссылки (если имеется).
		/// </summary>
		public string Caption;

		/// <summary>
		/// Фото (если имеется).
		/// </summary>
		public Photo Photo;

		/// <summary>
		/// Является ли ссылкой на внешний ресурс (если имеется).
		/// </summary>
		public bool? IsExternal;

		/// <summary>
		/// Продукт.
		/// </summary>
		public Product Product;

		/// <summary>
		/// Рейтинг.
		/// </summary>
		public Rating Rating;

		/// <summary>
		/// Приложение.
		/// </summary>
		public Application Application;

		/// <summary>
		/// Кнопка.
		/// </summary>
		public Button Button;

		/// <summary>
		/// Адрес страницы для предпросмотра содержимого страницы.
		/// </summary>
		public Uri PreviewUrl;

		/// <summary>
		/// Преобразовать к строке.
		/// </summary>
		/// <returns>
		/// Адрес ссылки.
		/// </returns>
		public override string ToString()
		{
			return Url.ToString();
		}

		#region Методы
		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response">Ответ сервера.</param>
		/// <returns></returns>
		internal static Link FromJson(VkResponse response)
		{
			var link = new Link
			{
				Id = response["id"],
				Url = response["url"],
				Title = response["title"],
				Description = response["description"] ?? response["desc"],
				Image = response["image_src"],
				PreviewPage = response["preview_page"],
				Caption = response["caption"],
				Photo = response["photo"],
				IsExternal = response["is_external"],
				Product = response["product"],
				Rating = response["rating"],
				Application = response["application"],
				Button = response["button"],
				PreviewUrl = response["preview_url"]
			};

			return link;
		}

		#endregion
	}
}