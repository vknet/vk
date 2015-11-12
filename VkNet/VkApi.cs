namespace VkNet
{
	using System;
	using System.Runtime.CompilerServices;
	using JetBrains.Annotations;

	using System.Collections.Generic;
	using System.Diagnostics;
	using System.Text;
	using System.Threading;
	using Newtonsoft.Json.Linq;

	using Categories;
	using Exception;
	using Utils;
	using Enums.Filters;

	/// <summary>
	/// Служит для оповещения об истечении токена
	/// </summary>
	/// <param name="api">Экземпляр API у которого истекло время токена</param>
	public delegate void VkApiDelegate(VkApi api);
	/// <summary>
	/// API для работы с ВКонтакте. Выступает в качестве фабрики для различных категорий API (например, для работы с пользователями, 
	/// группами и т.п.).
	/// </summary>
	public class VkApi
	{
		/// <summary>
		///  Текст ошибки авторизации.
		/// </summary>
		internal const string InvalidAuthorization = "Invalid authorization";
		/// <summary>
		/// Запросов в секунду.
		/// </summary>
		internal int _requestsPerSecond;

		/// <summary>
		/// Минимальное время, которое должно пройти между запросами чтобы не привысить кол-во запросов в секунду.
		/// </summary>
		internal int _minInterval;

		/// <summary>
		/// Учетные данные.
		/// </summary>
		internal KeyValuePair<string, string>? _credentials;
		/// <summary>
		/// Идентификатор приложения.
		/// </summary>
		internal int _appId;
		/// <summary>
		/// Права доступа приложения.
		/// </summary>
		internal Settings _settings;
		/// <summary>
		/// Таймер.
		/// </summary>
		private Timer _expireTimer;

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
		public int RequestsPerSecond
		{
			get { return _requestsPerSecond; }
			set
			{
                if (value > 0)
                {
                    _requestsPerSecond = value;
                    _minInterval = 1000 / _requestsPerSecond + 1;
                }
                else if (value == 0)
                    _requestsPerSecond = 0;
                else
                    throw new ArgumentException("Value must be positive", "RequestsPerSecond");
			}
		}

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
		public FriendsCategory Friends
		{ get; private set; }
		/// <summary>
		/// API для работы со статусом пользователя или сообщества.
		/// </summary>
		public StatusCategory Status
		{ get; private set; }
		/// <summary>
		/// API для работы с сообщениями.
		/// </summary>
		public MessagesCategory Messages
		{ get; private set; }
		/// <summary>
		/// API для работы с .
		/// </summary>
		public GroupsCategory Groups
		{ get; private set; }
		/// <summary>
		/// API для работы с аудиозаписями.
		/// </summary>
		public AudioCategory Audio
		{ get; private set; }
		/// <summary>
		/// API для получения справочной информации (страны, города, школы, учебные заведения и т.п.).
		/// </summary>
		public DatabaseCategory Database
		{ get; private set; }
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
		/// API для работы с закладками.
		/// </summary>
		public FaveCategory Fave
		{ get; private set; }
		/// <summary>
		/// API для работы с видеофайлами.
		/// </summary>
		public VideoCategory Video
		{ get; private set; }
		/// <summary>
		/// API для работы с аккаунтом пользователя.
		/// </summary>
		public AccountCategory Account
		{ get; private set; }
		/// <summary>
		/// API для работы с фотографиями
		/// </summary>
		public PhotoCategory Photo
		{ get; private set; }
		/// <summary>
		/// API для работы с документами
		/// </summary>
		public DocsCategory Docs
		{ get; private set; }
		/// <summary>
		/// API для работы с лайками
		/// </summary>
		public LikesCategory Likes
		{ get; private set; }


		/// <summary>
		/// API для работы с wiki.
		/// </summary>
		public PagesCategory Pages
		{ get; set; }

		/// <summary>
		/// API для работы с приложениями.
		/// </summary>
		public AppsCategory Apps
		{ get; set; }

		/// <summary>
		/// API для работы с новостной лентой.
		/// </summary>
		public NewsFeedCategory NewsFeed { get; set; }

		/// <summary>
		/// API для работы со статистикой.
		/// </summary>
		public StatsCategory Stats { get; set; }

		/// <summary>
		/// API для работы с подарками.
		/// </summary>
		public GiftsCategory Gifts
		{ get; set; }
		#endregion

		/// <summary>
		/// Браузер.
		/// </summary>
		internal IBrowser Browser
		{ get; set; }

		/// <summary>
		/// Токен для доступа к методам API
		/// </summary>
		public string AccessToken
		{ get; set; }

		/// <summary>
		/// Идентификатор пользователя, от имени которого была проведена авторизация.
		/// Если авторизация не была произведена с использованием метода <see cref="Authorize(int,string,string,Settings,long?,string)"/>, 
		/// то возвращается null.
		/// </summary>
		public long? UserId
		{ get; set; }

		/// <summary>
		/// Инициализирует новый экземпляр класса <see cref="VkApi"/>.
		/// </summary>
		public VkApi()
		{
			Browser = new Browser();

			Users = new UsersCategory(this);
			Friends = new FriendsCategory(this);
			Status = new StatusCategory(this);
			Messages = new MessagesCategory(this);
			Groups = new GroupsCategory(this);
			Audio = new AudioCategory(this);
			Wall = new WallCategory(this);
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

			RequestsPerSecond = 3;
		}

		/// <summary>
		/// Авторизация и получение токена
		/// </summary>
		/// <param name="appId">Идентификатор приложения</param>
		/// <param name="emailOrPhone">Email или телефон</param>
		/// <param name="password">Пароль</param>
		/// <param name="code">Делегат получения кода для двухфакторной авторизации</param>
		/// <param name="captchaSid">Идентикикатор капчи</param>
		/// <param name="captchaKey">Текст капчи</param>
		/// <param name="settings">Права доступа для приложения</param>
		public void Authorize(int appId, string emailOrPhone, string password, Settings settings, Func<string> code = null, long? captchaSid = null, string captchaKey = null)
		{
			_authorize(appId, emailOrPhone, password, settings, code, captchaSid, captchaKey);

			_credentials = new KeyValuePair<string, string>(emailOrPhone, password);
			_appId = appId;
			_settings = settings;
		}

		/// <summary>
		/// Выполняет авторизацию с помощью маркера доступа (access token), полученного извне.
		/// </summary>
		/// <param name="accessToken">Маркер доступа, полученный извне.</param>
		/// <param name="userId">Идентификатор пользователя, установившего приложение (необязательный параметр).</param>
		public void Authorize(string accessToken, long? userId = null)
		{
			_stopTimer();

			AccessToken = accessToken;
			UserId = userId;
			_credentials = null;
		}

		/// <summary>
		/// Получает новый AccessToken использую логин, пароль, приложение и настройки указанные при последней авторизации.
		/// </summary>
		public void RefreshToken(Func<string> code = null)
		{
			if (_credentials.HasValue)
			{
				_authorize(_appId, _credentials.Value.Key, _credentials.Value.Value, _settings, code);
			}
			else
			{
				throw new AggregateException(
					"Невозможно обновить токен доступа т.к. последняя авторизация происходила не при помощи логина и пароля");
			}
		}

		#region Private & Internal Methods

		/// <summary>
		/// Авторизация и получение токена
		/// </summary>
		/// <param name="appId">Идентификатор приложения</param>
		/// <param name="emailOrPhone">Email или телефон</param>
		/// <param name="password">Пароль</param>
		/// <param name="code">Делегат получения кода для двухфакторной авторизации</param>
		/// <param name="captchaSid">Идентикикатор капчи</param>
		/// <param name="captchaKey">Текст капчи</param>
		/// <param name="settings">Права доступа для приложения</param>
		/// <exception cref="VkApiAuthorizationException"></exception>
		internal void _authorize(int appId, string emailOrPhone, string password, Settings settings, Func<string> code, long? captchaSid = null, string captchaKey = null)
		{
			_stopTimer();

			var authorization = Browser.Authorize(appId, emailOrPhone, password, settings, code, captchaSid, captchaKey);
			if (!authorization.IsAuthorized)
			{
				throw new VkApiAuthorizationException(InvalidAuthorization, emailOrPhone, password);
			}
			int expireTime = (Convert.ToInt32(authorization.ExpiresIn) - 10) * 1000;
			if (expireTime > 0)
			{
				_expireTimer = new Timer(_alertExpires, null, expireTime, Timeout.Infinite);
			}

			AccessToken = authorization.AccessToken;
			UserId = authorization.UserId;
		}
		/// <summary>
		/// Прекращает работу таймера оповещения
		/// </summary>
		private void _stopTimer()
		{
			if (_expireTimer != null)
			{
				_expireTimer.Dispose();
			}
		}
		/// <summary>
		/// Создает событие оповещения об окончании времени токена
		/// </summary>
		/// <param name="state"></param>
		private void _alertExpires(object state)
		{
			if (OnTokenExpires != null)
			{
				OnTokenExpires(this);
			}
		}
#if false
		// todo refactor this shit
		internal async Task<VkResponse> CallAsync(string methodName, VkParameters parameters, bool skipAuthorization = false)
		{
			if (!skipAuthorization)
				IfNotAuthorizedThrowException();

			string url = GetApiUrl(methodName, parameters);

			string answer = await Browser.GetJsonAsync(url);

#if DEBUG
			Trace.WriteLine(Utilities.PreetyPrintApiUrl(url));
			Trace.WriteLine(Utilities.PreetyPrintJson(answer));
#endif
			VkErrors.IfErrorThrowException(answer);

			JObject json = JObject.Parse(answer);

			var rawResponse = json["response"];

			return new VkResponse(rawResponse) { RawJson = answer };
		}
#endif

		/// <summary>
		/// Вызвать метод.
		/// </summary>
		/// <param name="methodName">Название метода.</param>
		/// <param name="parameters">Параметры.</param>
		/// <param name="skipAuthorization">Если <c>true</c> то пропустить авторизацию.</param>
		/// <param name="apiVersion">Версия API.</param>
		/// <returns></returns>
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal VkResponse Call(string methodName, VkParameters parameters, bool skipAuthorization = false, string apiVersion = null)
		{
			if (!parameters.ContainsKey("v"))
			{
				if (!string.IsNullOrEmpty(apiVersion))
					parameters.Add("v", apiVersion);
				else
				{
					//TODO: WARN: раскомментировать после добавления аннотаций ко всем методам
					//throw new InvalidParameterException("You must use ApiVersionAttribute except adding \"v\" parameter to VkParameters");
				}
			} else
			{
				//TODO: WARN: раскомментировать, исправив ошибки в существующем коде
				//throw new InvalidParameterException("You must use ApiVersionAttribute except adding \"v\" parameter to VkParameters");
			}

			return Call(methodName, parameters, skipAuthorization);
		}

		/// <summary>
		/// Вызвать метод.
		/// </summary>
		/// <param name="methodName">Название метода.</param>
		/// <param name="parameters">Параметры.</param>
		/// <param name="skipAuthorization">Если <c>true</c> то пропустить авторизацию.</param>
		/// <returns></returns>
		private VkResponse Call(string methodName, VkParameters parameters, bool skipAuthorization = false)
		{
			string answer = Invoke(methodName, parameters, skipAuthorization);

			JObject json = JObject.Parse(answer);

			var rawResponse = json["response"];

			return new VkResponse(rawResponse) { RawJson = answer };
		}

		/// <summary>
		/// Прямой вызов API-метода
		/// </summary>
		/// <param name="methodName">Название метода. Например, "wall.get".</param>
		/// <param name="parameters">Вход. параметры метода.</param>
		/// <param name="skipAuthorization">Флаг, что метод можно вызывать без авторизации.</param>
		/// <returns>Ответ сервера в формате JSON.</returns>
		[CanBeNull]
		public string Invoke(string methodName, IDictionary<string, string> parameters, bool skipAuthorization = false)
		{
			if (!skipAuthorization)
				IfNotAuthorizedThrowException();

			// Защита от превышения кол-ва запросов в секунду
            if (RequestsPerSecond > 0 && LastInvokeTime.HasValue)
            {
                TimeSpan span = LastInvokeTimeSpan.Value;
                LastInvokeTime = DateTimeOffset.Now;
                if (span.TotalMilliseconds < _minInterval)
                    Thread.Sleep(_minInterval - (int)span.TotalMilliseconds);
            }

			string url = GetApiUrl(methodName, parameters);

			string answer = Browser.GetJson(url);

#if DEBUG && !UNIT_TEST
			Trace.WriteLine(Utilities.PreetyPrintApiUrl(url));
			Trace.WriteLine(Utilities.PreetyPrintJson(answer));
#endif
			VkErrors.IfErrorThrowException(answer);

			return answer;
		}

		/// <summary>
		/// Получить URL для API.
		/// </summary>
		/// <param name="methodName">Название метода.</param>
		/// <param name="parameters">Параметры.</param>
		/// <returns></returns>
		internal string GetApiUrl(string methodName, IDictionary<string, string> parameters)
		{
			var builder = new StringBuilder();

			builder.AppendFormat("{0}{1}?", "https://api.vk.com/method/", methodName);

			foreach (var pair in parameters)
			{
				builder.AppendFormat("{0}={1}&", pair.Key, pair.Value);
			}
			builder.AppendFormat("access_token={0}", AccessToken);

			return builder.ToString();
		}

		/// <summary>
		/// Бросить исключение если не авторизован.
		/// </summary>
		/// <exception cref="AccessTokenInvalidException"></exception>
		internal void IfNotAuthorizedThrowException()
		{
			if (string.IsNullOrEmpty(AccessToken))
			{
				throw new AccessTokenInvalidException();
			}
		}

		#endregion
	}
}
