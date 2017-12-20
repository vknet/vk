using System.Threading;
using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NLog;
using VkNet.Abstractions;
using VkNet.Categories;
using VkNet.Enums;
using VkNet.Exception;
using VkNet.Utils;
using VkNet.Utils.AntiCaptcha;
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable EventNeverSubscribedTo.Global

namespace VkNet
{
    /// <summary>
    /// Служит для оповещения об истечении токена
    /// </summary>
    /// <param name="sender">Экземпляр API у которого истекло время токена</param>
    public delegate void VkApiDelegate(VkApi sender);

    /// <inheritdoc />
    /// <summary>
    /// API для работы с ВКонтакте. Выступает в качестве фабрики для различных категорий API (например, для работы с пользователями,
    /// группами и т.п.).
    /// </summary>
    public class VkApi : IVkApi
    {
        /// <summary>
        /// Версия API vk.com.
        /// </summary>
        public const string VkApiVersion = "5.69";

        /// <summary>
        /// Параметры авторизации.
        /// </summary>
        private IApiAuthParams _ap;

        /// <summary>
        /// Таймер.
        /// </summary>
        private Timer _expireTimer;

        #region Requests limit stuff

        /// <summary>
        /// Запросов в секунду.
        /// </summary>
        private float _requestsPerSecond;

        /// <summary>
        /// Минимальное время, которое должно пройти между запросами чтобы не превысить кол-во запросов в секунду.
        /// </summary>
        private float _minInterval;

        /// <summary>
        /// Время вызова последнего метода этим объектом
        /// </summary>
        public DateTimeOffset? LastInvokeTime { get; private set; }

        /// <summary>
        /// Время, прошедшее с момента последнего обращения к API этим объектом
        /// </summary>
        public TimeSpan? LastInvokeTimeSpan
        {
            get
            {
                if (LastInvokeTime.HasValue)
                {
                    return DateTimeOffset.Now - LastInvokeTime.Value;
                }

                return null;
            }
        }

        private readonly object _minIntervalLock = new object();

        /// <summary>
        /// Ограничение на кол-во запросов в секунду
        /// </summary>
        public float RequestsPerSecond
        {
            get => _requestsPerSecond;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(@"Value must be positive", nameof(RequestsPerSecond));
                }

                _requestsPerSecond = value;
                if (!(_requestsPerSecond > 0))
                {
                    return;
                }

                lock (_minIntervalLock)
                {
                    _minInterval = (int) (1000 / _requestsPerSecond) + 1;
                }
            }
        }

        #endregion

        /// <summary>
        /// Оповещает об истечении срока токена доступа
        /// </summary>
        public event VkApiDelegate OnTokenExpires;

        #region Categories Definition

        /// <summary>
        /// API для работы с пользователями.
        /// </summary>
        public IUsersCategory Users { get; }

        /// <summary>
        /// API для работы с друзьями.
        /// </summary>
        public IFriendsCategory Friends { get; }

        /// <summary>
        /// API для работы со статусом пользователя или сообщества.
        /// </summary>
        public IStatusCategory Status { get; }

        /// <summary>
        /// API для работы с сообщениями.
        /// </summary>
        public IMessagesCategory Messages { get; }

        /// <summary>
        /// API для работы с .
        /// </summary>
        public IGroupsCategory Groups { get; }

        /// <summary>
        /// API для работы с аудио записями.
        /// </summary>
        public AudioCategory Audio { get; }

        /// <summary>
        /// API для получения справочной информации (страны, города, школы, учебные заведения и т.п.).
        /// </summary>
        public IDatabaseCategory Database { get; }

        /// <summary>
        /// API для работы со служебными методами.
        /// </summary>
        public IUtilsCategory Utils { get; }

        /// <summary>
        /// API для работы со стеной пользователя.
        /// </summary>
        public IWallCategory Wall { get; }

        /// <summary>
        /// API для работы со темами групп.
        /// </summary>
        public IBoardCategory Board { get; }

        /// <summary>
        /// API для работы с закладками.
        /// </summary>
        public IFaveCategory Fave { get; }

        /// <summary>
        /// API для работы с видео файлами.
        /// </summary>
        public IVideoCategory Video { get; }

        /// <summary>
        /// API для работы с аккаунтом пользователя.
        /// </summary>
        public IAccountCategory Account { get; }

        /// <summary>
        /// API для работы с фотографиями
        /// </summary>
        public IPhotoCategory Photo { get; }

        /// <summary>
        /// API для работы с документами
        /// </summary>
        public IDocsCategory Docs { get; }

        /// <summary>
        /// API для работы с лайками
        /// </summary>
        public ILikesCategory Likes { get; }

        /// <summary>
        /// API для работы с wiki.
        /// </summary>
        public IPagesCategory Pages { get; }

        /// <summary>
        /// API для работы с приложениями.
        /// </summary>
        public IAppsCategory Apps { get; }

        /// <summary>
        /// API для работы с новостной лентой.
        /// </summary>
        public INewsFeedCategory NewsFeed { get; }

        /// <summary>
        /// API для работы со статистикой.
        /// </summary>
        public IStatsCategory Stats { get; }

        /// <summary>
        /// API для работы с подарками.
        /// </summary>
        public IGiftsCategory Gifts { get; }

        /// <summary>
        /// API для работы с товарами.
        /// </summary>
        public IMarketsCategory Markets { get; }

        /// <summary>
        /// API для работы с Авторизацией.
        /// </summary>
        public IAuthCategory Auth { get; }

        /// <summary>
        /// API для работы с универсальным методом.
        /// </summary>
        public IExecuteCategory Execute { get; }

        /// <summary>
        /// API для работы с опросами. 
        /// </summary>
        public IPollsCategory PollsCategory { get; }

        #endregion

        /// <summary>
        /// Браузер.
        /// </summary>
        public IBrowser Browser { get; set; }

        /// <summary>
        /// Была ли произведена авторизация каким либо образом
        /// </summary>
        public bool IsAuthorized => !string.IsNullOrWhiteSpace(AccessToken);

        /// <summary>
        /// Токен для доступа к методам API
        /// </summary>
        private string AccessToken { get; set; }

        /// <summary>
        /// Токен для доступа к методам API
        /// </summary>
        public string Token => AccessToken;

        /// <summary>
        /// Идентификатор пользователя, от имени которого была проведена авторизация.
        /// Если авторизация не была произведена с использованием метода Authorize(int
        /// то возвращается null.
        /// </summary>
        // ReSharper disable once MemberCanBePrivate.Global
        public long? UserId { get; set; }

        /// <summary>
        /// Максимальное количество попыток распознавания капчи c помощью зарегистрированного обработчика
        /// </summary>
        // ReSharper disable once AutoPropertyCanBeMadeGetOnly.Global
        // ReSharper disable once MemberCanBePrivate.Global
        public int MaxCaptchaRecognitionCount { get; set; }

        /// <summary>
        /// Обработчик распознавания капчи
        /// </summary>
        public ICaptchaSolver CaptchaSolver { get; }

        /// <summary>
        /// Логгер
        /// </summary>
        private readonly ILogger _logger;

        /// <summary>
        /// Язык получаемых данных
        /// </summary>
        private Language? Language { get; set; }

        /// <summary>
        /// Инициализирует новый экземпляр класса VkApi
        /// </summary>
        public VkApi(IServiceCollection serviceCollection = null)
        {
            var container = serviceCollection ?? new ServiceCollection();

            container.RegisterDefaultDependencies();

            IServiceProvider serviceProvider = container.BuildServiceProvider();
            Browser = serviceProvider.GetRequiredService<IBrowser>();
            CaptchaSolver = serviceProvider.GetService<ICaptchaSolver>();
            _logger = serviceProvider.GetService<ILogger>();

            Users = new UsersCategory(this);
            Friends = new FriendsCategory(this);
            Status = new StatusCategory(this);
            Messages = new MessagesCategory(this);
            Groups = new GroupsCategory(this);
            Audio = new AudioCategory(this);
            Wall = new WallCategory(this);
            Board = new BoardCategory(this);
            Database = new DatabaseCategory(this);
            Utils = new UtilsCategory(this);
            Fave = new FaveCategory(this);
            Video = new VideoCategory(this);
            Account = new AccountCategory(this);
            Photo = new PhotoCategory(this);
            Docs = new DocsCategory(this);
            Likes = new LikesCategory(this);
            Pages = new PagesCategory(this);
            Gifts = new GiftsCategory(this);
            Apps = new AppsCategory(this);
            NewsFeed = new NewsFeedCategory(this);
            Stats = new StatsCategory(this);
            Auth = new AuthCategory(this);
            Markets = new MarketsCategory(this);
            Execute = new ExecuteCategory(this);
            PollsCategory = new PollsCategory(this);

            RequestsPerSecond = 3;

            MaxCaptchaRecognitionCount = 5;
            _logger.Debug("VkApi Initialization successfully");
        }

        /// <summary>
        /// Установить язык
        /// </summary>
        /// <param name="language"></param>
        public void SetLanguage(Language language)
        {
            Language = language;
        }

        /// <summary>
        /// Установить язык
        /// </summary>
        public Language? GetLanguage()
        {
            return Language;
        }

        /// <summary>
        /// Авторизация и получение токена
        /// </summary>
        /// <param name="params">Данные авторизации</param>
        public void Authorize(IApiAuthParams @params)
        {
            //подключение браузера через прокси 
            if (@params.Host != null)
            {
                _logger.Debug("Настройка прокси");
                Browser.Proxy = WebProxy.GetProxy(
                    @params.Host,
                    @params.Port,
                    @params.ProxyLogin,
                    @params.ProxyPassword
                );
            }

            //если токен не задан - обычная авторизация
            if (@params.AccessToken == null)
            {
                AuthorizeWithAntiCaptcha(@params);
                // Сбросить после использования
                @params.CaptchaSid = null;
                @params.CaptchaKey = "";
            }
            //если токен задан - авторизация с помощью токена полученного извне
            else
            {
                TokenAuth(@params.AccessToken, @params.UserId, @params.TokenExpireTime);
            }

            _ap = @params;
            _logger.Debug("Авторизация прошла успешно");
        }

        /// <summary>
        /// Авторизация и получение токена в асинхронном режиме
        /// </summary>
        /// <param name="params">Данные авторизации</param>
        public async Task AuthorizeAsync(IApiAuthParams @params)
        {
           await TypeHelper.TryInvokeMethodAsync(() => Authorize(@params));
        }

        /// <summary>
        /// Получает новый AccessToken используя логин, пароль, приложение и настройки указанные при последней авторизации.
        /// </summary>
        /// <param name="code">Делегат двух факторной авторизации. Если не указан - будет взят из параметров (если есть)</param>
        /// <exception cref="AggregateException">
        /// Невозможно обновить токен доступа т.к. последняя авторизация происходила не при помощи логина и пароля
        /// </exception>
        public void RefreshToken(Func<string> code = null)
        {
            if (!string.IsNullOrWhiteSpace(_ap.Login) && !string.IsNullOrWhiteSpace(_ap.Password))
            {
                _ap.TwoFactorAuthorization = _ap.TwoFactorAuthorization ?? code;
                AuthorizeWithAntiCaptcha(_ap);
            }
            else
            {
                const string message =
                    "Невозможно обновить токен доступа т.к. последняя авторизация происходила не при помощи логина и пароля";
                _logger.Error(message);
                throw new AggregateException(message);
            }
        }

        /// <summary>
        /// Получает новый AccessToken использую логин, пароль, приложение и настройки указанные при последней авторизации.
        /// </summary>
        /// <param name="code">Делегат двух факторной авторизации. Если не указан - будет взят из параметров (если есть)</param>
        public async Task RefreshTokenAsync(Func<string> code = null)
        {
            await TypeHelper.TryInvokeMethodAsync(() => RefreshToken(code));
        }

        /// <summary>
        /// Вызвать метод.
        /// </summary>
        /// <param name="methodName">Название метода.</param>
        /// <param name="parameters">Параметры.</param>
        /// <param name="skipAuthorization">Если <c>true</c> то пропустить авторизацию.</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.NoInlining)]
        public VkResponse Call(string methodName, VkParameters parameters, bool skipAuthorization = false)
        {
            var answer = CallBase(methodName, parameters, skipAuthorization);

            var json = JObject.Parse(answer);

            var rawResponse = json["response"];

            return new VkResponse(rawResponse) {RawJson = answer};
        }

        /// <summary>
        /// Вызвать метод.
        /// </summary>
        /// <param name="methodName">Название метода.</param>
        /// <param name="parameters">Параметры.</param>
        /// <param name="skipAuthorization">Если <c>true</c> то пропустить авторизацию.</param>
        /// <returns></returns>
        public async Task<VkResponse> CallAsync(string methodName, VkParameters parameters, bool skipAuthorization)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => Call(methodName, parameters, skipAuthorization));
        }

        /// <summary>
        /// Вызвать метод.
        /// </summary>
        /// <param name="methodName">Название метода.</param>
        /// <param name="parameters">Параметры.</param>
        /// <param name="skipAuthorization">Если <c>true</c> то пропустить авторизацию.</param>
        /// <returns></returns>
        public async Task<T> CallAsync<T>(string methodName, VkParameters parameters, bool skipAuthorization)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => Call<T>(methodName, parameters, skipAuthorization));
        }

        /// <summary>
        /// Вызвать метод.
        /// </summary>
        /// <param name="methodName">Название метода.</param>
        /// <param name="parameters">Параметры.</param>
        /// <param name="skipAuthorization">Если <c>true</c> то пропустить авторизацию.</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.NoInlining)]
        public T Call<T>(string methodName, VkParameters parameters, bool skipAuthorization = false)
        {
            var answer = CallBase(methodName, parameters, skipAuthorization);

            return JsonConvert.DeserializeObject<T>(answer, new VkCollectionJsonConverter());
        }

        

        /// <summary>
        /// Прямой вызов API-метода
        /// </summary>
        /// <param name="methodName">Название метода. Например, "wall.get".</param>
        /// <param name="parameters">Вход. параметры метода.</param>
        /// <param name="skipAuthorization">Флаг, что метод можно вызывать без авторизации.</param>
        /// <exception cref="AccessTokenInvalidException"></exception>
        /// <returns>Ответ сервера в формате JSON.</returns>
        [CanBeNull]
        public string Invoke(string methodName, IDictionary<string, string> parameters, bool skipAuthorization = false)
        {
            if (!skipAuthorization && !IsAuthorized)
            {
                var message = $"Метод '{methodName}' нельзя вызывать без авторизации";
                _logger.Error(message);
                throw new AccessTokenInvalidException(message);
            }

            var url = "";
            var answer = "";

            Action sendRequest = delegate
            {
                url = $"https://api.vk.com/method/{methodName}";
                LastInvokeTime = DateTimeOffset.Now;
                answer = Browser.GetJson(url, parameters);
            };

            // Защита от превышения количества запросов в секунду
            if (RequestsPerSecond > 0 && LastInvokeTime.HasValue)
            {
                if (_expireTimer == null)
                {
                    SetTimer(0);
                }

                lock (_expireTimer)
                {
                    var span = LastInvokeTimeSpan?.TotalMilliseconds;
                    if (span < _minInterval)
                    {
                        var timeout = (int) _minInterval - (int) span;
#if NET40
                        Thread.Sleep(timeout);
#else
                        Task.Delay(timeout).Wait();
#endif
                    }

                    sendRequest();
                }
            }
            else if (skipAuthorization)
            {
                sendRequest();
            }

#if DEBUG && !UNIT_TEST
            _logger.Trace(Utilities.PreetyPrintApiUrl(url));
            _logger.Trace(Utilities.PreetyPrintApiUrl(url));
#if UWP
            Debug.WriteLine(Utilities.PreetyPrintApiUrl(url));
            Debug.WriteLine(Utilities.PreetyPrintJson(answer));
#else
            Trace.WriteLine(Utilities.PreetyPrintApiUrl(url));
            Trace.WriteLine(Utilities.PreetyPrintJson(answer));
#endif
#endif
            VkErrors.IfErrorThrowException(answer);

            return answer;
        }

        /// <summary>
        /// Прямой вызов API-метода в асинхронном режиме
        /// </summary>
        /// <param name="methodName">Название метода. Например, "wall.get".</param>
        /// <param name="parameters">Вход. параметры метода.</param>
        /// <param name="skipAuthorization">Флаг, что метод можно вызывать без авторизации.</param>
        /// <returns>Ответ сервера в формате JSON.</returns>
        [CanBeNull]
        public async Task<string> InvokeAsync(string methodName, IDictionary<string, string> parameters,
            bool skipAuthorization = false)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => Invoke(methodName, parameters, skipAuthorization));
        }

        /// <summary>
        /// Освобождения неуправляемых ресурсов.
        /// </summary>
        public void Dispose()
        {
            _expireTimer.Dispose();
        }

        /// <summary>
        /// Обход ошибки валидации: https://vk.com/dev/need_validation
        /// </summary>
        /// <param name="validateUrl">Адрес, на который нужно перейти для валидации</param>
        /// <param name="phoneNumber">Номер телефона, который нужно ввести на странице валидации</param>
        public void Validate(string validateUrl, string phoneNumber)
        {
            StopTimer();

            LastInvokeTime = DateTimeOffset.Now;
            var authorization = Browser.Validate(validateUrl, phoneNumber);
            if (!authorization.IsAuthorized)
            {
                const string message = "Не удалось автоматически пройти валидацию!";
                _logger.Error(message);
                throw new NeedValidationException(message, validateUrl);
            }

            SetTokenProperties(authorization);
        }

        #region private

        /// <summary>
        /// Базовое обращение к vk.com
        /// </summary>
        /// <param name="methodName">Наименование метода</param>
        /// <param name="parameters">Параметры запроса</param>
        /// <param name="skipAuthorization">Пропустить авторизацию</param>
        /// <returns>Ответ от vk.com в формате json</returns>
        /// <exception cref="CaptchaNeededException">Требуется ввести капчу</exception>
        private string CallBase(string methodName, VkParameters parameters, bool skipAuthorization)
        {
            if (!parameters.ContainsKey("v"))
            {
                parameters.Add("v", VkApiVersion);
            }
            
            if (!parameters.ContainsKey("access_token"))
            {
                parameters.Add("access_token", AccessToken);
            }

            if (!parameters.ContainsKey("lang") && Language.HasValue)
            {
                parameters.Add("lang", Language);
            }

            _logger.Debug(
                $"Вызов метода {methodName}, с параметрами {string.Join(",", parameters.Select(x => $"{x.Key}={x.Value}"))}");
            string answer;

            if (CaptchaSolver == null)
            {
                answer = Invoke(methodName, parameters, skipAuthorization);
            }
            else
            {
                answer = CaptchaHandler((sid, key) =>
                {
                    parameters.Add("captcha_sid", sid);
                    parameters.Add("captcha_key", key);
                    return Invoke(methodName, parameters, skipAuthorization);
                });
            }

            return answer;
        }

        /// <summary>
        /// Авторизация и получение токена
        /// </summary>
        /// <param name="authParams">Параметры авторизации</param>
        /// <exception cref="VkApiAuthorizationException"></exception>
        private void AuthorizeWithAntiCaptcha(IApiAuthParams authParams)
        {
            _logger.Debug("Старт авторизации");
            if (CaptchaSolver == null)
            {
                BaseAuthorize(authParams);
            }
            else
            {
                CaptchaHandler((sid, key) =>
                {
                    _logger.Debug("Авторизация с использование капчи.");
                    authParams.CaptchaSid = sid;
                    authParams.CaptchaKey = key;
                    BaseAuthorize(authParams);
                    return true;
                });
            }
        }

        /// <summary>
        /// Обработка капчи
        /// </summary>
        /// <param name="action">Действие</param>
        /// <typeparam name="T">Тип результата</typeparam>
        /// <returns>Результат действия</returns>
        /// <exception cref="CaptchaNeededException">Требуется обработка капчи.</exception>
        private T CaptchaHandler<T>(Func<long?, string, T> action)
        {
            var numberOfRemainingAttemptsToSolveCaptcha = MaxCaptchaRecognitionCount;
            var numberOfRemainingAttemptsToAuthorize = MaxCaptchaRecognitionCount + 1;
            long? captchaSidTemp = null;
            string captchaKeyTemp = null;
            var callCompleted = false;
            var result = default(T);
            do
            {
                try
                {
                    result = action.Invoke(captchaSidTemp, captchaKeyTemp);
                    numberOfRemainingAttemptsToAuthorize--;
                    callCompleted = true;
                }
                catch (CaptchaNeededException captchaNeededException)
                {
                    RepeatSolveCaptcha(ref numberOfRemainingAttemptsToSolveCaptcha, captchaNeededException,
                        ref captchaSidTemp, ref captchaKeyTemp);
                }
            } while (numberOfRemainingAttemptsToAuthorize > 0 && !callCompleted);

            // Повторно выбрасываем исключение, если капча ни разу не была распознана верно
            if (callCompleted || !captchaSidTemp.HasValue)
            {
                return result;
            }

            _logger.Error("Капча ни разу не была распознана верно");
            throw new CaptchaNeededException(captchaSidTemp.Value, captchaKeyTemp);
        }

        /// <summary>
        /// Авторизация через установку токена
        /// </summary>
        /// <param name="accessToken">Токен</param>
        /// <param name="userId">Идентификатор пользователя</param>
        /// <param name="expireTime">Время истечения токена</param>
        /// <exception cref="ArgumentNullException"></exception>
        private void TokenAuth(string accessToken, long? userId, int expireTime)
        {
            if (string.IsNullOrWhiteSpace(accessToken))
            {
                _logger.Error("Авторизация через токен. Токен не задан.");
                throw new ArgumentNullException(accessToken);
            }

            _logger.Debug("Авторизация через токен");
            StopTimer();

            LastInvokeTime = DateTimeOffset.Now;
            SetApiPropertiesAfterAuth(expireTime, accessToken, userId);
            _ap = new ApiAuthParams();
        }
        
        /// <summary>
        /// Sets the token properties.
        /// </summary>
        /// <param name="authorization">The authorization.</param>
        private void SetTokenProperties(VkAuthorization authorization)
        {
            _logger.Debug("Установка свойств токена");
            var expireTime = (Convert.ToInt32(authorization.ExpiresIn) - 10) * 1000;
            SetApiPropertiesAfterAuth(expireTime, authorization.AccessToken, authorization.UserId);
        }

        /// <summary>
        /// Установить свойства api после авторизации
        /// </summary>
        /// <param name="expireTime"></param>
        /// <param name="accessToken"></param>
        /// <param name="userId"></param>
        private void SetApiPropertiesAfterAuth(int expireTime, string accessToken, long? userId)
        {
            SetTimer(expireTime);
            AccessToken = accessToken;
            UserId = userId;
        }

        /// <summary>
        /// Повторная обработка капчи
        /// </summary>
        /// <param name="numberOfRemainingAttemptsToSolveCaptcha"></param>
        /// <param name="captchaNeededException"></param>
        /// <param name="captchaSidTemp"></param>
        /// <param name="captchaKeyTemp"></param>
        private void RepeatSolveCaptcha(ref int numberOfRemainingAttemptsToSolveCaptcha,
            CaptchaNeededException captchaNeededException, ref long? captchaSidTemp, ref string captchaKeyTemp)
        {
            _logger.Warn("Повторная обработка капчи");
            if (numberOfRemainingAttemptsToSolveCaptcha < MaxCaptchaRecognitionCount)
            {
                CaptchaSolver?.CaptchaIsFalse();
            }

            if (numberOfRemainingAttemptsToSolveCaptcha <= 0)
            {
                return;
            }

            captchaSidTemp = captchaNeededException.Sid;
            captchaKeyTemp = CaptchaSolver?.Solve(captchaNeededException.Img?.AbsoluteUri);
            numberOfRemainingAttemptsToSolveCaptcha--;
        }

        /// <summary>
        /// Установить значение таймера
        /// </summary>
        /// <param name="expireTime">Значение таймера</param>
        private void SetTimer(int expireTime)
        {
            _expireTimer = new Timer(
                AlertExpires,
                null,
                expireTime > 0 ? expireTime : Timeout.Infinite,
                Timeout.Infinite
            );
        }

        /// <summary>
        /// Прекращает работу таймера оповещения
        /// </summary>
        private void StopTimer()
        {
            _expireTimer?.Dispose();
        }

        /// <summary>
        /// Создает событие оповещения об окончании времени токена
        /// </summary>
        /// <param name="state"></param>
        private void AlertExpires(object state)
        {
            OnTokenExpires?.Invoke(this);
        }

        /// <summary>
        /// Авторизация и получение токена
        /// </summary>
        /// <param name="authParams">Параметры авторизации</param>
        /// <exception cref="VkApiAuthorizationException"></exception>
        private void BaseAuthorize(IApiAuthParams authParams)
        {
            StopTimer();

            LastInvokeTime = DateTimeOffset.Now;
            var authorization = Browser.Authorize(authParams);
            if (!authorization.IsAuthorized)
            {
                var message = $"Invalid authorization with {authParams.Login} - {authParams.Password}";
                _logger.Error(message);
                throw new VkApiAuthorizationException(message, authParams.Login, authParams.Password);
            }
            _logger.Debug("Авторизация прошла успешно");
            SetTokenProperties(authorization);
        }
        
        #endregion
    }
}