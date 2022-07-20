using System;
using System.Diagnostics;
using VkNet.Utils;

namespace VkNet.Model.Attachments
{
	/// <summary>
	/// Ссылка на Web-страницу.
	/// См. описание http://vk.com/dev/attachments_w
	/// </summary>
	[DebuggerDisplay("[{Title}] {Uri}")]
	[Serializable]
	public class Link : MediaAttachment
	{
		/// <inheritdoc />
		protected override string Alias => "link";

		/// <summary>
		/// Идентификатор ссылки
		/// </summary>
		public string LinkId { get; set; }

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
		/// <c>"owner_id_page_id"</c>.
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
			var id = default(long?);
			var linkId = (string)response["id"];

			if (long.TryParse(linkId, out long temporaryId))
			{
				id = temporaryId;
			}

			return new Link
			{
				Id = id,
				LinkId = linkId,
				Uri = response["url"],
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
		}

		/// <summary>
		/// Преобразование класса <see cref="Link" /> в <see cref="VkParameters" />
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns>Результат преобразования в <see cref="Link" /></returns>
		public static implicit operator Link(VkResponse response)
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