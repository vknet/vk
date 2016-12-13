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
    public class UtilsCategory
    {
        private readonly VkApi _vk;

        public UtilsCategory(VkApi vk)
        {
            _vk = vk;
        }

        /// <summary>
        /// Возвращает информацию о том, является ли внешняя ссылка заблокированной на сайте ВКонтакте.
        /// </summary>
        /// <param name="url">Внешняя ссылка, которую необходимо проверить.</param>
        /// <returns>Статус ссылки</returns>
        /// <remarks>
        /// Страница документации ВКонтакте <see href="http://vk.com/dev/utils.checkLink"/>.
        /// </remarks>
        [Pure]
        [ApiVersion("5.44")]
        public LinkAccessType CheckLink([NotNull] string url, bool skipAuthorization = true)
        {
            return CheckLink(new Uri(url), skipAuthorization);
        }

        /// <summary>
        /// Возвращает информацию о том, является ли внешняя ссылка заблокированной на сайте ВКонтакте.
        /// </summary>
        /// <param name="url">Внешняя ссылка, которую необходимо проверить.</param>
        /// <returns>Статус ссылки</returns>
        /// <remarks>
        /// Страница документации ВКонтакте <see href="http://vk.com/dev/utils.checkLink"/>.
        /// </remarks>
        [Pure]
        [ApiVersion("5.44")]
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
        /// Страница документации ВКонтакте <see href="http://vk.com/dev/utils.resolveScreenName"/>.
        /// </remarks>
        [Pure]
        [ApiVersion("5.44")]
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
        /// Страница документации ВКонтакте <see href="http://vk.com/dev/utils.getServerTime"/>.
        /// </remarks>
        [Pure]
        [ApiVersion("5.44")]
        public DateTime GetServerTime()
        {
            return _vk.Call("utils.getServerTime", VkParameters.Empty, true);
        }
    }
}