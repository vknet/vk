using System;
using VkNet.Enums;
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
		public Page Get(long ownerId, long? pageId, bool global = false, bool sitePreview = false, bool needSource = false, bool needHtml = false)
		{
			return Get(ownerId, "", pageId, global, sitePreview, needSource, needHtml);
		}

		/// <summary>
		/// get
		/// </summary>
		/// <param name="ownerId">Идентификатор владельца вики-страницы.</param>
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
		public Page Get(long ownerId, string title, bool global = false, bool sitePreview = false, bool needSource = false, bool needHtml = false)
		{
			return Get(ownerId, title, null, global, sitePreview, needSource, needHtml);
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
		Page Get(long ownerId, string title = "", long? pageId = null, bool global = false, bool sitePreview = false, bool needSource = false, bool needHtml = false)
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
		/// Сохраняет текст вики-страницы.
		/// </summary>
		/// <param name="text">Новый текст страницы в вики-формате.</param>
		/// <param name="pageId">Идентификатор вики-страницы.</param>
		/// <param name="groupId">Идентификатор сообщества, которому принадлежит вики-страница.</param>
		/// <param name="userId">Идентификатор пользователя, создавшего вики-страницу.</param>
		/// <returns>
		/// В случае успеха возвращает id созданной страницы.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="https://vk.com/dev/pages.save" />.
		/// </remarks>
		[ApiVersion("5.37")]
		public long Save(string text, long groupId, long pageId, long userId)
		{
			return Save(text, groupId, userId, pageId: pageId);
		}

		/// <summary>
		/// Сохраняет текст вики-страницы.
		/// </summary>
		/// <param name="text">Новый текст страницы в вики-формате.</param>
		/// <param name="groupId">Идентификатор сообщества, которому принадлежит вики-страница.</param>
		/// <param name="userId">Идентификатор пользователя, создавшего вики-страницу.</param>
		/// <param name="title">Название вики-страницы.</param>
		/// <returns>
		/// В случае успеха возвращает id созданной страницы.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="https://vk.com/dev/pages.save" />.
		/// </remarks>
		[ApiVersion("5.37")]
		public long Save(string text, long groupId, string title, long userId)
		{
			return Save(text, groupId, userId, title: title);
		}

		/// <summary>
		/// Сохраняет текст вики-страницы.
		/// </summary>
		/// <param name="text">Новый текст страницы в вики-формате.</param>
		/// <param name="pageId">The page_id.</param>
		/// <param name="groupId">Идентификатор сообщества, которому принадлежит вики-страница.</param>
		/// <param name="title">Название вики-страницы.</param>
		/// <param name="userId">Идентификатор пользователя, создавшего вики-страницу.</param>
		/// <returns>
		/// В случае успеха возвращает id созданной страницы.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="https://vk.com/dev/pages.save" />.
		/// </remarks>
		[ApiVersion("5.37")]
		long Save(string text, long groupId, long userId, long? pageId = null, string title = "")
		{
			var parameters = new VkParameters
			{
				{ "text", text },
				{ "groupId", groupId },
				{ "user_id", userId },
				{ "title", title },
				{ "page_id", pageId }
			};

			return _vk.Call("pages.save", parameters);
		}


		/// <summary>
		/// Сохраняет новые настройки доступа на чтение и редактирование вики-страницы.
		/// </summary>
		/// <param name="pageId">Идентификатор вики-страницы. </param>
		/// <param name="groupId">Идентификатор сообщества, которому принадлежит вики-страница.</param>
		/// <param name="userId">Идентификатор пользователя, создавшего вики-страницу.</param>
		/// <param name="view">Значение настройки доступа на чтение.</param>
		/// <param name="edit">Значение настройки доступа на редактирование.</param>
		/// <returns>
		/// В случае успеха возвращает id страницы, доступ к которой был отредактирован.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="https://vk.com/dev/pages.saveAccess" />.
		/// </remarks>
		[ApiVersion("5.37")]
		public long SaveAccess(long pageId, long groupId, long? userId = null, AccessPages view = AccessPages.All, AccessPages edit = AccessPages.Leaders)
		{
			var parameters = new VkParameters
			{
				{ "page_id", pageId },
				{ "group_id", groupId },
				{ "user_id", userId },
				{ "view", view },
				{ "edit", edit }
			};

			return _vk.Call("pages.saveAccess", parameters);
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