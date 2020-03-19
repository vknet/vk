using System;

namespace VkNet.Model.RequestParams
{
	/// <summary>
	/// Параметры метода pages.get
	/// </summary>
	[Serializable]
	public class PagesGetParams
	{
		/// <summary>
		/// Идентификатор владельца вики-страницы. целое число.
		/// </summary>
		public long? OwnerId { get; set; }

		/// <summary>
		/// Идентификатор вики-страницы. целое число.
		/// </summary>
		public long? PageId { get; set; }

		/// <summary>
		/// 1 — требуется получить информацию о глобальной вики-странице. флаг, может
		/// принимать значения 1 или 0.
		/// </summary>
		public bool? Global { get; set; }

		/// <summary>
		/// 1 — получаемая wiki страница является предпросмотром для прикрепленной ссылки.
		/// флаг, может принимать значения 1 или
		/// 0.
		/// </summary>
		public bool? SitePreview { get; set; }

		/// <summary>
		/// Название страницы. строка.
		/// </summary>
		public string Title { get; set; }

		/// <summary>
		/// 1 —  требуется вернуть содержимое страницы в вики-формате. флаг, может
		/// принимать значения 1 или 0, доступен начиная
		/// с версии 5.20.
		/// </summary>
		public bool? NeedSource { get; set; }

		/// <summary>
		/// 1 —  требуется вернуть html-представление страницы. флаг, может принимать
		/// значения 1 или 0.
		/// </summary>
		public bool? NeedHtml { get; set; }
	}
}