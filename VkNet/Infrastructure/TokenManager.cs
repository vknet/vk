using System;
using System.Threading;
using Microsoft.Extensions.Logging;
using VkNet.Abstractions;
using VkNet.Abstractions.Core;

namespace VkNet.Infrastructure
{
	/// <inheritdoc />
	public class TokenManager : ITokenManager
	{
		private readonly IVkApi _api;

		private readonly ILogger _logger;

		private int _expireTime;

		private Timer _expireTimer;

		/// <summary>
		/// Инициализирует новый экземпляр класса <see cref="TokenManager" /> с указаным
		/// <see cref="IVkApi" /> и <see cref="ILogger" />.
		/// </summary>
		/// <param name="api"> Экземпляр класса <see cref="IVkApi" />. </param>
		/// <param name="logger"> Экземпляр класса <see cref="ILogger" />. </param>
		public TokenManager(IVkApi api, ILogger logger)
		{
			_api = api;
			_logger = logger;
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса <see cref="TokenManager" />.
		/// </summary>
		public TokenManager()
		{
		}

		/// <summary>
		/// Expires in DateTime.
		/// </summary>
		private DateTime ExpiresInDateTime => DateTime.Now.Add(TimeSpan.FromSeconds(ExpireTime));

		/// <inheritdoc />
		public long? UserId { get; set; }

		/// <inheritdoc />
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		/// <inheritdoc />
		public event VkApiDelegate OnTokenExpires;

		/// <inheritdoc />
		public string Token { get; internal set; }

		/// <inheritdoc />
		public bool IsAuthorized => !string.IsNullOrWhiteSpace(Token);

		/// <inheritdoc />
		public int ExpireTime
		{
			get => _expireTime;
			set
			{
				_expireTime = value;
				SetTimer(_expireTime);
			}
		}

		/// <inheritdoc />
		public bool IsExpired => ExpireTime != 0 && DateTime.Now > ExpiresInDateTime;

		/// <inheritdoc />
		public bool RefreshToken()
		{
			if (_api?.AccessToken == null || _api?.AuthorizationFlow == null)
			{
				_logger?.LogWarning("Невозможно обновить токен.");

				return false;
			}

			_api.Authorize(_api.AuthorizationFlow);

			return _api.AccessToken.IsAuthorized;
		}

		/// <inheritdoc />
		public void SetToken(string token)
		{
			Token = token;
		}

		/// <summary>
		/// Releases unmanaged and - optionally - managed resources.
		/// </summary>
		/// <param name="disposing">
		/// <c> true </c> to release both managed and unmanaged resources; <c> false </c>
		/// to release only
		/// unmanaged resources.
		/// </param>
		public virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				_expireTimer?.Dispose();
			}
		}

		/// <summary>
		/// Создаёт новый экземпляр класса <see cref="TokenManager" /> из строки.
		/// </summary>
		/// <param name="token"> Access Token </param>
		/// <param name="userId"> User Id </param>
		/// <returns> </returns>
		public static TokenManager FromString(string token, long? userId = null)
		{
			var session = new TokenManager
			{
				ExpireTime = default(int),
				UserId = userId
			};

			session.SetToken(token);

			return session;
		}

		/// <summary>
		/// Создает событие оповещения об окончании времени токена
		/// </summary>
		/// <param name="state"> </param>
		private void AlertExpires(object state)
		{
			OnTokenExpires?.Invoke(_api);
		}

		/// <summary>
		/// Установить значение таймера
		/// </summary>
		/// <param name="expireTime"> Значение таймера </param>
		private void SetTimer(int expireTime)
		{
			_expireTimer = new Timer(AlertExpires,
				null,
				expireTime > 0 ? expireTime : Timeout.Infinite,
				Timeout.Infinite);
		}
	}
}