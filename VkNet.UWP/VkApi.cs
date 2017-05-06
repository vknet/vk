using System.Threading;
using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using VkNet.Categories;
using VkNet.Exception;
using VkNet.Utils;
using VkNet.Utils.AntiCaptcha;
using VkNet.Enums.Filters;

namespace VkNet
{
	/// <summary>
	/// Служит для оповещения об истечении токена
	/// </summary>
	/// <param name="sender">Экземпляр API у которого истекло время токена</param>
	public delegate void VkApiDelegate(VkApi sender);

	/// <summary>
	/// API для работы с ВКонтакте. Выступает в качестве фабрики для различных категорий API (например, для работы с пользователями,
	/// группами и т.п.).
	/// </summary>
	public class VkApi : IVkApi
    {
		/// <summary>
		/// Версия API vk.com.
		/// </summary>
		public const string VkApiVersion = "5.64";

		/// <summary>
		/// Параметры авторизации.
		/// </summary>
		private AuthParams _ap;
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
		public DateTimeOffset? LastInvokeTime
		{ get; private set; }
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
		/// <summary>
		/// Ограничение на кол-во запросов в секунду
		/// </summary>
		public float RequestsPerSecond
		{
			get { return _requestsPerSecond; }
			set
			{
			    if (value < 0)
                {
                    throw new ArgumentException(@"Value must be positive", nameof(RequestsPerSecond));
                }
                _requestsPerSecond = value;
                if (_requestsPerSecond > 0)
				{
					_minInterval = (int)(1000 / _requestsPerSecond) + 1;
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
		public UsersCategory Users
		{ get; private set; }
        /// <summary>
        /// API для работы с друзьями.
        /// </summary>
        [Obsolete("Свойство устарело, используйте более общее IFriendsCategory IVkApi.Friends")]
        public FriendsCategory Friends
		{ get; private set; }

        /// <summary>
        /// API для работы с друзьями.
        /// </summary>
        IFriendsCategory IVkApi.Friends => Friends;

        /// <summary>
        /// API для работы со статусом пользователя или сообщества.
        /// </summary>
        public StatusCategory Status
		{ get; private set; }
        /// <summary>
        /// API для работы с сообщениями.
        /// </summary>
        [Obsolete("Свойство устарело, используйте более общее IMessagesCategory IVkApi.Messages")]
        public MessagesCategory Messages
		{ get; private set; }

        /// <summary>
        /// API для работы с сообщениями.
        /// </summary>
        IMessagesCategory IVkApi.Messages => Messages;

        /// <summary>
        /// API для работы с .
        /// </summary>
        [Obsolete("Свойство устарело, используйте более общее IGroupsCategory IVkApi.Groups")]
        public GroupsCategory Groups
		{ get; private set; }

        /// <summary>
        /// API для работы с .
        /// </summary>
        IGroupsCategory IVkApi.Groups => Groups;

        /// <summary>
        /// API для работы с аудио записями.
        /// </summary>
        [Obsolete("Свойство устарело, используйте более общее IAudioCategory IVkApi.Audio")]
        public AudioCategory Audio
		{ get; private set; }

        /// <summary>
        /// API для работы с аудио записями.
        /// </summary>
        IAudioCategory IVkApi.Audio => Audio;

        /// <summary>
        /// API для получения справочной информации (страны, города, школы, учебные заведения и т.п.).
        /// </summary>
        [Obsolete("Свойство устарело, используйте более общее IDatabaseCategory IVkApi.Database")]
        public DatabaseCategory Database
		{ get; private set; }

        /// <summary>
        /// API для получения справочной информации (страны, города, школы, учебные заведения и т.п.).
        /// </summary>
        IDatabaseCategory IVkApi.Database => Database;

		/// <summary>
		/// API для работы со служебными методами.
		/// </summary>
		public UtilsCategory Utils
		{ get; private set; }
		/// <summary>
		/// API для работы со стеной пользователя.
		/// </summary>
		public WallCategory Wall
		{ get; private set; }

        /// <summary>
        /// API для работы со темами групп.
        /// </summary>
        [Obsolete("Свойство устарело, используйте более общее IBoardCategory IVkApi.Board")]
        public BoardCategory Board
		{ get; private set; }

        /// <summary>
        /// API для работы со темами групп.
        /// </summary>
        IBoardCategory IVkApi.Board => Board;

        /// <summary>
        /// API для работы с закладками.
        /// </summary>
        [Obsolete("Свойство устарело, используйте более общее IFaveCategory IVkApi.Fave")]
        public FaveCategory Fave
		{ get; private set; }

        /// <summary>
        /// API для работы с закладками.
        /// </summary>
        IFaveCategory IVkApi.Fave => Fave;

        /// <summary>
        /// API для работы с видео файлами.
        /// </summary>
        public VideoCategory Video
		{ get; private set; }
        /// <summary>
        /// API для работы с аккаунтом пользователя.
        /// </summary>
        [Obsolete("Свойство устарело, используйте более общее IAccountCategory IVkApi.Account")]
        public AccountCategory Account
		{ get; private set; }
        /// <summary>
		/// API для работы с аккаунтом пользователя.
		/// </summary>
		IAccountCategory IVkApi.Account => Account;

        /// <summary>
        /// API для работы с фотографиями
        /// </summary>
        [Obsolete("Свойство устарело, используйте более общее IPhotoCategory IVkApi.Photo")]
        public PhotoCategory Photo
		{ get; private set; }

        /// <summary>
        /// API для работы с фотографиями
        /// </summary>
        IPhotoCategory IVkApi.Photo => Photo;

        /// <summary>
        /// API для работы с документами
        /// </summary>
        [Obsolete("Свойство устарело, используйте более общее IDocsCategory IVkApi.Docs")]
        public DocsCategory Docs
		{ get; private set; }

        /// <summary>
        /// API для работы с документами
        /// </summary>
        IDocsCategory IVkApi.Docs => Docs;

        /// <summary>
        /// API для работы с лайками
        /// </summary>
        [Obsolete("Свойство устарело, используйте более общее ILikesCategory IVkApi.Likes")]
        public LikesCategory Likes
		{ get; private set; }

        /// <summary>
        /// API для работы с лайками
        /// </summary>
        ILikesCategory IVkApi.Likes => Likes;

        /// <summary>
        /// API для работы с wiki.
        /// </summary>
        [Obsolete("Свойство устарело, используйте более общее IPagesCategory IVkApi.Pages")]
        public PagesCategory Pages
		{ get; set; }

        /// <summary>
        /// API для работы с wiki.
        /// </summary>
        IPagesCategory IVkApi.Pages
        { get; set; }

        /// <summary>
        /// API для работы с приложениями.
        /// </summary>
        [Obsolete("Свойство устарело, используйте более общее IAppsCategory IVkApi.Apps")]
		public AppsCategory Apps
		{ get; set; }

        /// <summary>
        /// API для работы с приложениями.
        /// </summary>
        IAppsCategory IVkApi.Apps
        { get; set; }

        /// <summary>
        /// API для работы с новостной лентой.
        /// </summary>
        [Obsolete("Свойство устарело, используйте более общее INewsFeedCategory IVkApi.NewsFeed")]
        public NewsFeedCategory NewsFeed { get; set; }

        /// <summary>
        /// API для работы с новостной лентой.
        /// </summary>
        INewsFeedCategory IVkApi.NewsFeed
        { get; set; }

        /// <summary>
        /// API для работы со статистикой.
        /// </summary>
        public StatsCategory Stats { get; set; }

        /// <summary>
        /// API для работы с подарками.
        /// </summary>
        [Obsolete("Свойство устарело, используйте более общее IGiftsCategory IVkApi.Gifts")]
        public GiftsCategory Gifts
		{ get; set; }

        /// <summary>
		/// API для работы с подарками.
		/// </summary>
		IGiftsCategory IVkApi.Gifts
        { get; set; }

        /// <summary>
        /// API для работы с товарами.
        /// </summary>
        [Obsolete("Свойство устарело, используйте более общее IMarketsCategory IVkApi.Markets")]
        public MarketsCategory Markets { get; set; }

        /// <summary>
        /// API для работы с товарами.
        /// </summary>
        IMarketsCategory IVkApi.Markets
        { get; set; }

        /// <summary>
        /// API для работы с Авторизацией.
        /// </summary>
        [Obsolete("Свойство устарело, используйте более общее IAuthCategory IVkApi.Auth")]
        public AuthCategory Auth { get; set; }

        /// <summary>
        /// API для работы с Авторизацией.
        /// </summary>
        IAuthCategory IVkApi.Auth { get; set; }

        /// <summary>
        /// API для работы с универсальным методом.
        /// </summary>
        [Obsolete("Свойство устарело, используйте более общее IExecuteCategory IVkApi.Execute")]
        public ExecuteCategory Execute { get; private set; }

        /// <summary>
        /// API для работы с универсальным методом.
        /// </summary>
        IExecuteCategory IVkApi.Execute => Execute;

        /// <summary>
		/// API для работы с опросами. 
		/// </summary>
		[Obsolete("Свойство устарело, используйте более общее IPollsCategory IVkApi.PollsCategory")]
        public PollsCategory PollsCategory { get; private set; }

        /// <summary>
        /// API для работы с опросами. 
        /// </summary>
        IPollsCategory IVkApi.PollsCategory => PollsCategory;
        #endregion

        /// <summary>
        /// Браузер.
        /// </summary>
        public IBrowser Browser
		{ get; set; }

		/// <summary>
		/// Была ли произведена авторизация каким либо образом
		/// </summary>
		public bool IsAuthorized => !string.IsNullOrWhiteSpace(AccessToken);

		/// <summary>
		/// Токен для доступа к методам API
		/// </summary>
		private string AccessToken
		{ get; set; }

		/// <summary>
		/// Токен для доступа к методам API
		/// </summary>
		public string Token => AccessToken;

		/// <summary>
		/// Идентификатор пользователя, от имени которого была проведена авторизация.
		/// Если авторизация не была произведена с использованием метода Authorize(int
		/// то возвращается null.
		/// </summary>
		public long? UserId
		{ get; set; }

		/// <summary>
		/// Максимальное количество попыток распознавания капчи c помощью зарегистрированного обработчика
		/// </summary>
		public int MaxCaptchaRecognitionCount { get; set; }

		/// <summary>
		/// Обработчик распознавания капчи
		/// </summary>
		private readonly ICaptchaSolver _captchaSolver;

		/// <summary>
		/// Инициализирует новый экземпляр класса VkApi
		/// </summary>
		public VkApi(ICaptchaSolver captchaSolver = null)
		{
			Browser = new Browser();

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
            ((IVkApi)this).Pages = Pages;
            Gifts = new GiftsCategory(this);
            ((IVkApi)this).Gifts = Gifts;
            Apps = new AppsCategory(this);
		    ((IVkApi) this).Apps = Apps;
			NewsFeed = new NewsFeedCategory(this);
            ((IVkApi)this).NewsFeed = NewsFeed;
            Stats = new StatsCategory(this);
			Auth = new AuthCategory(this);
            ((IVkApi)this).Auth = Auth;
            Markets = new MarketsCategory(this);
            ((IVkApi)this).Markets = Markets;
            Execute = new ExecuteCategory(this);
            PollsCategory = new PollsCategory(this);

			RequestsPerSecond = 3;

			MaxCaptchaRecognitionCount = 5;
			_captchaSolver = captchaSolver;
		}

	    /// <summary>
	    /// Авторизация и получение токена
	    /// </summary>
	    /// <param name="params">Данные авторизации</param>
	    public void Authorize(ApiAuthParams @params)
	    {
            Authorize(AuthParams.GetAuthParams(@params));
	    }

	    /// <summary>
        /// Авторизация и получение токена
        /// </summary>
        /// <param name="params">Данные авторизации</param>
        public void Authorize(AuthParams @params)
		{
            //подключение браузера через прокси 
            if (@params.Host != null)
            {
                Browser.Proxy = WebProxy.GetProxy(@params.Host, @params.Port, @params.ProxyLogin, @params.ProxyPassword);
            }

            //если токен не задан - обычная авторизация
            if (@params.AccessToken == null)
            {
                AuthorizeWithAntiCaptcha(
                    @params.ApplicationId,
                    @params.Login,
                    @params.Password,
                    @params.Settings,
                    @params.TwoFactorAuthorization,
                    @params.CaptchaSid,
                    @params.CaptchaKey
                    );
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
		}
		/// <summary>
		/// Авторизация и получение токена
		/// </summary>
		/// <param name="appId">Идентификатор приложения</param>
		/// <param name="emailOrPhone">Email или телефон</param>
		/// <param name="password">Пароль</param>
		/// <param name="settings">Права доступа для приложения</param>
		/// <param name="code">Делегат получения кода для двух факторной авторизации</param>
		/// <param name="captchaSid">Идентификатор капчи</param>
		/// <param name="captchaKey">Текст капчи</param>
		[Obsolete("Устаревший метод, будет удален. Используйте метод Authorize(ApiAuthParams @params)")]
		public void Authorize(int appId, string emailOrPhone, string password, Settings settings, Func<string> code = null, long? captchaSid = null, string captchaKey = null)
		{
			VkErrors.ThrowIfNumberIsNegative(() => appId);
			Authorize(new ApiAuthParams
			{
				ApplicationId = Convert.ToUInt64(appId),
				Login = emailOrPhone,
				Password = password,
				Settings = settings,
				TwoFactorAuthorization = code,
				CaptchaSid = captchaSid,
				CaptchaKey = captchaKey
			});
		}
        /// <summary>
		/// Авторизация и получение токена в асинхронном режиме
		/// </summary>
		/// <param name="params">Данные авторизации</param>
		public Task AuthorizeAsync(ApiAuthParams @params)
        {
            return AuthorizeAsync(AuthParams.GetAuthParams(@params));
        }
        /// <summary>
        /// Авторизация и получение токена в асинхронном режиме
        /// </summary>
        /// <param name="params">Данные авторизации</param>
        public Task AuthorizeAsync(AuthParams @params)
		{
			var rTask = new Task(() => Authorize(@params));
			rTask.Start();
			return rTask;
		}

        /// <summary>
        /// Выполняет авторизацию с помощью маркера доступа (access token), полученного извне.
        /// </summary>
        /// <param name="accessToken">Маркер доступа, полученный извне.</param>
        /// <param name="userId">Идентификатор пользователя, установившего приложение (необязательный параметр).</param>
        /// <param name="expireTime">Время, в течении которого действует токен доступа (0 - бесконечно).</param>
        [Obsolete("Устаревший метод, будет удален. Используйте метод Authorize(ApiAuthParams @params)")]
        public void Authorize(string accessToken, long? userId = null, int expireTime = 0)
        {
	        TokenAuth(accessToken, userId, expireTime);
        }

		private void TokenAuth(string accessToken, long? userId, int expireTime)
		{
			if (string.IsNullOrWhiteSpace(accessToken))
			{
				throw new ArgumentNullException(accessToken);
			}

			StopTimer();

			LastInvokeTime = DateTimeOffset.Now;
			SetTimer(expireTime);
			AccessToken = accessToken;
			UserId = userId;
			_ap = new AuthParams();
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
				AuthorizeWithAntiCaptcha(
					_ap.ApplicationId,
					_ap.Login,
					_ap.Password,
					_ap.Settings,
					code ?? _ap.TwoFactorAuthorization
					);
			}
			else
			{
				throw new AggregateException(
					"Невозможно обновить токен доступа т.к. последняя авторизация происходила не при помощи логина и пароля");
			}
		}
		/// <summary>
		/// Получает новый AccessToken использую логин, пароль, приложение и настройки указанные при последней авторизации.
		/// </summary>
		/// <param name="code">Делегат двух факторной авторизации. Если не указан - будет взят из параметров (если есть)</param>
		public Task RefreshTokenAsync(Func<string> code = null)
		{
			var result = new Task(() => RefreshToken(code));
			result.Start();
			return result;
		}

        #region Private & public Methods
        /// <summary>
        /// Авторизация и получение токена
        /// </summary>
        /// <param name="appId">Идентификатор приложения</param>
        /// <param name="emailOrPhone">Email или телефон</param>
        /// <param name="password">Пароль</param>
        /// <param name="code">Делегат получения кода для двух факторной авторизации</param>
        /// <param name="captchaSid">Идентификатор капчи</param>
        /// <param name="captchaKey">Текст капчи</param>
        /// <param name="settings">Права доступа для приложения</param>
        /// <exception cref="VkApiAuthorizationException"></exception>
        private void Authorize(ulong appId, string emailOrPhone, string password, Settings settings, Func<string> code, long? captchaSid = null, string captchaKey = null)
		{
			StopTimer();

			LastInvokeTime = DateTimeOffset.Now;
			var authorization = Browser.Authorize(appId, emailOrPhone, password, settings, code, captchaSid, captchaKey);
			if (!authorization.IsAuthorized)
			{
				throw new VkApiAuthorizationException($"Invalid authorization with {emailOrPhone} - {password}", emailOrPhone, password);
			}
			var expireTime = (Convert.ToInt32(authorization.ExpiresIn) - 10) * 1000;
			SetTimer(expireTime);
			AccessToken = authorization.AccessToken;
			UserId = authorization.UserId;
		}

        /// <summary>
        /// Авторизация и получение токена
        /// </summary>
        /// <param name="appId">Идентификатор приложения</param>
        /// <param name="emailOrPhone">Email или телефон</param>
        /// <param name="password">Пароль</param>
        /// <param name="code">Делегат получения кода для двух факторной авторизации</param>
        /// <param name="captchaSid">Идентификатор капчи</param>
        /// <param name="captchaKey">Текст капчи</param>
        /// <param name="settings">Права доступа для приложения</param>
        /// <exception cref="VkApiAuthorizationException"></exception>
        private void AuthorizeWithAntiCaptcha(ulong appId, string emailOrPhone, string password, Settings settings, Func<string> code, long? captchaSid = null, string captchaKey = null)
		{
			if (_captchaSolver == null)
			{
				Authorize(appId, emailOrPhone, password, settings, code, captchaSid, captchaKey);
			}
			else
			{
				var numberOfRemainingAttemptsToSolveCaptcha = MaxCaptchaRecognitionCount;
				var numberOfRemainingAttemptsToAuthorize = MaxCaptchaRecognitionCount + 1;
				var captchaSidTemp = captchaSid;
				var captchaKeyTemp = captchaKey;
				var authorizationCompleted = false;

				do
				{
					try
					{
						numberOfRemainingAttemptsToAuthorize--;
						Authorize(appId, emailOrPhone, password, settings, code, captchaSidTemp, captchaKeyTemp);

						authorizationCompleted = true;
					}
					catch (CaptchaNeededException captchaNeededException)
					{
						// Если мы обрабатываем исключение не первый раз, сообщаем решателю капчи
						// об ошибке распознавания предыдущей капчи
						if (numberOfRemainingAttemptsToSolveCaptcha < MaxCaptchaRecognitionCount)
						{
							_captchaSolver?.CaptchaIsFalse();
						}

					    if (numberOfRemainingAttemptsToSolveCaptcha <= 0)
					    {
					        continue;
					    }
						captchaSidTemp = captchaNeededException.Sid;
						captchaKeyTemp = _captchaSolver?.Solve(captchaNeededException.Img?.AbsoluteUri);
						numberOfRemainingAttemptsToSolveCaptcha--;
					}
				} while (numberOfRemainingAttemptsToAuthorize > 0 && !authorizationCompleted);

				// Повторно выбрасываем исключение, если капча ни разу не была распознана верно
				if (!authorizationCompleted && captchaSidTemp.HasValue)
				{
					throw new CaptchaNeededException(captchaSidTemp.Value, captchaKeyTemp);
				}
			}
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
        #endregion
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
            if (!parameters.ContainsKey("v"))
            {
                parameters.Add("v", VkApiVersion);
            }

            string answer = null;

			if (_captchaSolver == null)
			{
				answer = Invoke(methodName, parameters, skipAuthorization);
			}
			else
			{
				var numberOfRemainingAttemptsToSolveCaptcha = MaxCaptchaRecognitionCount;
				var numberOfRemainingAttemptsToCall = MaxCaptchaRecognitionCount + 1;
				long? captchaSidTemp = null;
				string captchaKeyTemp = null;
				var callCompleted = false;

				do
				{
					try
					{
						parameters.Add("captcha_sid", captchaSidTemp);
						parameters.Add("captcha_key", captchaKeyTemp);
						numberOfRemainingAttemptsToCall--;
						answer = Invoke(methodName, parameters, skipAuthorization);

						callCompleted = true;
					}
					catch (CaptchaNeededException captchaNeededException)
					{
						// Если мы обрабатываем исключение не первый раз, сообщаем решателю капчи
						// об ошибке распознавания предыдущей капчи
						if (numberOfRemainingAttemptsToSolveCaptcha < MaxCaptchaRecognitionCount)
						{
							_captchaSolver?.CaptchaIsFalse();
						}

					    if (numberOfRemainingAttemptsToSolveCaptcha <= 0)
					    {
					        continue;
					    }
						captchaSidTemp = captchaNeededException.Sid;
						captchaKeyTemp = _captchaSolver?.Solve(captchaNeededException.Img?.AbsoluteUri);
						numberOfRemainingAttemptsToSolveCaptcha--;
					}
				} while (numberOfRemainingAttemptsToCall > 0 && !callCompleted);

				// Повторно выбрасываем исключение, если капча ни разу не была распознана верно
				if (!callCompleted && captchaSidTemp.HasValue)
				{
					throw new CaptchaNeededException(captchaSidTemp.Value, captchaKeyTemp);
				}
			}

			var json = JObject.Parse(answer);

			var rawResponse = json["response"];

			return new VkResponse(rawResponse) { RawJson = answer };
		}

		/// <summary>
		/// Получить URL для API.
		/// </summary>
		/// <param name="methodName">Название метода.</param>
		/// <param name="parameters">Параметры.</param>
		/// <param name="skipAuthorization">Пропускать ли авторизацию</param>
		/// <returns></returns>
		public string GetApiUrlAndAddToken(string methodName, IDictionary<string, string> parameters, bool skipAuthorization = false)
		{
            if (!skipAuthorization)
            {
                parameters["access_token"] = AccessToken;
            }

			return $"https://api.vk.com/method/{methodName}";
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
				throw new AccessTokenInvalidException($@"Метод '{methodName}' нельзя вызывать без авторизации");
			}

			var url = "";
			var answer = "";

			Action sendRequest = delegate
			{
				url = GetApiUrlAndAddToken(methodName, parameters, skipAuthorization);
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
#if UWP
                        Task.Delay(timeout).Wait();
#else
                        Thread.Sleep(timeout);
#endif
                    }
					sendRequest();
				}
            } else if (skipAuthorization)
            {
				sendRequest();
            }

#if DEBUG && !UNIT_TEST
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
		public Task<string> InvokeAsync(string methodName, IDictionary<string, string> parameters, bool skipAuthorization = false)
		{
			var result = new Task<string>(() => Invoke(methodName, parameters, skipAuthorization));
			result.Start();
			return result;
		}

	    #region Implementation of IDisposable
		/// <summary>
		/// 
		/// </summary>
	    public void Dispose()
	    {
	        _expireTimer.Dispose();
	    }

	    #endregion
	}
}
