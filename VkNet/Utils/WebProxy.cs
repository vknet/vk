using System;
using System.Net;

namespace VkNet.Utils;

/// <inheritdoc cref="IWebProxy" />
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
	private WebProxy(Uri proxyUri) => _proxyUri = proxyUri;

	/// <inheritdoc />
	public ICredentials Credentials { get; set; }

	/// <inheritdoc />
	public Uri GetProxy(Uri destination) => _proxyUri;

	/// <inheritdoc />
	public bool IsBypassed(Uri host) => false;

	/// <summary>
	/// Получить данные авторизации
	/// </summary>
	/// <param name="proxyLogin"> Логин </param>
	/// <param name="proxyPassword"> Пароль </param>
	/// <returns> Данные авторизации </returns>
	private static ICredentials GetCredentials(string proxyLogin = null, string proxyPassword = null)
	{
		if (proxyLogin is not null && proxyPassword is not null)
		{
			return new NetworkCredential(proxyLogin, proxyPassword);
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
		if (host is null || port is null)
		{
			return null;
		}

		return new WebProxy(proxyUri: new(uriString: $"http://{host}:{port.Value}"))
		{
			Credentials = GetCredentials(proxyLogin, proxyPassword)
		};
	}
}