using VkNet.Enums.SafetyEnums;

namespace VkNet.Categories
{
    using System;
    using JetBrains.Annotations;

    using Enums;
    using Model;
    using Utils;

    /// <summary>
    /// Служебные методы.
    /// </summary>
    public class UtilsCategory
    {
        private readonly VkApi _vk;

        internal UtilsCategory(VkApi vk)
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
        public LinkAccessType CheckLink([NotNull] string url)
        {
            VkErrors.ThrowIfNullOrEmpty(() => url);

            var parameters = new VkParameters { {"url", url} };

            var response = _vk.Call("utils.checkLink", parameters, true);
            return response;
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
        public VkObject ResolveScreenName([NotNull] string screenName)
        {
            VkErrors.ThrowIfNullOrEmpty(() => screenName);

            var parameters = new VkParameters {{"screen_name", screenName}};

            var response = _vk.Call("utils.resolveScreenName", parameters, true);

            if (response == null) return null;
            return response;
        }

        /// <summary>
        /// Возвращает текущее время на сервере ВКонтакте в unixtime.
        /// </summary>
        /// <returns>Время на сервере ВКонтакте в unixtime</returns>
        /// <remarks>
        /// Страница документации ВКонтакте <see href="http://vk.com/dev/utils.getServerTime"/>.
        /// </remarks>
        [Pure]
        public DateTime GetServerTime()
        {
            return _vk.Call("utils.getServerTime", VkParameters.Empty, true);
        }
    }
}