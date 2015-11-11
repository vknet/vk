using System;
using System.Collections.ObjectModel;
using VkNet.Enums;
using VkNet.Model;
using VkNet.Model.Attachments;

namespace VkNet.Categories
{
#if WINDOWS_PHONE
	using System.Net;
#else
	using System.Web;

#endif
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
		/// Возвращает информацию о вики-странице.
		/// </summary>
		/// <param name="ownerId">Идентификатор владельца вики-страницы.</param>
		/// <param name="pageId">Идентификатор вики-страницы.</param>
		/// <param name="global"><c>true</c> — требуется получить информацию о глобальной вики-странице. </param>
		/// <param name="sitePreview"><c>true</c>— получаемая wiki страница является предпросмотром для прикрепленной ссылки.</param>
		/// <param name="needSource"><c>true</c> — требуется вернуть содержимое страницы в вики-формате.</param>
		/// <param name="needHtml"><c>true</c> — требуется вернуть html-представление страницы.</param>
		/// <returns>
		/// Возвращает информацию о вики-странице в виде объекта page. 
		/// Если был задан параметр need_source равный 1, дополнительно будет возвращено поле source.
		/// Если был задан параметр need_html равный 1, дополнительно будет возвращено поле html.
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
		/// Возвращает информацию о вики-странице.
		/// </summary>
		/// <param name="ownerId">Идентификатор владельца вики-страницы.</param>
		/// <param name="global"><c>true</c> — требуется получить информацию о глобальной вики-странице. </param>
		/// <param name="sitePreview"><c>true</c>— получаемая wiki страница является предпросмотром для прикрепленной ссылки.</param>
		/// <param name="title">Название страницы.</param>
		/// <param name="needSource"><c>true</c> — требуется вернуть содержимое страницы в вики-формате.</param>
		/// <param name="needHtml"><c>true</c> — требуется вернуть html-представление страницы.</param>
		/// <returns>
		/// Возвращает информацию о вики-странице в виде объекта page. 
		/// Если был задан параметр need_source равный 1, дополнительно будет возвращено поле source.
		/// Если был задан параметр need_html равный 1, дополнительно будет возвращено поле html.
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
		/// Возвращает информацию о вики-странице.
		/// </summary>
		/// <param name="ownerId">Идентификатор владельца вики-страницы.</param>
		/// <param name="pageId">Идентификатор вики-страницы.</param>
		/// <param name="global"><c>true</c> — требуется получить информацию о глобальной вики-странице. </param>
		/// <param name="sitePreview"><c>true</c>— получаемая wiki страница является предпросмотром для прикрепленной ссылки.</param>
		/// <param name="title">Название страницы.</param>
		/// <param name="needSource"><c>true</c> — требуется вернуть содержимое страницы в вики-формате.</param>
		/// <param name="needHtml"><c>true</c> — требуется вернуть html-представление страницы.</param>
		/// <returns>
		/// Возвращает информацию о вики-странице в виде объекта page. 
		/// Если был задан параметр need_source равный 1, дополнительно будет возвращено поле source.
		/// Если был задан параметр need_html равный 1, дополнительно будет возвращено поле html.
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
			return Save(text, groupId, userId, pageId, null);
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
		/// Возвращает список всех старых версий вики-страницы.
		/// </summary>
		/// <param name="pageId">Идентификатор вики-страницы.</param>
		/// <param name="groupId">Идентификатор сообщества, которому принадлежит вики-страница. </param>
		/// <param name="userId">Идентификатор пользователя, создавшего вики-страницу.</param>
		/// <returns>
		/// Возвращает массив объектов page_version, имеющих следующую структуру.
		/// id — идентификатор версии страницы;
		/// length длина версии страницы в байтах;
		/// edited — дата редактирования страницы;
		/// editor_id — идентификатор редактора;
		/// editor_name — имя редактора.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="https://vk.com/dev/pages.getHistory" />.
		/// </remarks>
		[ApiVersion("5.37")]
		public ReadOnlyCollection<History> GetHistory(long pageId, long groupId, long? userId = null)
		{
			var parameters = new VkParameters
			{
				{ "page_id", pageId },
				{ "group_id", groupId },
				{ "user_id", userId }
			};
			VkResponseArray result = _vk.Call("pages.getHistory", parameters);
			
			return result.ToReadOnlyCollectionOf<History>(x => x);
		}


		/// <summary>
		/// Возвращает список вики-страниц в группе.
		/// </summary>
		/// <param name="groupId">Идентификатор сообщества, которому принадлежит вики-страница.</param>
		/// <returns>
		/// Возвращает массив объектов вики-страниц.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="https://vk.com/dev/pages.getTitles" />.
		/// </remarks>
		[ApiVersion("5.37")]
		public ReadOnlyCollection<Page> GetTitles(long groupId)
		{
			var parameters = new VkParameters
			{
				{ "group_id", groupId }
			};
			VkResponseArray result = _vk.Call("pages.getTitles", parameters);

			return result.ToReadOnlyCollectionOf<Page>(x => x);
		}


		/// <summary>
		/// Возвращает текст одной из старых версий страницы.
		/// </summary>
		/// <param name="versionId">Идентификатор версии. </param>
		/// <param name="groupId">Идентификатор сообщества, которому принадлежит вики-страница.</param>
		/// <param name="needHtml">Определяет, требуется ли в ответе html-представление вики-страницы.</param>
		/// <param name="userId">Идентификатор пользователя, который создал страницу.</param>
		/// <returns>
		/// Возвращает объект вики-страницы.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="https://vk.com/dev/pages.getVersion" />.
		/// </remarks>
		[ApiVersion("5.37")]
		public Page GetVersion(long versionId, long groupId, bool needHtml = false, long? userId = null)
		{
			var parameters = new VkParameters
			{
				{ "version_id", versionId },
				{ "group_id", groupId },
				{ "user_id", userId },
				{ "need_html", needHtml }
			};

			return _vk.Call("pages.getTitles", parameters);
		}


		/// <summary>
		/// Возвращает html-представление вики-разметки.
		/// </summary>
		/// <param name="text">Текст в вики-формате.</param>
		/// <param name="groupId">Идентификатор группы, в контексте которой интерпретируется данная страница.</param>
		/// <returns>
		/// В случае успеха возвращает экранированный html, соответствующий вики-разметке.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="https://vk.com/dev/pages.parseWiki" />.
		/// </remarks>
		[ApiVersion("5.37")]
		public string ParseWiki(string text, ulong groupId)
		{
			var parameters = new VkParameters
			{
				{ "text", HttpUtility.UrlEncode(text) },
				{ "group_id", groupId }
			};

			return _vk.Call("pages.parseWiki", parameters);
		}


		/// <summary>
		/// Позволяет очистить кеш отдельных внешних страниц, которые могут быть прикреплены к записям ВКонтакте.
		/// После очистки кеша при последующем прикреплении ссылки к записи, данные о странице будут обновлены.
		/// Внешние страницы – страницы которые прикрепляются к записям вместе с ссылкой и доступные по кнопке "Предпросмотр".
		/// </summary>
		/// <param name="url">URL.</param>
		/// <returns>
		/// При удачной очистке кеша – метод возвращает <c>true</c>.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="https://vk.com/dev/pages.clearCache" />.
		/// </remarks>
		[ApiVersion("5.37")]
		public bool ClearCache(Uri url)
		{
			var parameters = new VkParameters
			{
				{ "url", url }
			};

			return _vk.Call("pages.clearCache", parameters);
		}


	}
}