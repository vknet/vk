using System;
using VkNet.Model.Attachments;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkNet.Categories
{
    /// <summary>
    /// Методы для работы с wiki.
    /// </summary>
    public partial class PagesCategory
    {

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
        [ApiVersion("5.44")]
        [Obsolete("Устаревшая версия API. Используйте метод Get(PagesGetParams @params)")]
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
        [ApiVersion("5.44")]
        [Obsolete("Устаревшая версия API. Используйте метод Get(PagesGetParams @params)")]
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
        [ApiVersion("5.44")]
        [Obsolete("Устаревшая версия API. Используйте метод Get(PagesGetParams @params)")]
        private Page Get(long ownerId, string title = "", long? pageId = null, bool global = false, bool sitePreview = false, bool needSource = false, bool needHtml = false)
        {
            var parameters = new PagesGetParams
            {
                OwnerId = ownerId,
                PageId = pageId,
                Global = global,
                SitePreview = sitePreview,
                Title = title,
                NeedHtml = needHtml,
                NeedSource = needSource
            };

            return Get(parameters);
        }

    }
}