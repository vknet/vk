using VkNet.Enums.SafetyEnums;

namespace VkNet.Categories
{
    using System;
    using JetBrains.Annotations;
    using Model;
    using Utils;

    /// <summary>
    /// Служебные методы.
    /// </summary>
    public class UtilsCategory : IUtilsCategory
    {
        private readonly VkApi _vk;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vk"></param>
        public UtilsCategory(VkApi vk)
        {
            _vk = vk;
        }

	    /// <summary>
	    /// Возвращает информацию о том, является ли внешняя ссылка заблокированной на сайте ВКонтакте.
	    /// </summary>
	    /// <param name="url">Внешняя ссылка, которую необходимо проверить.</param>
	    /// <param name="skipAuthorization">Без авторизации</param>
	    /// <returns>Статус ссылки</returns>
	    /// <remarks>
	    /// Страница документации ВКонтакте http://vk.com/dev/utils.checkLink
	    /// </remarks>
	    [Pure]
        public LinkAccessType CheckLink([NotNull] string url, bool skipAuthorization = true)
        {
            return CheckLink(new Uri(url), skipAuthorization);
        }

	    /// <summary>
	    /// Возвращает информацию о том, является ли внешняя ссылка заблокированной на сайте ВКонтакте.
	    /// </summary>
	    /// <param name="url">Внешняя ссылка, которую необходимо проверить.</param>
	    /// <param name="skipAuthorization">Без авторизации</param>
	    /// <returns>Статус ссылки</returns>
	    /// <remarks>
	    /// Страница документации ВКонтакте http://vk.com/dev/utils.checkLink
	    /// </remarks>
	    [Pure]
        public LinkAccessType CheckLink([NotNull] Uri url, bool skipAuthorization = true)
        {
            var parameters = new VkParameters { { "url", url } };

            return _vk.Call("utils.checkLink", parameters, skipAuthorization);
        }

        /// <summary>
        /// Определяет тип объекта (пользователь, сообщество, приложение) и его идентификатор по короткому имени ScreenName.
        /// </summary>
        /// <param name="screenName">Короткое имя</param>
        /// <returns>Тип объекта</returns>
        /// <remarks>
        /// Страница документации ВКонтакте http://vk.com/dev/utils.resolveScreenName
        /// </remarks>
        [Pure]
        public VkObject ResolveScreenName([NotNull] string screenName)
        {
            VkErrors.ThrowIfNullOrEmpty(() => screenName);

            var parameters = new VkParameters { { "screen_name", screenName } };

            return _vk.Call("utils.resolveScreenName", parameters, true);
        }

        /// <summary>
        /// Возвращает текущее время на сервере ВКонтакте в unixtime.
        /// </summary>
        /// <returns>Время на сервере ВКонтакте в unixtime</returns>
        /// <remarks>
        /// Страница документации ВКонтакте http://vk.com/dev/utils.getServerTime
        /// </remarks>
        [Pure]
        public DateTime GetServerTime()
        {
            return _vk.Call("utils.getServerTime", VkParameters.Empty, true);
        }

        /// <summary>
        /// Позволяет получить URL, сокращенный с помощью vk.cc.
        /// </summary>
        /// <returns>URL, сокращенный с помощью vk.cc</returns>
        public ShortLink GetShortLink(Uri url, bool isPrivate)
        {
            var parameters = new VkParameters
            {
                { "url", url },
                { "private", isPrivate }
            };

            return _vk.Call("utils.getShortLink", parameters);
        }
    }
}