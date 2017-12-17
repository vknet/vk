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
    public interface IVkApi : IDisposable, IVkApiAuth, IVkApiAuthAsync
    {
        #region Properties

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
        IUsersCategory Users { get; }

        /// <summary>
        /// API для работы с друзьями.
        /// </summary>
        IFriendsCategory Friends { get; }

        /// <summary>
        /// API для работы со статусом пользователя или сообщества.
        /// </summary>
        IStatusCategory Status { get; }

        /// <summary>
        /// API для работы с сообщениями.
        /// </summary>
        IMessagesCategory Messages { get; }

        /// <summary>
        /// API для работы с группами.
        /// </summary>
        IGroupsCategory Groups { get; }

        /// <summary>
        /// API для работы с аудио записями.
        /// </summary>
        AudioCategory Audio { get; }

        /// <summary>
        /// API для получения справочной информации (страны, города, школы, учебные заведения и т.п.).
        /// </summary>
        IDatabaseCategory Database { get; }

        /// <summary>
        /// API для работы со служебными методами.
        /// </summary>
        IUtilsCategory Utils { get; }

        /// <summary>
        /// API для работы со стеной пользователя.
        /// </summary>
        IWallCategory Wall { get; }

        /// <summary>
        /// API для работы со темами групп.
        /// </summary>
        IBoardCategory Board { get; }

        /// <summary>
        /// API для работы с закладками.
        /// </summary>
        IFaveCategory Fave { get; }

        /// <summary>
        /// API для работы с видео файлами.
        /// </summary>
        IVideoCategory Video { get; }

        /// <summary>
        /// API для работы с аккаунтом пользователя.
        /// </summary>
        IAccountCategory Account { get; }

        /// <summary>
        /// API для работы с фотографиями
        /// </summary>
        IPhotoCategory Photo { get; }

        /// <summary>
        /// API для работы с документами
        /// </summary>
        IDocsCategory Docs { get; }

        /// <summary>
        /// API для работы с лайками
        /// </summary>
        ILikesCategory Likes { get; }

        /// <summary>
        /// API для работы с wiki.
        /// </summary>
        IPagesCategory Pages { get; }

        /// <summary>
        /// API для работы с приложениями.
        /// </summary>
        IAppsCategory Apps { get; }

        /// <summary>
        /// API для работы с новостной лентой.
        /// </summary>
        INewsFeedCategory NewsFeed { get; }

        /// <summary>
        /// API для работы со статистикой.
        /// </summary>
        IStatsCategory Stats { get; }

        /// <summary>
        /// API для работы с подарками.
        /// </summary>
        IGiftsCategory Gifts { get; }

        /// <summary>
        /// API для работы с товарами.
        /// </summary>
        IMarketsCategory Markets { get; }

        /// <summary>
        /// API для работы с Авторизацией.
        /// </summary>
        IAuthCategory Auth { get; }

        /// <summary>
        /// API для работы с универсальным методом.
        /// </summary>
        IExecuteCategory Execute { get; }

        /// <summary>
        /// API для работы с опросами. 
        /// </summary>
        IPollsCategory PollsCategory { get; }

        /// <summary>
        /// Браузер.
        /// </summary>
        IBrowser Browser { get; set; }

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

        #endregion

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
        new void Dispose();

        /// <summary>
        /// Обход ошибки валидации: https://vk.com/dev/need_validation
        /// </summary>
        /// <param name="validateUrl">Адрес, на который нужно перейти для валидации</param>
        /// <param name="phoneNumber">Номер телефона, который нужно ввести на странице валидации</param>
        void Validate(string validateUrl, string phoneNumber);

        #endregion
    }
}