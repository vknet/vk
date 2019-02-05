﻿using System;
using System.Collections.Generic;
using System.Net;
using VkNet.Abstractions.Authorization;
using VkNet.Abstractions.Core;
using VkNet.Model;

namespace VkNet.Utils
{
	/// <summary>
	/// Интерфейс браузера, с помощью которого осуществляется сетевое взаимодействие.
	/// Интерфейс введен с целью обеспечения возможности выполнения модульного
	/// тестирования.
	/// </summary>
	[Obsolete("Интерфейс был разделен на IImplicitFlow и INeedValidationHandler")]
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

		/// <summary>
		/// Задать параметры авторизации
		/// </summary>
		/// <param name="authParams">Параметры авторизации</param>
		[Obsolete("Настройки должны внедряться через DI", true)]
		void SetAuthParams(IApiAuthParams authParams);
	}
}