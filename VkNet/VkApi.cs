using System.Threading;
using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using NLog;
using VkNet.Abstractions;
using VkNet.Abstractions.Utils;
using VkNet.Categories;
using VkNet.Enums;
using VkNet.Exception;
using VkNet.Model;
using VkNet.Utils;
using VkNet.Utils.AntiCaptcha;
using VkNet.Utils.JsonConverter;

// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable EventNeverSubscribedTo.Global

namespace VkNet
{
    /// <summary>
    /// Служит для оповещения об истечении токена
    /// </summary>
    /// <param name="sender">
    /// Экземпляр API у которого истекло время токена
    /// </param>
    public delegate void VkApiDelegate(VkApi sender);

    /// <inheritdoc />
    /// <summary>
    /// API для работы с ВКонтакте.
    /// Выступает в качестве фабрики для различных категорий API (например, для работы с пользователями, группами и т.п.)
    /// </summary>
    public class VkApi : IVkApi
    {
        /// <summary>
        /// Версия API vk.com.
        /// </summary>
        public const string VkApiVersion = "5.74";

        /// <summary>
        /// Параметры авторизации.
        /// </summary>
        private IApiAuthParams _ap;

        /// <summary>
        /// Таймер.
        /// </summary>
        private Timer _expireTimer;

        private IRestClient _client;

        /// <summary>
        /// The expire timer lock
        /// </summary>
        private readonly object _expireTimerLock = new object();

        #region Requests limit stuff

        /// <summary>
        /// Запросов в секунду.
        /// </summary>
        private float _requestsPerSecond;

        /// <summary>
        /// Минимальное время, которое должно пройти между запросами чтобы не превысить кол-во запросов в секунду.
        /// </summary>
        private float _minInterval;

        /// <inheritdoc />
        public DateTimeOffset? LastInvokeTime { get; private set; }

        /// <inheritdoc />
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

        /// <inheritdoc />
        public float RequestsPerSecond
        {
            get => _requestsPerSecond;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(@"Value must be positive", nameof(value));
                }

                _requestsPerSecond = value;
                if (_requestsPerSecond <= 0)
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

        /// <inheritdoc />
        public event VkApiDelegate OnTokenExpires;

        #region Categories Definition

        /// <inheritdoc />
        public IUsersCategory Users { get; private set; }

        /// <inheritdoc />
        public IFriendsCategory Friends { get; private set; }

        /// <inheritdoc />
        public IStatusCategory Status { get; private set; }

        /// <inheritdoc />
        public IMessagesCategory Messages { get; private set; }

        /// <inheritdoc />
        public IGroupsCategory Groups { get; private set; }

        /// <inheritdoc />
        public AudioCategory Audio { get; private set; }

        /// <inheritdoc />
        public IDatabaseCategory Database { get; private set; }

        /// <inheritdoc />
        public IUtilsCategory Utils { get; private set; }

        /// <inheritdoc />
        public IWallCategory Wall { get; private set; }

        /// <inheritdoc />
        public IBoardCategory Board { get; private set; }

        /// <inheritdoc />
        public IFaveCategory Fave { get; private set; }

        /// <inheritdoc />
        public IVideoCategory Video { get; private set; }

        /// <inheritdoc />
        public IAccountCategory Account { get; private set; }

        /// <inheritdoc />
        public IPhotoCategory Photo { get; private set; }

        /// <inheritdoc />
        public IDocsCategory Docs { get; private set; }

        /// <inheritdoc />
        public ILikesCategory Likes { get; private set; }

        /// <inheritdoc />
        public IPagesCategory Pages { get; private set; }

        /// <inheritdoc />
        public IAppsCategory Apps { get; private set; }

        /// <inheritdoc />
        public INewsFeedCategory NewsFeed { get; private set; }

        /// <inheritdoc />
        public IStatsCategory Stats { get; private set; }

        /// <inheritdoc />
        public IGiftsCategory Gifts { get; private set; }

        /// <inheritdoc />
        public IMarketsCategory Markets { get; private set; }

        /// <inheritdoc />
        public IAuthCategory Auth { get; private set; }

        /// <inheritdoc />
        public IExecuteCategory Execute { get; private set; }

        /// <inheritdoc />
        public IPollsCategory PollsCategory { get; private set; }

        /// <inheritdoc />
        public ISearchCategory Search { get; private set; }

        #endregion

        /// <inheritdoc />
        public IBrowser Browser { get; set; }

        /// <inheritdoc />
        public bool IsAuthorized => !string.IsNullOrWhiteSpace(AccessToken);

        /// <summary>
        /// Токен для доступа к методам API
        /// </summary>
        private string AccessToken { get; set; }

        /// <inheritdoc />
        public string Token => AccessToken;

        /// <inheritdoc />
        public long? UserId { get; set; }

        /// <inheritdoc />
        public int MaxCaptchaRecognitionCount { get; set; }

        /// <inheritdoc />
        public ICaptchaSolver CaptchaSolver { get; set; }

        /// <summary>
        /// Логгер
        /// </summary>
        private ILogger _logger;

        /// <summary>
        /// Язык получаемых данных
        /// </summary>
        private Language? Language { get; set; }

        /// <inheritdoc />
        public VkApi(ILogger logger, ICaptchaSolver captchaSolver = null, IBrowser browser = null)
        {
            var container = new ServiceCollection();

            if (logger != null)
            {
                container.TryAddSingleton(logger);
            }

            if (captchaSolver != null)
            {
                container.TryAddSingleton(captchaSolver);
            }

            if (browser != null)
            {
                container.TryAddSingleton(browser);
            }

            container.RegisterDefaultDependencies();

            IServiceProvider serviceProvider = container.BuildServiceProvider();

            Initialization(serviceProvider);
        }

        /// <inheritdoc />
        public VkApi(IServiceCollection serviceCollection = null)
        {
            var container = serviceCollection ?? new ServiceCollection();

            container.RegisterDefaultDependencies();

            IServiceProvider serviceProvider = container.BuildServiceProvider();

            Initialization(serviceProvider);
        }

        /// <inheritdoc />
        public void SetLanguage(Language language)
        {
            Language = language;
        }

        /// <inheritdoc />
        public Language? GetLanguage()
        {
            return Language;
        }

        /// <inheritdoc />
        public void Authorize(IApiAuthParams @params)
        {
            //подключение браузера через прокси 
            if (@params.Host != null)
            {
                _logger?.Debug("Настройка прокси");
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
            _logger?.Debug("Авторизация прошла успешно");
        }

        /// <inheritdoc />
        public async Task AuthorizeAsync(IApiAuthParams @params)
        {
            await TypeHelper.TryInvokeMethodAsync(() => Authorize(@params));
        }

        /// <inheritdoc />
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
                _logger?.Error(message);
                throw new AggregateException(message);
            }
        }

        /// <inheritdoc />
        public async Task RefreshTokenAsync(Func<string> code = null)
        {
            await TypeHelper.TryInvokeMethodAsync(() => RefreshToken(code));
        }

        /// <inheritdoc />
        [MethodImpl(MethodImplOptions.NoInlining)]
        public VkResponse Call(string methodName, VkParameters parameters, bool skipAuthorization = false)
        {
            var answer = CallBase(methodName, parameters, skipAuthorization);

            var json = JObject.Parse(answer);

            var rawResponse = json["response"];

            return new VkResponse(rawResponse) {RawJson = answer};
        }

        /// <inheritdoc />
        public async Task<VkResponse> CallAsync(string methodName, VkParameters parameters,
            bool skipAuthorization = false)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => Call(methodName, parameters, skipAuthorization));
        }

        /// <inheritdoc />
        public async Task<T> CallAsync<T>(string methodName, VkParameters parameters, bool skipAuthorization = false)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => Call<T>(methodName, parameters, skipAuthorization));
        }

        /// <inheritdoc />
        [MethodImpl(MethodImplOptions.NoInlining)]
        public T Call<T>(string methodName, VkParameters parameters, bool skipAuthorization = false)
        {
            var answer = CallBase(methodName, parameters, skipAuthorization);

            var settings = new JsonSerializerSettings
            {
                Converters = new List<JsonConverter>
                {
                    new VkCollectionJsonConverter(),
                    new VkDefaultJsonConverter(),
                    new UnixDateTimeConverter(),
                    new AttachmentJsonConverter()
                }
            };

            return JsonConvert.DeserializeObject<T>(answer, settings);
        }

        /// <inheritdoc />
        [CanBeNull]
        public string Invoke(string methodName, IDictionary<string, string> parameters, bool skipAuthorization = false)
        {
            if (!skipAuthorization && !IsAuthorized)
            {
                var message = $"Метод '{methodName}' нельзя вызывать без авторизации";
                _logger?.Error(message);
                throw new AccessTokenInvalidException(message);
            }

            var url = "";
            var answer = "";

            void SendRequest()
            {
                url = $"https://api.vk.com/method/{methodName}";
                LastInvokeTime = DateTimeOffset.Now;
                answer = _client.PostAsync(new Uri(url), parameters).Result.Value;
            }

            // Защита от превышения количества запросов в секунду
            if (RequestsPerSecond > 0 && LastInvokeTime.HasValue)
            {
                if (_expireTimer == null)
                {
                    SetTimer(0);
                }

                lock (_expireTimerLock)
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

                    SendRequest();
                }
            }
            else if (skipAuthorization)
            {
                SendRequest();
            }

            _logger?.Trace($"Uri = \"{url}\"");
            _logger?.Trace($"Json ={Environment.NewLine}{Utilities.PreetyPrintJson(answer)}");

            VkErrors.IfErrorThrowException(answer);

            return answer;
        }

        /// <inheritdoc />
        [CanBeNull]
        public async Task<string> InvokeAsync(string methodName, IDictionary<string, string> parameters,
            bool skipAuthorization = false)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => Invoke(methodName, parameters, skipAuthorization));
        }

        /// <inheritdoc cref="IDisposable" />
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected void Dispose(bool disposing)
        {
            StopTimer();
        }

        /// <inheritdoc />
        public void Validate(string validateUrl, string phoneNumber)
        {
            StopTimer();

            LastInvokeTime = DateTimeOffset.Now;
            var authorization = Browser.Validate(validateUrl, phoneNumber);
            if (!authorization.IsAuthorized)
            {
                const string message = "Не удалось автоматически пройти валидацию!";
                _logger?.Error(message);
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

            _logger?.Debug(
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
            _logger?.Debug("Старт авторизации");
            if (CaptchaSolver == null)
            {
                BaseAuthorize(authParams);
            }
            else
            {
                CaptchaHandler((sid, key) =>
                {
                    _logger?.Debug("Авторизация с использование капчи.");
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

            _logger?.Error("Капча ни разу не была распознана верно");
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
                _logger?.Error("Авторизация через токен. Токен не задан.");
                throw new ArgumentNullException(accessToken);
            }

            _logger?.Debug("Авторизация через токен");
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
            _logger?.Debug("Установка свойств токена");
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
            _logger?.Warn("Повторная обработка капчи");
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
                _logger?.Error(message);
                throw new VkApiAuthorizationException(message, authParams.Login, authParams.Password);
            }

            SetTokenProperties(authorization);
        }

        private void Initialization(IServiceProvider serviceProvider)
        {
            Browser = serviceProvider.GetRequiredService<IBrowser>();
            CaptchaSolver = serviceProvider.GetService<ICaptchaSolver>();
            _logger = serviceProvider.GetService<ILogger>();
            _client = serviceProvider.GetRequiredService<IRestClient>();
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
            Search = new SearchCategory(this);

            RequestsPerSecond = 3;

            MaxCaptchaRecognitionCount = 5;
            _logger?.Debug("VkApi Initialization successfully");
        }

        #endregion
    }
}