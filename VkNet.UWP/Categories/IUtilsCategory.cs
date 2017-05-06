namespace VkNet.Categories
{
    using System;
    using Enums.SafetyEnums;
    using JetBrains.Annotations;
    using Model;

    /// <summary>
    /// Служебные методы.
    /// </summary>
    public interface IUtilsCategory
    {
        /// <summary>
        /// Возвращает информацию о том, является ли внешняя ссылка заблокированной на сайте ВКонтакте.
        /// </summary>
        /// <param name="url">Внешняя ссылка, которую необходимо проверить.</param>
        /// <param name="skipAuthorization">Без авторизации</param>
        /// <returns>Статус ссылки</returns>
        /// <remarks>
        /// Страница документации ВКонтакте http://vk.com/dev/utils.checkLink
        /// </remarks>
        LinkAccessType CheckLink([NotNull] string url, bool skipAuthorization = true);

        /// <summary>
        /// Возвращает информацию о том, является ли внешняя ссылка заблокированной на сайте ВКонтакте.
        /// </summary>
        /// <param name="url">Внешняя ссылка, которую необходимо проверить.</param>
        /// <param name="skipAuthorization">Без авторизации</param>
        /// <returns>Статус ссылки</returns>
        /// <remarks>
        /// Страница документации ВКонтакте http://vk.com/dev/utils.checkLink
        /// </remarks>
        LinkAccessType CheckLink([NotNull] Uri url, bool skipAuthorization = true);

        /// <summary>
        /// Определяет тип объекта (пользователь, сообщество, приложение) и его идентификатор по короткому имени ScreenName.
        /// </summary>
        /// <param name="screenName">Короткое имя</param>
        /// <returns>Тип объекта</returns>
        /// <remarks>
        /// Страница документации ВКонтакте http://vk.com/dev/utils.resolveScreenName
        /// </remarks>
        VkObject ResolveScreenName([NotNull] string screenName);

        /// <summary>
        /// Возвращает текущее время на сервере ВКонтакте в unixtime.
        /// </summary>
        /// <returns>Время на сервере ВКонтакте в unixtime</returns>
        /// <remarks>
        /// Страница документации ВКонтакте http://vk.com/dev/utils.getServerTime
        /// </remarks>
        DateTime GetServerTime();

        /// <summary>
        /// Позволяет получить URL, сокращенный с помощью vk.cc.
        /// </summary>
        /// <returns>URL, сокращенный с помощью vk.cc</returns>
        ShortLink GetShortLink(Uri url, bool isPrivate);
    }
}