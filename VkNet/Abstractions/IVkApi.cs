using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VkNet.Categories;
using VkNet.Enums;
using VkNet.Exception;
using VkNet.Utils;

namespace VkNet.Abstractions
{
    /// <summary>
    /// VkApi
    /// </summary>
    public interface IVkApi : IDisposable
    {
        /// <summary>
        /// Время вызова последнего метода этим объектом
        /// </summary>
        DateTimeOffset? LastInvokeTime { get; }

        /// <summary>
        /// Время, прошедшее с момента последнего обращения к API этим объектом
        /// </summary>
        TimeSpan? LastInvokeTimeSpan { get; }

        /// <summary>
        /// Ограничение на кол-во запросов в секунду
        /// </summary>
        float RequestsPerSecond { get; set; }

        /// <summary>
        /// API для работы с пользователями.
        /// </summary>
        UsersCategory Users { get; }

        /// <summary>
        /// API для работы с друзьями.
        /// </summary>
        FriendsCategory Friends { get; }

        /// <summary>
        /// API для работы со статусом пользователя или сообщества.
        /// </summary>
        StatusCategory Status { get; }

        /// <summary>
        /// API для работы с сообщениями.
        /// </summary>
        MessagesCategory Messages { get; }

        /// <summary>
        /// API для работы с группами.
        /// </summary>
        GroupsCategory Groups { get; }

        /// <summary>
        /// API для работы с аудио записями.
        /// </summary>
        AudioCategory Audio { get; }

        /// <summary>
        /// API для получения справочной информации (страны, города, школы, учебные заведения и т.п.).
        /// </summary>
        DatabaseCategory Database { get; }

        /// <summary>
        /// API для работы со служебными методами.
        /// </summary>
        UtilsCategory Utils { get; }

        /// <summary>
        /// API для работы со стеной пользователя.
        /// </summary>
        WallCategory Wall { get; }

        /// <summary>
        /// API для работы со темами групп.
        /// </summary>
        BoardCategory Board { get; }

        /// <summary>
        /// API для работы с закладками.
        /// </summary>
        FaveCategory Fave { get; }

        /// <summary>
        /// API для работы с видео файлами.
        /// </summary>
        VideoCategory Video { get; }

        /// <summary>
        /// API для работы с аккаунтом пользователя.
        /// </summary>
        AccountCategory Account { get; }

        /// <summary>
        /// API для работы с фотографиями
        /// </summary>
        PhotoCategory Photo { get; }

        /// <summary>
        /// API для работы с документами
        /// </summary>
        DocsCategory Docs { get; }

        /// <summary>
        /// API для работы с лайками
        /// </summary>
        LikesCategory Likes { get; }

        /// <summary>
        /// API для работы с wiki.
        /// </summary>
        PagesCategory Pages { get; }

        /// <summary>
        /// API для работы с приложениями.
        /// </summary>
        AppsCategory Apps { get; }

        /// <summary>
        /// API для работы с новостной лентой.
        /// </summary>
        NewsFeedCategory NewsFeed { get; }

        /// <summary>
        /// API для работы со статистикой.
        /// </summary>
        StatsCategory Stats { get; }

        /// <summary>
        /// API для работы с подарками.
        /// </summary>
        GiftsCategory Gifts { get; }

        /// <summary>
        /// API для работы с товарами.
        /// </summary>
        MarketsCategory Markets { get; }

        /// <summary>
        /// API для работы с Авторизацией.
        /// </summary>
        AuthCategory Auth { get; }

        /// <summary>
        /// API для работы с универсальным методом.
        /// </summary>
        ExecuteCategory Execute { get; }

        /// <summary>
        /// API для работы с опросами. 
        /// </summary>
        PollsCategory PollsCategory { get; }

        /// <summary>
        /// Браузер.
        /// </summary>
        IBrowser Browser { get; set; }

        /// <summary>
        /// Была ли произведена авторизация каким либо образом
        /// </summary>
        bool IsAuthorized { get; }

        /// <summary>
        /// Токен для доступа к методам API
        /// </summary>
        string Token { get; }

        /// <summary>
        /// Идентификатор пользователя, от имени которого была проведена авторизация.
        /// Если авторизация не была произведена с использованием метода Authorize(int
        /// то возвращается null.
        /// </summary>
        // ReSharper disable once MemberCanBePrivate.Global
        long? UserId { get; set; }

        /// <summary>
        /// Максимальное количество попыток распознавания капчи c помощью зарегистрированного обработчика
        /// </summary>
        // ReSharper disable once AutoPropertyCanBeMadeGetOnly.Global
        // ReSharper disable once MemberCanBePrivate.Global
        int MaxCaptchaRecognitionCount { get; set; }

        /// <summary>
        /// Оповещает об истечении срока токена доступа
        /// </summary>
        event VkApiDelegate OnTokenExpires;

        #region Methods

        /// <summary>
        /// Установить язык
        /// </summary>
        /// <param name="language"></param>
        void SetLanguage(Language language);

        /// <summary>
        /// Установить язык
        /// </summary>
        Language? GetLanguage();

        /// <summary>
        /// Авторизация и получение токена
        /// </summary>
        /// <param name="params">Данные авторизации</param>
        void Authorize(ApiAuthParams @params);

        /// <summary>
        /// Авторизация и получение токена в асинхронном режиме
        /// </summary>
        /// <param name="params">Данные авторизации</param>
        Task AuthorizeAsync(ApiAuthParams @params);

        /// <summary>
        /// Получает новый AccessToken используя логин, пароль, приложение и настройки указанные при последней авторизации.
        /// </summary>
        /// <param name="code">Делегат двух факторной авторизации. Если не указан - будет взят из параметров (если есть)</param>
        /// <exception cref="AggregateException">
        /// Невозможно обновить токен доступа т.к. последняя авторизация происходила не при помощи логина и пароля
        /// </exception>
        void RefreshToken(Func<string> code = null);

        /// <summary>
        /// Получает новый AccessToken использую логин, пароль, приложение и настройки указанные при последней авторизации.
        /// </summary>
        /// <param name="code">Делегат двух факторной авторизации. Если не указан - будет взят из параметров (если есть)</param>
        Task RefreshTokenAsync(Func<string> code = null);

        /// <summary>
        /// Вызвать метод.
        /// </summary>
        /// <param name="methodName">Название метода.</param>
        /// <param name="parameters">Параметры.</param>
        /// <param name="skipAuthorization">Если <c>true</c> то пропустить авторизацию.</param>
        /// <returns></returns>
        VkResponse Call(string methodName, VkParameters parameters, bool skipAuthorization = false);

        /// <summary>
        /// Вызвать метод.
        /// </summary>
        /// <param name="methodName">Название метода.</param>
        /// <param name="parameters">Параметры.</param>
        /// <param name="skipAuthorization">Если <c>true</c> то пропустить авторизацию.</param>
        /// <returns></returns>
        T Call<T>(string methodName, VkParameters parameters, bool skipAuthorization = false);

        /// <summary>
        /// Прямой вызов API-метода
        /// </summary>
        /// <param name="methodName">Название метода. Например, "wall.get".</param>
        /// <param name="parameters">Вход. параметры метода.</param>
        /// <param name="skipAuthorization">Флаг, что метод можно вызывать без авторизации.</param>
        /// <exception cref="AccessTokenInvalidException"></exception>
        /// <returns>Ответ сервера в формате JSON.</returns>
        string Invoke(string methodName, IDictionary<string, string> parameters, bool skipAuthorization = false);

        /// <summary>
        /// Прямой вызов API-метода в асинхронном режиме
        /// </summary>
        /// <param name="methodName">Название метода. Например, "wall.get".</param>
        /// <param name="parameters">Вход. параметры метода.</param>
        /// <param name="skipAuthorization">Флаг, что метод можно вызывать без авторизации.</param>
        /// <returns>Ответ сервера в формате JSON.</returns>
        Task<string> InvokeAsync(string methodName, IDictionary<string, string> parameters,
            bool skipAuthorization = false);

        /// <summary>
        /// Освобождения неуправляемых ресурсов.
        /// </summary>
        void Dispose();

        /// <summary>
        /// Обход ошибки валидации: https://vk.com/dev/need_validation
        /// </summary>
        /// <param name="validateUrl">Адрес, на который нужно перейти для валидации</param>
        /// <param name="phoneNumber">Номер телефона, который нужно ввести на странице валидации</param>
        void Validate(string validateUrl, string phoneNumber);

        #endregion
    }
}