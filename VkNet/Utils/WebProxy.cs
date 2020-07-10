using System;
using System.Net;

namespace VkNet.Utils
{
	/// <inheritdoc />
	/// <summary>
	/// Реализация WebProxy
	/// </summary>
	public class WebProxy : IWebProxy
	{
		/// <summary>
		/// Uri прокси
		/// </summary>
		private readonly Uri _proxyUri;

		/// <summary>
		/// Инициализация класса прокси
		/// </summary>
		/// <param name="proxyUri"> Uri прокси </param>
		private WebProxy(Uri proxyUri)
		{
			_proxyUri = proxyUri;
		}

		/// <inheritdoc />
		public ICredentials Credentials { get; set; }

		/// <inheritdoc />
		public Uri GetProxy(Uri destination)
		{
			return _proxyUri;
		}

		/// <inheritdoc />
		public bool IsBypassed(Uri host)
		{
			return false;
		}

		/// <summary>
		/// Получить данные авторизации
		/// </summary>
		/// <param name="proxyLogin"> Логин </param>
		/// <param name="proxyPassword"> Пароль </param>
		/// <returns> Данные авторизации </returns>
		private static ICredentials GetCredentials(string proxyLogin = null, string proxyPassword = null)
		{
			if (proxyLogin != null && proxyPassword != null)
			{
				return new NetworkCredential(userName: proxyLogin, password: proxyPassword);
			}

			// Авторизация с реквизитами по умолчанию (для NTLM прокси)
			return CredentialCache.DefaultCredentials;
		}

		/// <summary>
		/// Получить прокси
		/// </summary>
		/// <param name="host"> Имя узла прокси-сервера </param>
		/// <param name="port"> Порт </param>
		/// <param name="proxyLogin"> Логин </param>
		/// <param name="proxyPassword"> Пароль </param>
		/// <returns> Прокси </returns>
		public static IWebProxy GetProxy(string host = null, int? port = null, string proxyLogin = null, string proxyPassword = null)
		{
			if (host == null || port == null)
			{
				return null;
			}

			return new WebProxy(proxyUri: new Uri(uriString: $"http://{host}:{port.Value}"))
			{
				Credentials = GetCredentials(proxyLogin: proxyLogin, proxyPassword: proxyPassword)
			};
		}
	}
}