using System;
using System.Collections.Generic;
using System.Net;
using VkNet.Abstractions.Authorization;
using VkNet.Abstractions.Core;

namespace VkNet.Utils
{
	/// <summary>
	/// Интерфейс браузера, с помощью которого осуществляется сетевое взаимодействие.
	/// Интерфейс введен с целью обеспечения возможности выполнения модульного
	/// тестирования.
	/// </summary>
	[Obsolete(ObsoleteText.Browser)]
	public interface IBrowser: IImplicitFlow, INeedValidationHandler
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
	}
}