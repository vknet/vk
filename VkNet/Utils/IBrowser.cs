using System.Collections.Generic;
using System.Net;
using VkNet.Model;

namespace VkNet.Utils
{
	/// <summary>
	/// Интерфейс браузера, с помощью которого осуществляется сетевое взаимодействие.
	/// Интерфейс введен с целью обеспечения возможности выполнения модульного
	/// тестирования.
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
		/// <param name="url"> Адрес получения json </param>
		/// <param name="parameters"> Параметры метода api </param>
		/// <returns> Результат выполнения запроса, полученный от сервера в формате JSON. </returns>
		string GetJson(string url, IEnumerable<KeyValuePair<string, string>> parameters);

		/// <summary>
		/// Выполняет авторизацию ВКонтакте.
		/// </summary>
		/// <param name="authParams"> Параметры авторизации. </param>
		/// <returns>
		/// Информация об авторизации приложения.
		/// </returns>
		/// <remarks>
		/// Если приложение с идентификатором <paramref name="authParams.appId" /> не было
		/// установлено у пользователя, имеющего
		/// логин <paramref name="authParams.email" />, то производится его установка с
		/// разрешениями
		/// <paramref name="authParams.settings" />.
		/// </remarks>
		VkAuthorization Authorize(IApiAuthParams authParams);

		/// <summary>
		/// Выполняет обход ошибки валидации: https://vk.com/dev/need_validation
		/// </summary>
		/// <param name="validateUrl"> Адрес страницы валидации </param>
		/// <param name="phoneNumber">
		/// Номер телефона, который необходимо ввести на
		/// странице валидации
		/// </param>
		/// <returns> Информация об авторизации приложения. </returns>
		VkAuthorization Validate(string validateUrl, string phoneNumber);
	}
}