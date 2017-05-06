﻿namespace VkNet.Categories
{
    using System;
    using System.Collections.ObjectModel;
    using Enums;
    using Model;
    using Model.Attachments;
    using Model.RequestParams;

    /// <summary>
	/// Методы для работы с wiki.
	/// </summary>
    public interface IPagesCategory
    {
        /// <summary>
        /// Возвращает информацию о вики-странице..
        /// </summary>
        /// <param name="params">Параметры запроса.</param>
        /// <returns>
        /// Возвращает информацию о вики-странице в виде объекта page.
        /// Если был задан параметр need_source равный 1, дополнительно будет возвращено поле source.
        /// Если был задан параметр need_html равный 1, дополнительно будет возвращено поле html..
        /// </returns>
        /// <remarks>
        /// Страница документации ВКонтакте http://vk.com/dev/pages.get
        /// </remarks>
        Page Get(PagesGetParams @params);

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
        /// Страница документации ВКонтакте https://vk.com/dev/pages.save
        /// </remarks>
        long Save(string text, long groupId, long pageId, long userId);

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
        /// Страница документации ВКонтакте https://vk.com/dev/pages.save
        /// </remarks>
        long Save(string text, long groupId, string title, long userId);

        /// <summary>
        /// Сохраняет текст вики-страницы..
        /// </summary>
        /// <param name="text">Новый текст страницы в вики-формате. строка (Строка).</param>
        /// <param name="pageId">Идентификатор вики-страницы. Вместо page_id может быть передан параметр title. целое число (Целое число).</param>
        /// <param name="groupId">Идентификатор сообщества, которому принадлежит вики-страница. целое число (Целое число).</param>
        /// <param name="userId">Идентификатор пользователя, создавшего вики-страницу. целое число (Целое число).</param>
        /// <param name="title">Название вики-страницы. строка (Строка).</param>
        /// <returns>
        /// В случае успеха возвращает id созданной страницы..
        /// </returns>
        /// <remarks>
        /// Страница документации ВКонтакте http://vk.com/dev/pages.save
        /// </remarks>
        long Save(string text, long groupId, long userId, long? pageId = null, string title = "");

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
        /// Страница документации ВКонтакте https://vk.com/dev/pages.saveAccess
        /// </remarks>
        long SaveAccess(long pageId, long groupId, long? userId = null, AccessPages view = AccessPages.All, AccessPages edit = AccessPages.Leaders);

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
        /// Страница документации ВКонтакте https://vk.com/dev/pages.getHistory
        /// </remarks>
        ReadOnlyCollection<History> GetHistory(long pageId, long groupId, long? userId = null);

        /// <summary>
        /// Возвращает список вики-страниц в группе.
        /// </summary>
        /// <param name="groupId">Идентификатор сообщества, которому принадлежит вики-страница.</param>
        /// <returns>
        /// Возвращает массив объектов вики-страниц.
        /// </returns>
        /// <remarks>
        /// Страница документации ВКонтакте https://vk.com/dev/pages.getTitles
        /// </remarks>
        ReadOnlyCollection<Page> GetTitles(long groupId);

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
        /// Страница документации ВКонтакте https://vk.com/dev/pages.getVersion
        /// </remarks>
        Page GetVersion(long versionId, long groupId, bool needHtml = false, long? userId = null);

        /// <summary>
        /// Возвращает html-представление вики-разметки.
        /// </summary>
        /// <param name="text">Текст в вики-формате.</param>
        /// <param name="groupId">Идентификатор группы, в контексте которой интерпретируется данная страница.</param>
        /// <returns>
        /// В случае успеха возвращает экранированный html, соответствующий вики-разметке.
        /// </returns>
        /// <remarks>
        /// Страница документации ВКонтакте https://vk.com/dev/pages.parseWiki
        /// </remarks>
        string ParseWiki(string text, ulong groupId);

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
        /// Страница документации ВКонтакте https://vk.com/dev/pages.clearCache
        /// </remarks>
        bool ClearCache(Uri url);
    }
}