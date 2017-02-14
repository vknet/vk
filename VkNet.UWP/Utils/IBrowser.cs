using System;
using System.Collections.Generic;
using System.Net;
using VkNet.Enums.Filters;

namespace VkNet.Utils
{
    /// <summary>
    /// Интерфейс браузера, с помощью которого осуществляется сетевое взаимодействие.
    /// Интерфейс введен с целью обеспечения возможности выполнения модульного тестирования.
    /// </summary>
    public interface IBrowser
    {
        /// <summary>
        /// Прокси сервер
        /// </summary>
        IWebProxy Proxy { get; set; }

        /// <summary>
        /// Выполняет JSON-запрос к ВКонтакте.
        /// </summary>
        /// <param name="url">Адрес получения json</param>
        /// <param name="parameters">Параметры метода api</param>
        /// <returns>Результат выполнения запроса, полученный от сервера в формате JSON.</returns>
        string GetJson(string url, IEnumerable<KeyValuePair<string, string>> parameters);

        /// <summary>
        /// Выполняет авторизацию ВКонтакте.
        /// Если приложение с идентификатором <paramref name="appId"/> не было установлено у пользователя, имеющего
        /// логин <paramref name="email"/>, то производится его установка с разрешениями <paramref name="settings"/>.
        /// </summary>
        /// <param name="appId">Идентификатор авторизуемого приложения.</param>
        /// <param name="email">Логин пользователя ВКонтакте (его почта).</param>
        /// <param name="password">Пароль пользователя.</param>
        /// <param name="settings">Запрашиваемые для работы разрешения.</param>
        /// <param name="code">Провайдер кода для двух факторной авторизации.</param>
        /// <param name="captchaSid">Идентификатор капчи</param>
        /// <param name="captchaKey">Текст капчи.</param>
        /// <returns>
        /// Информация об авторизации приложения.
        /// </returns>
        VkAuthorization Authorize(ulong appId, string email, string password, Settings settings, Func<string> code, long? captchaSid, string captchaKey);
    }
}