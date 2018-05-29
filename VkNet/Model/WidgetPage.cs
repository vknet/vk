using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using VkNet.Model.Attachments;

namespace VkNet.Model
{
	/// <summary>
	/// Объект-страница для виджета
	/// </summary>
	[Serializable]
	public class WidgetPage
	{
		/// <summary>
		/// Идентификатор страницы в системе;
		/// </summary>
		[JsonProperty(propertyName: "id")]
		public string Id { get; set; }

		/// <summary>
		/// Заголовок страницы (берется из мета-тегов на странице или задается параметром
		/// pageTitle при инициализации)
		/// </summary>
		[JsonProperty(propertyName: "title")]
		public string Title { get; set; }

		/// <summary>
		/// Краткое описание страницы (берется из мета-тегов на странице или задается
		/// параметром pageDescription при
		/// инициализации);
		/// </summary>
		[JsonProperty(propertyName: "description")]
		public string Description { get; set; }

		/// <summary>
		/// Абсолютный адрес страницы;
		/// </summary>
		[JsonProperty(propertyName: "url")]
		public Uri Url { get; set; }

		/// <summary>
		/// Объект, содержащий поле count — количество отметок «Мне нравится» к странице.
		/// </summary>
		[JsonProperty(propertyName: "likes")]
		public ObjectCount Likes { get; set; }

		/// <summary>
		/// Объект, содержащий поле count — количество комментариев к странице внутри
		/// виджета.
		/// </summary>
		[JsonProperty(propertyName: "comments")]
		public ObjectCount Comments { get; set; }

		/// <summary>
		/// Дата первого обращения к виджетам на странице
		/// </summary>
		[JsonProperty(propertyName: "date")]
		[JsonConverter(converterType: typeof(UnixDateTimeConverter))]
		public DateTime Date { get; set; }

		/// <summary>
		/// Объект, содержащий фотографию-миниатюру страницы (берется из мета-тегов на
		/// странице или задается параметром
		/// pageImage при инициализации)
		/// </summary>
		[JsonProperty(propertyName: "photo")]
		public Photo Photo { get; set; }

		/// <summary>
		/// Внутренний идентификатор страницы в приложении/на сайте (в случае, если при
		/// инициализации виджетов использовался
		/// параметр page_id);
		/// </summary>
		[JsonProperty(propertyName: "pageId")]
		public long PageId { get; set; }
	}
}