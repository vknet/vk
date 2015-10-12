using System;
using VkNet.Model.Attachments;

namespace VkNet.Categories
{
	using Utils;

	/// <summary>
	/// Методы для работы с wiki.
	/// </summary>
	public class PagesCategory
	{
		/// <summary>
		/// API
		/// </summary>
		readonly VkApi _vk;

		/// <summary>
		/// Методы для работы с wiki.
		/// </summary>
		/// <param name="vk">API.</param>
		internal PagesCategory(VkApi vk)
		{
			_vk = vk;
		}
		/// <summary>
		/// get
		/// </summary>
		/// <param name="ownerId">Идентификатор владельца вики-страницы.</param>
		/// <param name="pageId">Идентификатор вики-страницы.</param>
		/// <param name="global"><c>true</c> — требуется получить информацию о глобальной вики-странице. </param>
		/// <param name="sitePreview"><c>true</c>— получаемая wiki страница является предпросмотром для прикрепленной ссылки.</param>
		/// <param name="title">Название страницы.</param>
		/// <param name="needSource"><c>true</c> — требуется вернуть содержимое страницы в вики-формате.</param>
		/// <param name="needHtml"><c>true</c> — требуется вернуть html-представление страницы.</param>
		/// <returns>
		/// Возвращает результат выполнения метода.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="https://vk.com/dev/pages.get" />.
		/// </remarks>
		[ApiVersion("5.37")]
		public Page Get(long ownerId, string title, long? pageId = null, bool global = false, bool sitePreview = false, bool needSource = false, bool needHtml = false)
		{
			var parameters = new VkParameters
			{
				{ "owner_id", ownerId },
				{ "page_id", pageId },
				{ "global", global },
				{ "site_preview", sitePreview },
				{ "title", title },
				{ "need_source", needSource },
				{ "need_html", needHtml }
			};

			return _vk.Call("pages.get", parameters);
		}


		/// <summary>
		/// save
		/// </summary>
		/// <returns>Возвращает результат выполнения метода.</returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="https://vk.com/dev/pages.save" />.
		/// </remarks>
		[ApiVersion("5.37")]
		public bool Save()
		{
			throw new NotImplementedException();
		}


		/// <summary>
		/// saveAccess
		/// </summary>
		/// <returns>Возвращает результат выполнения метода.</returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="https://vk.com/dev/pages.saveAccess" />.
		/// </remarks>
		[ApiVersion("5.37")]
		public bool SaveAccess()
		{
			throw new NotImplementedException();
		}


		/// <summary>
		/// getHistory
		/// </summary>
		/// <returns>Возвращает результат выполнения метода.</returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="https://vk.com/dev/pages.getHistory" />.
		/// </remarks>
		[ApiVersion("5.37")]
		public bool GetHistory()
		{
			throw new NotImplementedException();
		}


		/// <summary>
		/// getTitles
		/// </summary>
		/// <returns>Возвращает результат выполнения метода.</returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="https://vk.com/dev/pages.getTitles" />.
		/// </remarks>
		[ApiVersion("5.37")]
		public bool GetTitles()
		{
			throw new NotImplementedException();
		}


		/// <summary>
		/// getVersion
		/// </summary>
		/// <returns>Возвращает результат выполнения метода.</returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="https://vk.com/dev/pages.getVersion" />.
		/// </remarks>
		[ApiVersion("5.37")]
		public bool GetVersion()
		{
			throw new NotImplementedException();
		}


		/// <summary>
		/// parseWiki
		/// </summary>
		/// <returns>Возвращает результат выполнения метода.</returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="https://vk.com/dev/pages.parseWiki" />.
		/// </remarks>
		[ApiVersion("5.37")]
		public bool ParseWiki()
		{
			throw new NotImplementedException();
		}


		/// <summary>
		/// clearCache
		/// </summary>
		/// <returns>Возвращает результат выполнения метода.</returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="https://vk.com/dev/pages.clearCache" />.
		/// </remarks>
		[ApiVersion("5.37")]
		public bool ClearCache()
		{
			throw new NotImplementedException();
		}


	}
}